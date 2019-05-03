using Cronos.Infra.Contexto;
using Cronos.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Cronos.Infra.Repositorio;
using WebSockets.ws;
using WebSockets.ws.Servico;
using WebSockets.ws.Interfaces;

namespace Cronos.Api
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

            string connectString = "Data Source=127.0.0.1;Initial Catalog=cronos.db;User ID=root;Password=";
            services.AddDbContext<DbContexto>(options => options.UseMySql(connectString));

            //injecao de dependencias 
            services.RegistreService();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors();
            // services.AddAuthenticationCore();
            //services.AddScoped<Cronos.Domain.Interfaces.Repositorio.ILivroRepositorio ,Cronos.Infra.NHibernate.Repositorio.LivroRepositorio>();

            services.AddScoped<IWebSocketServico, _WebSocketServico>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => 
                builder.WithOrigins("http://127.0.0.1", "http://127.0.0.1:8080", "http://localhost")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
           );

            app.UseHsts();
            //app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseMvc();

           app.WebSocketsConfigureStartup();

        }
    }
}
