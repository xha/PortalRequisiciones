using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Datos.Models;

namespace Inicio.Controllers
{
    public class ComprasController : Controller
    {
        private readonly BDWENCO Wenco;
        private readonly BDCOMUN Comun;
        public REQUISC_PORTALModel Modelo = new REQUISC_PORTALModel();

        public ComprasController(BDCOMUN context, BDWENCO context2)
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
        public JsonResult ListadoCompras()
        {
            List<REQUISC_PORTALModel> compras = Comun.REQUISC_PORTAL.ToList();

            var Resultado = (from N in compras
                             where N.TIPOREQUI.Contains("RQ".ToString())
                             orderby N.FECREQUI
                             select N);

            return Json(Resultado);
        }
        /********************************************************************************************************************************************/

        // GET: Compras
        public ActionResult Index()
        {
            JsonResult compras = ListadoCompras();
            ViewBag.ListadoCompras = compras;
            ViewBag.ACompras = "activo";

            return View();
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
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
        public async Task<IActionResult> Edit(string codigo)
        {
            ViewBag.ACompras = "activo";
            if (codigo == null)
            {
                return NotFound();
            }

            var modelo = await Comun.REQUISC_PORTAL.FindAsync(codigo);
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
    }
}
