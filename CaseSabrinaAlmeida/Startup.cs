using CaseSabrinaAlmeida.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Text.Json;

namespace CaseSabrinaAlmeida
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.ConfigureHttpJsonOptions(options =>
            //{
            //    options.SerializerOptions.TypeInfoResolverChain.Insert(0, ClienteArrayJsonSerializerContext.Default);
            //    options.SerializerOptions.TypeInfoResolverChain.Insert(1, TransferenciaJsonSerializerContext.Default);
            //    options.SerializerOptions.TypeInfoResolverChain.Insert(2, HistoricoTransferenciasJsonSerializerContext.Default);

            //});
            
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.TypeInfoResolverChain.Insert(0, ClienteArrayJsonSerializerContext.Default);
                options.JsonSerializerOptions.TypeInfoResolverChain.Insert(1, TransferenciaJsonSerializerContext.Default);
                options.JsonSerializerOptions.TypeInfoResolverChain.Insert(2, HistoricoTransferenciasJsonSerializerContext.Default);

            });

            // Configure HttpClient
            services.AddHttpClient();
            //services.AddHttpClient<HttpClient>();
            services.AddControllersWithViews();

            //services.AddCors();
            //services.AddDistributedMemoryCache();
            //services.AddRazorPages();
            //services.AddControllersWithViews();
            //services.AddEndpointsApiExplorer();
            //services.AddResponseCompression();
            //services.AddSession();

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    app.UseSession();

        //    app.UseRouting();
        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapRazorPages();
        //        endpoints.MapControllerRoute(
        //            "default", "{controller=Home}/{id?}");
        //    });
        //    app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
        //}




        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

