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
        //private readonly BDWENCO Wenco;
        private readonly BDCOMUN Comun;
        public REQUISC_PORTALModel Modelo = new REQUISC_PORTALModel();

        public ComprasController(BDCOMUN context)
        {
            Comun = context;
        }

        /********************************************************************************************************************************************/
        //LLAMADOS JSON
        public JsonResult Areas()
        {
            List<SP_PORTAL_LISTADO_AREA> area = Comun?.AREA.FromSqlRaw("SP_PORTAL_LISTADO_AREA '003'").ToList();

            return Json(area);
        }

        public JsonResult Articulos()
        {
            List<SP_PORTAL_LISTADO_ARTICULO_RQ> articulo = Comun?.ARTICULO.FromSqlRaw("SP_PORTAL_LISTADO_ARTICULO_RQ '003BDCOMUN'").ToList();

            return Json(articulo);
        }

        public JsonResult Solicitantes()
        {
            List<SP_PORTAL_LISTADO_SOLICITANTE> articulo = Comun?.SOLICITANTE.FromSqlRaw("SP_PORTAL_LISTADO_SOLICITANTE '003'").ToList();

            return Json(articulo);
        }

        [HttpPost]
        public JsonResult ListadoCompras()
        {
            List<REQUISC_PORTALModel> compras = Comun.REQUISC_PORTAL.ToList();

            return Json(compras);
        }
        /********************************************************************************************************************************************/

        // GET: Compras
        public ActionResult Index()
        {
            JsonResult compras = ListadoCompras();
            ViewBag.ListadoCompras = compras;

            return View();
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            JsonResult areas = Areas();
            JsonResult articulos = Articulos();
            JsonResult solicitantes = Solicitantes();
            ViewBag.Solicitantes = solicitantes;
            ViewBag.Areas = areas;
            ViewBag.Articulos = articulos;

            return View();
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(string codigo)
    {
            if (codigo == null)
            {
                return NotFound();
            }

            var modelo = await Comun.REQUISC_PORTAL.FindAsync(codigo);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }
    }
}
