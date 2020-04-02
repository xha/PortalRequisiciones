using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Datos.Models;
using Newtonsoft.Json.Linq;

namespace Inicio.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly BDWENCO Wenco;
        private readonly BDCOMUN Comun;
        public REQUISC_PORTAL Modelo = new REQUISC_PORTAL();
        public REQUISD_PORTAL ModeloDetalle = new REQUISD_PORTAL();

        public ServiciosController(BDCOMUN context, BDWENCO context2)
        {
            Comun = context;
            Wenco = context2;
        }

        /********************************************************************************************************************************************/
        //LLAMADOS JSON
        public JsonResult Areas()
        {
            List<SP_PORTAL_LISTADO_AREA> area = Comun?.AREA.FromSqlRaw("SP_PORTAL_LISTADO_AREA '003'").ToList();

            var Resultado = (from N in area
                             orderby N.AREA
                             select N);

            return Json(Resultado);
        }

        public JsonResult Servicios()
        {
            List<SP_PORTAL_LISTADO_ARTICULO_RQ> servicio = Comun?.ARTICULO.FromSqlRaw("SP_PORTAL_LISTADO_ARTICULO_RQ '003BDCOMUN'").ToList();

            var Resultado = (from N in servicio
                             orderby N.ARTICULO
                             select new { N.CODIGO, DESCRIPCION = N.ARTICULO.Replace('"', ' '), N.STOCK, N.COD_FAMILIA, N.UNIDAD });

            return Json(Resultado);
        }

        public JsonResult Solicitantes()
        {
            List<SP_PORTAL_LISTADO_SOLICITANTE> solicitante = Comun?.SOLICITANTE.FromSqlRaw("SP_PORTAL_LISTADO_SOLICITANTE '003'").ToList();

            var Resultado = (from N in solicitante
                             orderby N.SOLICITANTE
                             select N);

            return Json(Resultado);
        }

        public JsonResult CentroCosto()
        {
            List<SP_PORTAL_LISTADO_CENTROCOSTO_COMP> centro_costo = Wenco?.CENTRO_COSTO.FromSqlRaw("SP_PORTAL_LISTADO_CENTROCOSTO_COMP '003'").ToList();

            var Resultado = (from N in centro_costo
                             orderby N.CENTRO_COSTO
                             select N);

            return Json(Resultado);
        }

        public JsonResult OrdenFabricacion()
        {
            List<SP_PORTAL_LISTADO_ORDEN_FABRICACION> orden = Comun?.ORDEN_FABRICACION.FromSqlRaw("SP_PORTAL_LISTADO_ORDEN_FABRICACION '003'").ToList();

            var Resultado = (from N in orden
                             orderby N.ORDEN_FABRICACION
                             select N);

            return Json(Resultado);
        }

        [HttpPost]
        public JsonResult ListadoServicios()
        {
            List<REQUISC_PORTAL> Servicios = Comun?.REQUISC_PORTAL.Where(p => p.TIPOREQUI == "RS").ToList();

            var Resultado = (from N in Servicios
                             orderby N.FECREQUI
                             select N);

            return Json(Resultado);
        }

        [HttpPost]
        public JsonResult ListadoDetalle(string codigo)
        {
            List<REQUISD_PORTAL> detalle = Comun?.REQUISD_PORTAL.Where(p => p.NROREQUI == codigo).ToList();

            var Resultado = (from N in detalle
                             orderby N.REQITEM
                             select N);

            return Json(Resultado);
        }
        /********************************************************************************************************************************************/

        // GET: Servicios
        public ActionResult Index()
        {
            JsonResult Servicios = ListadoServicios();
            ViewBag.ListadoServicios = Servicios;
            ViewBag.AServicios = "activo";

            return View();
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.AServicios = "activo";
            JsonResult areas = Areas();
            JsonResult servicios = Servicios();
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
        public IActionResult Create(string detalle, [Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento")] REQUISC_PORTAL modelo)
        {
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
                        ModeloDetalle.GLOSA = item.GetValue("glosa_servicio").ToString();
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

            ViewBag.AServicios = "activo";
            JsonResult areas = Areas();
            JsonResult servicios = Servicios();
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
            if (codigo == null)
            {
                return NotFound();
            }

            var modelo = await Comun.REQUISC_PORTAL.FindAsync(codigo, "RQ");
            if (modelo == null)
            {
                return NotFound();
            }

            JsonResult areas = Areas();
            JsonResult servicios = Servicios();
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
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string detalle, [Bind("NROREQUI,CODSOLIC,FECREQUI,GLOSA,AREA,TIPOREQUI,TipoDocumento")] REQUISC_PORTAL modelo)
        {
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
                        ModeloDetalle.GLOSA = item.GetValue("glosa_servicio").ToString();
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
                //ESTA ES LA FORMA FACIL
                Comun.Database.ExecuteSqlRaw("DELETE FROM REQUISD_PORTAL WHERE NROREQUI=" + id);

                //ESTA FORMA DA ERROR A MULTIPLES DELETE
                //Comun.REQUISD_PORTAL.RemoveRange(Comun.REQUISD_PORTAL.Where(s => s.NROREQUI == id));
                //Comun.REQUISD_PORTAL.Remove(Comun.REQUISD_PORTAL.Find(id));
                //Comun.REQUISD_PORTAL.Where(p => p.NROREQUI == id).ToList().ForEach(p => Comun.REQUISD_PORTAL.Remove(p));
                //Comun.SaveChanges();
                //LA FORMA POR ENTITY ES RECORRER EL LISTADO E IR BORRANDO LINEA A LINEA

                Comun.REQUISC_PORTAL.Remove(Comun.REQUISC_PORTAL.Find(id, "RQ"));
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
