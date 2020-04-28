using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Datos.Models;
using Inicio.Services;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Inicio.Controllers
{
    public class AccountController : Controller
    {
        private readonly BDCLIENTE Client;
        //private BDWENCO Wenco;
        public Login Modelo = new Login();

        //public USUARIO_COMP Modelo = new USUARIO_COMP();
        //public REQUISD_PORTAL ModeloDetalle = new REQUISD_PORTAL();

        public AccountController(BDCLIENTE context2)
        {
            Client = context2;
        }

        //public string SessionNombre { get; private set; }

        /*public static void SetAppSettingValue(string key, string value, string appSettingsJsonFilePath = null)
        {
            if (appSettingsJsonFilePath == null)
            {
                appSettingsJsonFilePath = System.IO.Path.Combine(System.AppContext.BaseDirectory, "appsettings.json");
            }

            var json = System.IO.File.ReadAllText(appSettingsJsonFilePath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(json);

            jsonObj[key] = value;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.WriteAllText(appSettingsJsonFilePath, output);
        }*/

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login userModel)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            USUARIO_COMP Modelo = new USUARIO_COMP();

            string clave = Modelo.CODIFICA(userModel.CLAVE,5);
            string clave2 = Modelo.DECODIFICA(userModel.CLAVE, 5);
            string ruc_encrip = Modelo.Encriptar(userModel.RUC);

            List<Clientes> rs_cliente = Client.TCliente.Where(i => i.RUC_Cliente == ruc_encrip).ToList();

            if (rs_cliente.Count > 0)
            {
                bool LicenciaValida;
                //LicenciaValida = Modelo.ConsultarLicencia("ValidarLicencia", userModel.RUC.ToString(), "03");
                //OJO
                LicenciaValida = true;
                if (LicenciaValida)
                {
                    int id_cliente          = rs_cliente[0].ID_Clientes_Portales;
                    string servidor         = Modelo.Desencriptar(rs_cliente[0].Servidor);
                    //string Base_datos       = Modelo.Desencriptar(rs_cliente[0].Base_Datos);
                    string Base_datos       = "BDWENCO";
                    string usuario_server   = Modelo.Desencriptar(rs_cliente[0].Usuario_Server);
                    string contrasenia      = Modelo.Desencriptar(rs_cliente[0].Contrasenia_Server);

                    var optionsBuilder = new DbContextOptionsBuilder<BDWENCO>();
                    //services.AddDbContext<BDCOMUN>(options => options.UseSqlServer(Configuration.GetConnectionString("BDCOMUNConnectionString")));
                    string cadena = "Data Source=" + servidor + ";Initial Catalog=" + Base_datos + ";MultipleActiveResultSets=true;User ID=" + usuario_server + ";Password=" + contrasenia + "";
                    optionsBuilder.UseSqlServer(cadena);
                    var Wenco = new BDWENCO(optionsBuilder.Options);

                    //SetAppSettingValue("BDWENCOConnectionString", "Data Source = "+ servidor + "; Initial Catalog = "+ Base_datos + "; MultipleActiveResultSets = true; User ID = "+ usuario_server + "; Password = "+ contrasenia + "");

                    // && i.USU_PASSWORD == clave
                    //List<USUARIO_COMP> user = Wenco?.UsuarioModel.Where(i => i.USU_CODIGO == userModel.CODIGO && i.FLGPORTAL_COMPRAS == true && i.USU_PASSWORD == clave).ToList();
                    List<SP_PORTAL_COMPRAS> user = Wenco?.PORTAL_COMPRAS.FromSqlRaw("SP_PORTAL_COMPRAS '" + userModel.CODIGO.ToUpper() + "','" + clave + "'").ToList();

                    if (user.Count > 0)
                    {
                        /*var Resultado = (from p in user
                                         group p.EMP_CODIGO by p.EMP_CODIGO, p.EMP_NOMBRE by p.EMP_NOMBRE into g
                                         select new { N = g.ToList() });*/

                        string vempresas = "";
                        foreach (var rs in user)
                        {
                            //List<EMPRESA> empre = Wenco?.EMPRESA.FromSqlRaw("SELECT EMP_CODIGO,EMP_RAZON_NOMBRE FROM EMPRESA WHERE EMP_CODIGO='" + empresa + "'").ToList();
                            if (vempresas=="") TempData["USU_EMPRESA"] = rs.EMP_CODIGO;

                            vempresas += rs.EMP_CODIGO + " - "+ rs.EMP_RAZON_NOMBRE + ",";
                        }

                        TempData["Empresas"] = vempresas;
                        //var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                        //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userModel.USU_CODIGO));
                        //identity.AddClaim(new Claim(ClaimTypes.Name, user[0].USU_NOMBRE));
                        JObject datosSesion = new JObject();
                        datosSesion.Add(new JProperty("id_cliente", id_cliente));
                        datosSesion.Add(new JProperty("servidor", rs_cliente[0].Servidor));
                        //datosSesion.Add(new JProperty("Base_datos", rs_cliente[0].Base_Datos));
                        datosSesion.Add(new JProperty("Base_datos", "BDWENCO"));
                        datosSesion.Add(new JProperty("usuario_server", rs_cliente[0].Usuario_Server));
                        datosSesion.Add(new JProperty("contrasenia", rs_cliente[0].Contrasenia_Server));
                        //TempData["USU_EMPRESA"] = "003";

                        TempData.Put<dynamic>("DataServer", datosSesion);
                        TempData["USU_NOMBRE"] = user[0].USU_NOMBRE;
                        TempData["USU_CODIGO"] = userModel.CODIGO;
                        
                        //TempData.Keep();
                        //HttpContext.Session.SetString("SessionNombre", user[0].USU_NOMBRE);

                        var claims = new List<Claim>{
                            new Claim(ClaimTypes.NameIdentifier, userModel.CODIGO),
                            new Claim(ClaimTypes.Name, user[0].USU_NOMBRE),
                            //new Claim(ClaimTypes.Role, user[0].CARGO),
                        };

                        var claimsIdentity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                            IsPersistent = true,
                            //IssuedUtc = <DateTimeOffset>,
                            // The time at which the authentication ticket was issued.
                            RedirectUri = "/Account/Login"
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
                        /*HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                            new ClaimsPrincipal(identity))
                            */
                        return RedirectToAction(nameof(ComprasController.Index), "Compras", new { tipo = "RQ" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Usuario o clave inválida");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Licencia no válida");
                    return View();
                }
            }            
            else
            {
                ModelState.AddModelError("", "RUC No válido");
                return View();
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}