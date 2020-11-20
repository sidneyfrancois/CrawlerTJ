using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace dotnet_rpg
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnet_rpg", Version = "v1" });
            });

            services.AddScoped<IProcessoService, ProcessoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnet_rpg v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void Crawler()
        {
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            wc.Encoding = Encoding.UTF8;

            string numeroProcesso = "0809979-67.2015.8.05.0080";


            string pagina = wc.DownloadString("http://esaj.tjba.jus.br/cpo/sg/search.do;jsessionid=82BCEACF52467D352D912CC6929C3AAA.cposg3?paginaConsulta=1&cbPesquisa=NUMPROC&tipoNuProcesso=SAJ&numeroDigitoAnoUnificado=&foroNumeroUnificado=&dePesquisaNuUnificado=&dePesquisa=" + numeroProcesso);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(pagina);

            HtmlNode[] nodesTabelaProcesso = htmlDocument.DocumentNode.SelectNodes("//tr").ToArray();

            Processo novo_processo = new Processo();
            novo_processo.numeroProcesso = numeroProcesso;

            novo_processo.classe = nodesTabelaProcesso[25].InnerText;
            string area = (nodesTabelaProcesso[27].InnerText);
            novo_processo.area = area.Substring(area.IndexOf(':') +1);
            novo_processo.assunto = nodesTabelaProcesso[28].InnerText;
            novo_processo.origem = nodesTabelaProcesso[29].InnerText;

        }
    }
}
