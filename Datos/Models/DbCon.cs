﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class BDWENCO : DbContext
    {
        public BDWENCO(DbContextOptions<BDWENCO> options) : base(options)
        {

        }

        //public DbSet<UsuarioModel> Usuario { get; set; }

        public string ConexDinamica(string datasour, string catalog, string user, string password)
        {
            string providerName = "System.Data.SqlClient";
            EntityConnectionStringBuilder sqlBuilders = new EntityConnectionStringBuilder();
            sqlBuilders.Provider = providerName;
            sqlBuilders.ProviderConnectionString = "data source=" + datasour + ";initial catalog=" + catalog + ";user id=" + user + ";password=" + password + ";MultipleActiveResultSets=True;App=EntityFramework";
            //sqlBuilders.Metadata = "res://*/ProcedimientosAlmacenados.CModel.csdl|res://*/ProcedimientosAlmacenados.CModel.ssdl|res://*/ProcedimientosAlmacenados.CModel.msl";
            return sqlBuilders.ToString();
        }

        public string ConexFIJA(string datasour, string catalog, string user, string password)
        {
            string providerName = "System.Data.SqlClient";
            EntityConnectionStringBuilder sqlBuilders = new EntityConnectionStringBuilder();
            sqlBuilders.Provider = providerName;
            sqlBuilders.ProviderConnectionString = "data source=" + datasour + ";initial catalog=" + catalog + ";user id=" + user + ";password=" + password + ";MultipleActiveResultSets=True;App=EntityFramework";
            sqlBuilders.Metadata = "res://*/ProcedimientosAlmacenadosEstaticos.ModeloEstatico.csdl|res://*/ProcedimientosAlmacenadosEstaticos.ModeloEstatico.ssdl|res://*/ProcedimientosAlmacenadosEstaticos.ModeloEstatico.msl";
            return sqlBuilders.ToString();
        }
    }

    public class BDCOMUN : DbContext
    {
        public BDCOMUN(DbContextOptions<BDCOMUN> options) : base(options)
        {

        }

        public DbSet<REQUISC_PORTALModel> REQUISC_PORTAL { get; set; }
    }

        /*public bool ConsultaPost(string ruta, string ruc, string modulo)
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
        }*/
}