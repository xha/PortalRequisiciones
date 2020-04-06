using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Datos.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;


namespace Inicio.Controllers
{
    public class AccountController : Controller
    {
        private readonly BDWENCO Wenco;
        public USUARIO_COMP Modelo = new USUARIO_COMP();
        public REQUISD_PORTAL ModeloDetalle = new REQUISD_PORTAL();

        public AccountController(BDWENCO context)
        {
            Wenco = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(USUARIO_COMP modelo)
        {
            return View();
        }
    }
}