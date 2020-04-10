using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Datos.Models
{
    [Table("USUARIO_COMP")]
    public class USUARIO_COMP
    {
        [Required]
        [Display(Name = "Usuario")]
        public string USU_CODIGO { get; set; }
        [Required]
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        public string USU_PASSWORD { get; set; }
        [Display(Name = "Empresa")]
        public string EMP_CODIGO { get; set; }
        public string USU_NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public string CARGO { get; set; }
        public string USU_NIVEL { get; set; }
        public string ARCHIVO_FIRMA { get; set; }
        public string NOMBRE_ARCHIVO { get; set; }
        public string COD_AUDITORIA { get; set; }
        public DateTime? USU_FEC_CREA { get; set; }
        public DateTime? USU_FEC_INACTIVO { get; set; }

        public bool? USU_ESTADO { get; set; }
        public bool? FLGPORTAL_APROB { get; set; }
        public bool? FLGPORTAL_COMPRAS { get; set; }
        public bool? DIGITALIZA_FIRMA { get; set; }        

        public int Asc(string cadena)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(cadena);
            return bytes[0];
        }

        public String DECODIFICA(String cadena, int valor)
        {
            int ciclo, posic, val_n, val_an;
            String carac, CAD;

            cadena = cadena.Trim();
            CAD = "";
            val_n = 0; val_an = 0;
            for (ciclo = 1; ciclo <= cadena.Length; ciclo++)
            {
                carac = cadena.Substring(ciclo - 1, 1);
                posic = ciclo % 7;
                switch (posic)
                {
                    case 0:
                        val_n = Asc(carac) / 2;
                        break;
                    case 1:
                        val_n = Asc(carac) + valor;
                        break;
                    case 2:
                        val_n = Asc(carac) + (ciclo * 2);
                        val_an = Asc(carac);
                        break;
                    case 3:
                        if (val_an > 10)
                            val_an = val_an - (Convert.ToInt32(val_an / 10) * 10);
                        val_n = Asc(carac) + valor - val_an;
                        break;
                    case 4:
                        val_n = Asc(carac) + ciclo;
                        break;
                    case 5:
                        if (val_an > 10)
                            val_an = val_an - (Convert.ToInt32(val_an / 10) * 10);
                        val_n = Asc(carac) + valor - val_an;
                        break;
                    case 6:
                        val_n = Asc(carac);
                        break;
                }
                CAD = CAD + Convert.ToChar(val_n);
            }
            return CAD.ToUpper();
        }

        public String CODIFICA(String cadena, int valor)
        {
            int ciclo, posic, ult_sal;
            String carac, cadena_cod, CAD;
            posic = 0; ult_sal = 0;
            carac = ""; cadena_cod = ""; CAD = "";
            cadena = cadena.Trim().ToUpper();
            for (ciclo = 1; ciclo <= cadena.Length; ciclo++)
            {

                carac = cadena.Substring(ciclo - 1, 1);
                if (ciclo % 2 == 0)
                {
                    carac = carac.ToUpper();
                }
                else
                {
                    carac = carac.ToLower();
                }
                cadena_cod = cadena_cod + carac;
            }
            for (ciclo = 1; ciclo <= cadena_cod.Length; ciclo++)
            {
                posic = ciclo % 7;
                carac = cadena_cod.Substring(ciclo - 1, 1);
                switch (posic)
                {
                    case 0:
                        carac = Convert.ToChar(Asc(carac) * 2).ToString();
                        break;
                    case 1:
                        carac = Convert.ToChar(Asc(carac) - valor).ToString();
                        break;
                    case 2:
                        carac = Convert.ToChar(Asc(carac) - (ciclo * 2)).ToString();
                        ult_sal = Asc(carac);
                        break;
                    case 3:
                        if (ult_sal > 10)
                            ult_sal = ult_sal - (Convert.ToInt32(ult_sal / 10) * 10);
                        carac = Convert.ToChar(Asc(carac) - valor + ult_sal).ToString();
                        break;
                    case 4:
                        carac = Convert.ToChar(Asc(carac) - ciclo).ToString();
                        break;
                    case 5:
                        if (ult_sal > 10)
                            ult_sal = ult_sal - (Convert.ToInt32(ult_sal / 10) * 10);
                        carac = Convert.ToChar(Asc(carac) - valor + ult_sal).ToString();
                        break;
                }
                CAD = CAD + carac;
            }
            return CAD;
        }

        public string Encriptar(string input)
        {
            byte[] iv = ASCIIEncoding.ASCII.GetBytes("qualityi");
            byte[] encryptionKey = Convert.FromBase64String("rpadftlyhorfdertghyujki8765rgyhj");
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = encryptionKey;
            des.IV = iv;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        public string Desencriptar(string input)
        {
            try
            {
                byte[] iv = ASCIIEncoding.ASCII.GetBytes("qualityi");
                byte[] encryptionKey = Convert.FromBase64String("rpadftlyhorfdertghyujki8765rgyhj");
                byte[] buffer = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                des.Key = encryptionKey;
                des.IV = iv;
                return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception)
            {
                return input;
            }
        }

        public bool ConsultarLicencia(string ruta, string ruc, string modulo)
        {
            HttpClient client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri("https://www.starsoftweb.com/ServicioLicenciaPortales/Api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _CREDENCIALES);
            HttpResponseMessage respuesta = new HttpResponseMessage();

            JObject cadena = new JObject();
            cadena.Add(new JProperty("ruc", ruc));
            cadena.Add(new JProperty("modulo", modulo));

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cadena), Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress + ruta, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                if (data.Contains("IsSuccess\":true"))
                {
                    DateTime Hoy = DateTime.Today;
                    dynamic Listado = JsonConvert.DeserializeObject(data);

                    string[] arreglo_fecha = Listado.fechaVigencia.ToString().Split(' ');

                    DateTime fechaVigencia = Convert.ToDateTime(arreglo_fecha[0] + ' ' + arreglo_fecha[1]);

                    if (fechaVigencia > Hoy)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
