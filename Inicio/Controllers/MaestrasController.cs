using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Inicio.Controllers
{
    public class MaestrasController : Controller
    {

        //private readonly BDWENCO Wenco;
        public readonly BDCOMUN Comun;

        public MaestrasController(BDCOMUN context)
        {
            Comun = context;
        }

        public JsonResult Areas()
        {
            List<SP_PORTAL_LISTADO_AREA> area = Comun?.AREA.FromSqlRaw("SP_PORTAL_LISTADO_AREA '003'").ToList();

            return Json(area);
        }

        public JsonResult Articulos()
        {
            List<SP_PORTAL_LISTADO_ARTICULO_RQ> articulo = Comun?.ARTICULO.FromSqlRaw(" exec SP_PORTAL_LISTADO_ARTICULO_RQ '003BDCOMUN'").ToList();

            return Json(articulo);
        }
    }
}