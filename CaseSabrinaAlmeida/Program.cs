using CaseSabrinaAlmeida;
using CaseSabrinaAlmeida.Controllers;
using CaseSabrinaAlmeida.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace CaseSabrinaAlmeida
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"Iniciando aplicação...");
            try
            {
                IHostBuilder host = Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.ConfigureKestrel(kestrelOptions =>
                     {
                         kestrelOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(120);
                     }
                     );
                     webBuilder.UseStartup<Startup>();
                 });

                host.Build().Run();
               
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}










