using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace dotnet_rpg
{
    public class Program
    {
        public static object context { get; private set; }
        public static void Main(string[] args)
        {
            CriarBancoDeDados();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void CriarBancoDeDados()
        {
            using(var context = new ProcessoContext())
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }
    }
}
