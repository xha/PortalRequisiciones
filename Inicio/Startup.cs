using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Datos.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Datos.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Inicio.Services;
using System.Net;
using Wkhtmltopdf.NetCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Inicio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            //First register a custom made db context provider
            services.AddTransient<BDCLIENTE>();
            //Then use implementation factory to get the one you need
            services.AddDbContext<BDCLIENTE>(options => options.UseSqlServer(Configuration.GetConnectionString("BDCLIENTEConnectionString")));
            services.AddDbContext<BDWENCO>(options => options.UseSqlServer(Configuration.GetConnectionString("BDWENCOConnectionString")));
            services.AddDbContext<BDCOMUN>(options => options.UseSqlServer(Configuration.GetConnectionString("BDCOMUNConnectionString")));
            //services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));            

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<BDWENCO>();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Home/Index";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
             services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, act => {
                act.LoginPath = "/Account/Login";
                act.LogoutPath = "/Account/Logout";
                act.AccessDeniedPath = "/Home/Index";
                act.SlidingExpiration = true;
                act.ExpireTimeSpan = TimeSpan.FromSeconds(5);
            });

            services.AddDistributedMemoryCache();

            /*services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false; // consent required
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<TestSesion>();*/

            services.AddSession(options =>
            { 
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddWkhtmltopdf("wkhtmltopdf");
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Index");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Fixar Cultura para en-US
            RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new CultureInfo("es-ES") },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo("es-ES") },
                DefaultRequestCulture = new RequestCulture("es-ES")
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            /*app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect("/Account/Login");
            });*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
