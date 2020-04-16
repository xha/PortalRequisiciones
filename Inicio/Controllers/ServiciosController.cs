using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Datos.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Inicio.Services;

namespace Inicio.Controllers
{
    [Authorize]
    public class ServiciosController : Controller
    {
        private static BDWENCO Wenco;
        private static BDCOMUN Comun;
        public REQUISC_PORTAL Modelo = new REQUISC_PORTAL();
        public REQUISD_PORTAL ModeloDetalle = new REQUISD_PORTAL();
        public USUARIO_COMP ModeloUsuComp = new USUARIO_COMP();

        public ServiciosController(BDCOMUN context, BDWENCO context2)
        {
            Comun = context;
            Wenco = context2;
        }

        /********************************************************************************************************************************************/
        //LLAMADOS JSON
        public JsonResult Areas()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_AREA> area = Wenco?.AREA.FromSqlRaw("SP_PORTAL_LISTADO_AREA '" + empresa + "'").ToList();

            var Resultado = (from N in area
                             orderby N.AREA
                             select N);

            return Json(Resultado);
        }

        public JsonResult LServicios()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            string tipo = HttpContext.Session.GetString("TipoDocumento");
            List<SP_PORTAL_LISTADO_ARTICULO_RQ> articulo = Wenco?.ARTICULO.FromSqlRaw("SP_PORTAL_LISTADO_ARTICULO_RQ '" + empresa + "BDCOMUN','" + tipo + "'").ToList();

            var Resultado = (from N in articulo
                             orderby N.ARTICULO
                             select new { N.CODIGO, DESCRIPCION = N.ARTICULO.Replace('"', ' '), N.STOCK, N.COD_FAMILIA, N.UNIDAD,N.FAMILIA });

