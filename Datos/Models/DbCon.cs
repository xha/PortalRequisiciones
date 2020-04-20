using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null))
                optionsBuilder.UseSqlServer(@"...");

            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<USUARIO_COMP>()
                .HasNoKey();
        }

        public DbSet<SP_PORTAL_LISTADO_CENTROCOSTO_COMP> CENTRO_COSTO { get; set; }
        public DbSet<SP_PORTAL_LISTADO_AREA> AREA { get; set; }
        public DbSet<SP_PORTAL_LISTADO_ARTICULO_RQ> ARTICULO { get; set; }
        public DbSet<SP_PORTAL_LISTADO_ARTICULO_RQ_POR_ALMACEN> ARTICULOALM { get; set; }
        public DbSet<SP_PORTAL_LISTADO_SOLICITANTE> SOLICITANTE { get; set; }
        public DbSet<SP_PORTAL_LISTADO_ORDEN_FABRICACION> ORDEN_FABRICACION { get; set; }
        public DbSet<USUARIO_COMP> UsuarioModel { get; set; }
        public DbSet<SP_PORTAL_ESTADO_REQUISICION> SP_ESTADO { get; set; }
    }

    public class BDCOMUN : DbContext
    {
        public BDCOMUN(DbContextOptions<BDCOMUN> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<REQUISC_PORTAL>()
                .HasKey(t => new {
                    t.NROREQUI,
                    t.TIPOREQUI,
                });

            modelBuilder.Entity<REQUISD_PORTAL>()
                .HasKey(t => new {
                    t.NROREQUI,
                    t.REQITEM,
                    t.TIPOREQUI,
                });

            modelBuilder.Entity<OBS_PORTAL_RQ>()
                .HasKey(t => new {
                    t.TIPO_RQ,
                    t.NRO_RQ,
                });
        }

        public DbSet<REQUISC_PORTAL> REQUISC_PORTAL { get; set; }
        public DbSet<REQUISC> REQUISC { get; set; }
        public DbSet<REQUISD_PORTAL> REQUISD_PORTAL { get; set; }
        public DbSet<OBS_PORTAL_RQ> OBS { get; set; }
    }

    public class BDCLIENTE : DbContext
    {
        public BDCLIENTE(DbContextOptions<BDCLIENTE> options) : base(options)
        {

        }

        public DbSet<Clientes> TCliente { get; set; }
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