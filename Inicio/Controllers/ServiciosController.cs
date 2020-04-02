using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Datos.Models;
using Microsoft.AspNetCore.Http;

namespace Inicio.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly BDWENCO Wenco;
        private readonly BDCOMUN Comun;
        public REQUISC_PORTAL Modelo = new REQUISC_PORTAL();

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

        public JsonResult Articulos()
        {
            List<SP_PORTAL_LISTADO_ARTICULO_RQ> articulo = Comun?.ARTICULO.FromSqlRaw("SP_PORTAL_LISTADO_ARTICULO_RQ '003BDCOMUN'").ToList();

            var Resultado = (from N in articulo
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
            List<REQUISC_PORTAL> compras = Comun.REQUISC_PORTAL.ToList();

            var Resultado = (from N in compras
                             where N.TIPOREQUI.Contains("RS".ToString())
                             orderby N.FECREQUI
                             select N);

            return Json(Resultado);
        }
        /********************************************************************************************************************************************/

        // GET: Servicios
        public ActionResult Index()
        {
            JsonResult servicios = ListadoServicios();
            ViewBag.ListadoServicios = servicios;
            ViewBag.AServicios = "activo";
            return View();
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.AServicios = "activo";
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

        // POST: Servicios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Servicios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            ViewBag.AServicios = "activo";
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Servicios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}