            return Json(Resultado);
        }

        public JsonResult Solicitantes()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_SOLICITANTE> solicitante = Wenco?.SOLICITANTE.FromSqlRaw("SP_PORTAL_LISTADO_SOLICITANTE '" + empresa + "'").ToList();

            var Resultado = (from N in solicitante
                             orderby N.SOLICITANTE
                             select N);

            return Json(Resultado);
        }

        public JsonResult CentroCosto()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_CENTROCOSTO_COMP> centro_costo = Wenco?.CENTRO_COSTO.FromSqlRaw("SP_PORTAL_LISTADO_CENTROCOSTO_COMP '" + empresa + "'").ToList();

            var Resultado = (from N in centro_costo
                             orderby N.CENTRO_COSTO
                             select N);

            return Json(Resultado);
            /* string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_CENTROCOSTO_COMP> centro_costo = Wenco?.CENTRO_COSTO.FromSqlRaw("SP_PORTAL_LISTADO_CENTROCOSTO_COMP '" + empresa + "'").ToList();

            var Resultado = (from N in centro_costo
                             orderby N.CENTRO_COSTO
                             select N);

            List<SP_PORTAL_LISTADO_CENTROCOSTO_COMP> retorno = Resultado.ToList<SP_PORTAL_LISTADO_CENTROCOSTO_COMP>();

            return retorno;*/
        }

        public JsonResult OrdenFabricacion()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_ORDEN_FABRICACION> orden = Wenco?.ORDEN_FABRICACION.FromSqlRaw("SP_PORTAL_LISTADO_ORDEN_FABRICACION '" + empresa + "'").ToList();

            var Resultado = (from N in orden
                             orderby N.ORDEN_FABRICACION
                             select N);

            return Json(Resultado);
        }

        [HttpPost]
        public JsonResult ListadoServicios(string fecha_desde, string fecha_hasta)
        {
            RehacerConexion();
            string empresa = "[" + HttpContext.Session.GetString("empresa").ToString() + "BDCOMUN]";
            //List<REQUISC_PORTAL> compras = Comun.REQUISC_PORTAL.Where(p => p.TIPOREQUI == "RQ").ToList();
            var cadena = "SELECT RC.NROREQUI AS NUMERO,S.TDESCRI AS SOLICITANTE,A.AREA_DESCRIPCION AS AREA,RC.FECREQUI AS FECHA,R.ESTREQUI AS ESTADO ";
            cadena += "FROM " + empresa + ".DBO.REQUISC_PORTAL AS RC ";
            cadena += "LEFT JOIN " + empresa + ".DBO.TABAYU AS S ON S.TCOD = '12' AND S.TCLAVE = RC.CODSOLIC ";
            cadena += "LEFT JOIN " + empresa + ".DBO.AREA AS A ON A.AREA_CODIGO = RC.AREA ";
            cadena += "LEFT JOIN " + empresa + ".DBO.REQUISC AS R ON R.TIPOREQUI = RC.TIPOREQUI AND R.NRO_REQUERIMIENTO_PORTAL = RC.NROREQUI ";
            cadena += "WHERE RC.TIPOREQUI='RS' and RC.FECREQUI BETWEEN '" + fecha_desde + "' AND '" + fecha_hasta + "' ORDER BY RC.NROREQUI";
            List<REQUISC> compras = Comun?.REQUISC.FromSqlRaw(cadena).ToList();

            var Resultado = (from N in compras
                             orderby N.FECHA
                             select N);

            return Json(Resultado);
        }

        [HttpPost]
        public JsonResult ListadoDetalle(string codigo)
        {
            RehacerConexion();
            List<REQUISD_PORTAL> detalle = Comun?.REQUISD_PORTAL.Where(p => p.NROREQUI == codigo && p.TIPOREQUI == "RS").ToList();

            var Resultado = (from N in detalle
                             orderby N.REQITEM
                             select N);

            return Json(Resultado);
        }

        [HttpGet]
        public string Correlativo()
        {
            string correl = "";
            int maximo = Convert.ToInt32(Comun.REQUISC_PORTAL.Where(p => p.TIPOREQUI == "RS").Max(p => p.NROREQUI)) + 1;
            int minimo = maximo.ToString().Length;
            for (int i = minimo; i < 10; i++) correl += "0";

            return correl + maximo;
        }

        [HttpGet]
        public JsonResult ListadoErrores(string codigo)
        {
            RehacerConexion();
            List<OBS_PORTAL_RQ> obs = Comun.OBS.Where(p => p.NRO_RQ == codigo).ToList();

            var Resultado = (from N in obs
                             select N);

            return Json(Resultado);
        }
        /********************************************************************************************************************************************/
        public void RehacerConexion()
        {
            dynamic d = TempData.Get<dynamic>("DataServer");
            if (d != null)
            {
                JObject datosSesion = new JObject();
                datosSesion.Add(new JProperty("servidor", ModeloUsuComp.Desencriptar(d.servidor.ToString())));
                datosSesion.Add(new JProperty("Base_datos", ModeloUsuComp.Desencriptar(d.Base_datos.ToString())));
                datosSesion.Add(new JProperty("usuario_server", ModeloUsuComp.Desencriptar(d.usuario_server.ToString())));
                datosSesion.Add(new JProperty("contrasenia", ModeloUsuComp.Desencriptar(d.contrasenia.ToString())));
                datosSesion.Add(new JProperty("empresa", TempData["USU_EMPRESA"].ToString()));
                HttpContext.Session.SetString("empresa", TempData["USU_EMPRESA"].ToString());
                HttpContext.Session.SetString("USU_CODIGO", TempData["USU_CODIGO"].ToString());
                HttpContext.Session.SetString("USU_NOMBRE", TempData["USU_NOMBRE"].ToString());

                HttpContext.Session.SetObjectAsJson("DataServer", datosSesion);
            }

            TempData.Keep();
            dynamic s = HttpContext.Session.GetObjectFromJson<dynamic>("DataServer");

            var optionsBuilder = new DbContextOptionsBuilder<BDWENCO>();
            //services.AddDbContext<BDCOMUN>(options => options.UseSqlServer(Configuration.GetConnectionString("BDCOMUNConnectionString")));
            string cadena = "Data Source=" + s.servidor + ";Initial Catalog=" + s.Base_datos + ";MultipleActiveResultSets=true;User ID=" + s.usuario_server + ";Password=" + s.contrasenia + "";
            optionsBuilder.UseSqlServer(cadena);
            Wenco = new BDWENCO(optionsBuilder.Options);

            var optionsBuilder2 = new DbContextOptionsBuilder<BDCOMUN>();
            cadena = "Data Source=" + s.servidor + ";Initial Catalog=" + s.empresa + "BDCOMUN;MultipleActiveResultSets=true;User ID=" + s.usuario_server + ";Password=" + s.contrasenia + "";
            optionsBuilder2.UseSqlServer(cadena);
            Comun = new BDCOMUN(optionsBuilder2.Options);
        }

        [HttpGet]
        public bool RequisicionExiste(string codigo)
        {
            RehacerConexion();
            List<REQUISC_PORTAL> compras = Comun.REQUISC_PORTAL.Where(p => p.TIPOREQUI == "RS" && p.NROREQUI == codigo).ToList();

            if (compras.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            };
        }
        /********************************************************************************************************************************************/

        // GET: Servicios
        public ActionResult Index()
        {
            DateTime hoy = DateTime.Now;

            string fecha_hasta = hoy.ToString("dd/MM/yyyy");
            string fecha_desde = hoy.ToString("MM/yyyy");
            fecha_desde = "01/" + fecha_desde;
            HttpContext.Session.SetString("TipoDocumento", "RS");
            JsonResult Servicios = ListadoServicios(fecha_desde, fecha_hasta);
            
            ViewBag.ListadoServicios = Servicios;
            ViewBag.AServicios = "activo";

            return View();
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            RehacerConexion();
            ViewBag.AServicios = "activo";
            JsonResult areas = Areas();
            JsonResult servicios = LServicios();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Servicios = servicios;
            ViewBag.CentroCosto = centro;
            ViewBag.OrdenFabricacion = orden;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string detalle, [Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento,COD_USUARIO")] REQUISC_PORTAL modelo)
        {
            RehacerConexion();
            if (ModelState.IsValid)
            {
                try
                {
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    //modelo.NROREQUI = modelo.NROREQUI.Trim();
                    modelo.NROREQUI = Correlativo();
                    //modelo.FECREQUI = Convert.ToDateTime(modelo.FECREQUI + " " + hora);
                    Comun.REQUISC_PORTAL.Add(modelo);
                    await Comun.SaveChangesAsync();

                    JArray ArrayDetalle = JArray.Parse(detalle);
                    int i = 0;
                    int longitud = ArrayDetalle.Count;
                    foreach (JObject item in ArrayDetalle)
                    {
                        i++;
                        ModeloDetalle.CODPRO = item.GetValue("codigo").ToString();
                        ModeloDetalle.DESCPRO = item.GetValue("descripcion").ToString();
                        ModeloDetalle.UNIPRO = item.GetValue("unidad").ToString();
                        ModeloDetalle.CANTID = Convert.ToDecimal(item.GetValue("cantidad"));
                        ModeloDetalle.FECREQUE = Convert.ToDateTime(item.GetValue("fecha_req") + " " + hora);
                        ModeloDetalle.CENCOST = item.GetValue("centro_costo").ToString();
                        ModeloDetalle.NROREQUI = modelo.NROREQUI;
                        ModeloDetalle.ORDFAB_REQUI = item.GetValue("orden_fabricacion").ToString();
                        ModeloDetalle.GLOSA = item.GetValue("glosa_servicio").ToString();
                        ModeloDetalle.REQITEM = i;
                        ModeloDetalle.SALDO = Convert.ToDecimal(item.GetValue("cantidad"));
                        ModeloDetalle.REMAQ = item.GetValue("nro_maquina").ToString();
                        ModeloDetalle.TIPOREQUI = modelo.TIPOREQUI;
                        if (i == longitud)
                        {
                            ModeloDetalle.LISTO_CARGAR = true;
                        }
                        else
                        {
                            ModeloDetalle.LISTO_CARGAR = false;
                        }
                        ModeloDetalle.ESTADO = false;

                        Comun.REQUISD_PORTAL.Add(ModeloDetalle);
                        //await Comun.SaveChangesAsync();
                        await Comun.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewBag.Error = "Faltan campos importantes";
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.AServicios = "activo";
            JsonResult areas = Areas();
            JsonResult servicios = LServicios();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Servicios = servicios;
            ViewBag.CentroCosto = centro;
            ViewBag.OrdenFabricacion = orden;

            return View();
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(string codigo)
        {
            ViewBag.AServicios = "activo";
            RehacerConexion();
            if (codigo == null)
            {
                return NotFound();
            }

            var modelo = await Comun.REQUISC_PORTAL.FindAsync(codigo, "RS");
            if (modelo == null)
            {
                return NotFound();
            }

            JsonResult areas = Areas();
            JsonResult servicios = LServicios();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Servicios = servicios;
            ViewBag.CentroCosto = centro;
            ViewBag.OrdenFabricacion = orden;

            return View(modelo);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string detalle, [Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento,COD_USUARIO")] REQUISC_PORTAL modelo)
        {
            RehacerConexion();
            if (ModelState.IsValid)
            {
                try
                {
                    Comun.Database.ExecuteSqlRaw("DELETE FROM REQUISD_PORTAL WHERE NROREQUI=" + modelo.NROREQUI);
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    Comun.REQUISC_PORTAL.Update(modelo);
                    await Comun.SaveChangesAsync();

                    JArray ArrayDetalle = JArray.Parse(detalle);
                    int i = 0;
                    int longitud = ArrayDetalle.Count;
                    foreach (JObject item in ArrayDetalle)
                    {
                        i++;
                        ModeloDetalle.CODPRO = item.GetValue("codigo").ToString();
                        ModeloDetalle.DESCPRO = item.GetValue("descripcion").ToString();
                        ModeloDetalle.UNIPRO = item.GetValue("unidad").ToString();
                        ModeloDetalle.CANTID = Convert.ToDecimal(item.GetValue("cantidad"));
                        ModeloDetalle.FECREQUE = Convert.ToDateTime(item.GetValue("fecha_req") + " " + hora);
                        ModeloDetalle.CENCOST = item.GetValue("centro_costo").ToString();
                        ModeloDetalle.NROREQUI = modelo.NROREQUI;
                        ModeloDetalle.ORDFAB_REQUI = item.GetValue("orden_fabricacion").ToString();
                        ModeloDetalle.GLOSA = item.GetValue("glosa_servicio").ToString();
                        ModeloDetalle.REQITEM = i;
                        ModeloDetalle.SALDO = Convert.ToDecimal(item.GetValue("cantidad"));
                        ModeloDetalle.REMAQ = item.GetValue("nro_maquina").ToString();
                        ModeloDetalle.TIPOREQUI = modelo.TIPOREQUI;
                        if (i == longitud)
                        {
                            ModeloDetalle.LISTO_CARGAR = true;
                        }
                        else
                        {
                            ModeloDetalle.LISTO_CARGAR = false;
                        }
                        ModeloDetalle.ESTADO = false;

                        Comun.REQUISD_PORTAL.Add(ModeloDetalle);
                        await Comun.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return View(modelo);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(modelo);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var jsonData = new
            {
                resultado = false,
                error = "",
            };

            try
            {
                RehacerConexion();
                //ESTA ES LA FORMA FACIL
                //Comun.Database.ExecuteSqlRaw("DELETE FROM REQUISD_PORTAL WHERE NROREQUI=" + id);

                //ESTA FORMA DA ERROR A MULTIPLES DELETE
                //Comun.REQUISD_PORTAL.RemoveRange(Comun.REQUISD_PORTAL.Where(s => s.NROREQUI == id));
                //Comun.REQUISD_PORTAL.Remove(Comun.REQUISD_PORTAL.Find(id));
                //Comun.REQUISD_PORTAL.Where(p => p.NROREQUI == id).ToList().ForEach(p => Comun.REQUISD_PORTAL.Remove(p));
                //Comun.SaveChanges();
                //LA FORMA POR ENTITY ES RECORRER EL LISTADO E IR BORRANDO LINEA A LINEA

                Comun.REQUISC_PORTAL.Remove(Comun.REQUISC_PORTAL.Find(id, "RS"));
                Comun.SaveChanges();

                jsonData = new
                {
                    resultado = true,
                    error = "",
                };

            }
            catch (Exception ex)
            {
                jsonData = new
                {
                    resultado = false,
                    error = "Error en la ejecución de comando"
                };
            }

            return Json(jsonData);
        }

        private bool REQUISC_PORTALExists(string id)
        {
            return Comun.REQUISC_PORTAL.Any(e => e.NROREQUI == id);
        }
    }
}
