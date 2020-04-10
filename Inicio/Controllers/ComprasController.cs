﻿using System;
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
    public class ComprasController : Controller
    {
        private static BDWENCO Wenco;
        private static BDCOMUN Comun;
        public REQUISC_PORTAL Modelo = new REQUISC_PORTAL();
        public REQUISD_PORTAL ModeloDetalle = new REQUISD_PORTAL();
        public USUARIO_COMP ModeloUsuComp = new USUARIO_COMP();

        public ComprasController(BDCOMUN context, BDWENCO context2)
        {
            Comun = context;
            Wenco = context2;
        }

        /********************************************************************************************************************************************/
        //LLAMADOS JSON
        public JsonResult Areas()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_AREA> area = Comun?.AREA.FromSqlRaw("SP_PORTAL_LISTADO_AREA '" + empresa + "'").ToList();

            var Resultado = (from N in area
                             orderby N.AREA
                             select N);

            return Json(Resultado);
        }

        public JsonResult Articulos()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_ARTICULO_RQ> articulo = Comun?.ARTICULO.FromSqlRaw("SP_PORTAL_LISTADO_ARTICULO_RQ '" + empresa + "BDCOMUN'").ToList();

            var Resultado = (from N in articulo
                             orderby N.ARTICULO
                             select new { N.CODIGO, DESCRIPCION = N.ARTICULO.Replace('"', ' '), N.STOCK, N.COD_FAMILIA, N.UNIDAD });

            return Json(Resultado);
        }

        public JsonResult Solicitantes()
        {
            string empresa = HttpContext.Session.GetString("empresa");
            List<SP_PORTAL_LISTADO_SOLICITANTE> solicitante = Comun?.SOLICITANTE.FromSqlRaw("SP_PORTAL_LISTADO_SOLICITANTE '" + empresa + "'").ToList();

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
            List<SP_PORTAL_LISTADO_ORDEN_FABRICACION> orden = Comun?.ORDEN_FABRICACION.FromSqlRaw("SP_PORTAL_LISTADO_ORDEN_FABRICACION '"+empresa+"'").ToList();

            var Resultado = (from N in orden
                             orderby N.ORDEN_FABRICACION
                             select N);

            return Json(Resultado);
        }

        [HttpPost]
        public JsonResult ListadoCompras()
        {
            string empresa = "["+ HttpContext.Session.GetString("empresa").ToString() + "BDCOMUN]";
            //List<REQUISC_PORTAL> compras = Comun.REQUISC_PORTAL.Where(p => p.TIPOREQUI == "RQ").ToList();
            var cadena = "SELECT RC.NROREQUI AS NUMERO,S.TDESCRI AS SOLICITANTE,A.AREA_DESCRIPCION AS AREA,RC.FECREQUI AS FECHA,R.ESTREQUI AS ESTADO ";
            cadena += "FROM " + empresa + ".DBO.REQUISC_PORTAL AS RC ";
            cadena += "LEFT JOIN "+ empresa+".DBO.TABAYU AS S ON S.TCOD = '12' AND S.TCLAVE = RC.CODSOLIC ";
            cadena += "LEFT JOIN " + empresa + ".DBO.AREA AS A ON A.AREA_CODIGO = RC.AREA ";
            cadena += "LEFT JOIN " + empresa + ".DBO.REQUISC AS R ON R.TIPOREQUI = RC.TIPOREQUI AND R.NRO_REQUERIMIENTO_PORTAL = RC.NROREQUI ";
            cadena += "WHERE RC.TIPOREQUI='RQ' ORDER BY RC.NROREQUI";
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
            List<REQUISD_PORTAL> detalle = Comun?.REQUISD_PORTAL.Where(p => p.NROREQUI == codigo && p.TIPOREQUI == "RQ").ToList();

            var Resultado = (from N in detalle
                             orderby N.REQITEM
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
            List<REQUISC_PORTAL> compras = Comun.REQUISC_PORTAL.Where(p => p.TIPOREQUI == "RQ" && p.NROREQUI == codigo).ToList();

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
        // GET: Compras
        [Authorize]
        public IActionResult Index()
        {
            RehacerConexion();
            JsonResult compras = ListadoCompras();
            /*JsonResult areas = Areas();
            JsonResult articulos = Articulos();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            HttpContext.Session.SetObjectAsJson("areas", areas);
            HttpContext.Session.SetObjectAsJson("articulos", articulos);
            HttpContext.Session.SetObjectAsJson("solicitantes", solicitantes);
            HttpContext.Session.SetObjectAsJson("centro", centro);
            HttpContext.Session.SetObjectAsJson("orden", orden);*/

            ViewBag.ListadoCompras = compras;
            ViewBag.ACompras = "activo";
            ViewBag.SessionUsuario = TempData["USU_NOMBRE"];

            return View();
        }

        // GET: Compras/Create
        [Authorize]
        public IActionResult Create()
        {
            RehacerConexion();
            ViewBag.ACompras = "activo";

            JsonResult areas = Areas();
            JsonResult articulos = Articulos();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Articulos = articulos;
            ViewBag.CentroCosto = centro;
            ViewBag.OrdenFabricacion = orden;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string detalle, [Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento,COD_USUARIO")] REQUISC_PORTAL modelo)
        {
            RehacerConexion();
            if (ModelState.IsValid)
            {
                try
                {
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    modelo.NROREQUI = modelo.NROREQUI.Trim();
                    //modelo.FECREQUI = Convert.ToDateTime(modelo.FECREQUI + " " + hora);
                    Comun.REQUISC_PORTAL.Add(modelo);
                    Comun.SaveChanges();

                    JArray ArrayDetalle = JArray.Parse(detalle);
                    int i = 0;
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
                        ModeloDetalle.GLOSA = item.GetValue("glosa_articulo").ToString();
                        ModeloDetalle.REQITEM = i;
                        ModeloDetalle.SALDO = Convert.ToDecimal(item.GetValue("cantidad"));
                        ModeloDetalle.REMAQ = item.GetValue("nro_maquina").ToString();
                        ModeloDetalle.TIPOREQUI = modelo.TIPOREQUI;
                        ModeloDetalle.LISTO_CARGAR = true;
                        ModeloDetalle.ESTADO = false;

                        Comun.REQUISD_PORTAL.Add(ModeloDetalle);
                        //await Comun.SaveChangesAsync();
                        Comun.SaveChanges();
                    }                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewBag.Error = "Error al grabar";
                    return View();
                }

                return RedirectToAction(nameof(Index));
            } 

            ViewBag.ACompras = "activo";
            JsonResult areas = Areas();
            JsonResult articulos = Articulos();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Articulos = articulos;
            ViewBag.CentroCosto = centro;
            ViewBag.OrdenFabricacion = orden;

            return View();
        }

        // GET: Test/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string codigo)
        {
            ViewBag.ACompras = "activo";
            RehacerConexion();
            if (codigo == null)
            {
                return NotFound();
            }
            RehacerConexion();
            var modelo = await Comun.REQUISC_PORTAL.FindAsync(codigo, "RQ");
            if (modelo == null)
            {
                return NotFound();
            }

            JsonResult areas = Areas();
            JsonResult articulos = Articulos();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Articulos = articulos;
            ViewBag.CentroCosto = centro;
            ViewBag.OrdenFabricacion = orden;

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string detalle, [Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento,COD_USUARIO")] REQUISC_PORTAL modelo)
        {
            RehacerConexion();
            if (ModelState.IsValid)
            {
                try
                {
                    Comun.Database.ExecuteSqlRaw("DELETE FROM REQUISD_PORTAL WHERE NROREQUI=" + modelo.NROREQUI);
                    string hora = DateTime.Now.ToString("hh:mm:ss");
                    Comun.REQUISC_PORTAL.Update(modelo);
                    Comun.SaveChanges();

                    JArray ArrayDetalle = JArray.Parse(detalle);
                    int i = 0;
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
                        ModeloDetalle.GLOSA = item.GetValue("glosa_articulo").ToString();
                        ModeloDetalle.REQITEM = i;
                        ModeloDetalle.SALDO = Convert.ToDecimal(item.GetValue("cantidad"));
                        ModeloDetalle.REMAQ = item.GetValue("nro_maquina").ToString();
                        ModeloDetalle.TIPOREQUI = modelo.TIPOREQUI;
                        ModeloDetalle.LISTO_CARGAR = true;
                        ModeloDetalle.ESTADO = false;

                        Comun.REQUISD_PORTAL.Add(ModeloDetalle);
                        Comun.SaveChanges();
                    }                    
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return View(modelo);
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ACompras = "activo";
            JsonResult areas = Areas();
            JsonResult articulos = Articulos();
            JsonResult solicitantes = Solicitantes();
            JsonResult centro = CentroCosto();
            JsonResult orden = OrdenFabricacion();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Articulos = articulos;
            ViewBag.CentroCosto = centro;
            ViewBag.OrdenFabricacion = orden;

            return View(modelo);
        }

        [Authorize]
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
                Comun.Database.ExecuteSqlRaw("DELETE FROM REQUISD_PORTAL WHERE NROREQUI="+id);

                //ESTA FORMA DA ERROR A MULTIPLES DELETE
                //Comun.REQUISD_PORTAL.RemoveRange(Comun.REQUISD_PORTAL.Where(s => s.NROREQUI == id));
                //Comun.REQUISD_PORTAL.Remove(Comun.REQUISD_PORTAL.Find(id));
                //Comun.REQUISD_PORTAL.Where(p => p.NROREQUI == id).ToList().ForEach(p => Comun.REQUISD_PORTAL.Remove(p));
                //Comun.SaveChanges();
                //LA FORMA POR ENTITY ES RECORRER EL LISTADO E IR BORRANDO LINEA A LINEA

                Comun.REQUISC_PORTAL.Remove(Comun.REQUISC_PORTAL.Find(id,"RQ"));
                Comun.SaveChanges();

                jsonData = new
                {
                    resultado = true,
                    error = "",
                };

            }  catch (Exception ex) {
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
