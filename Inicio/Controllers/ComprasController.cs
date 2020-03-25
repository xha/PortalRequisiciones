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

        public ComprasController(BDCOMUN context)
        {
            Comun = context;
        }

        // GET: Compras
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ListadoCompras()
        {
            List<REQUISC_PORTALModel> compras = Comun.REQUISC_PORTAL.ToList();

            var Resultado = (from N in compras 
                             select N   );
            return Json(Resultado);
        }
    }
}
