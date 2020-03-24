using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Inicio.Controllers
{
    public class ComprasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListadoCompras()
        {

            return null;
        }
    }
}