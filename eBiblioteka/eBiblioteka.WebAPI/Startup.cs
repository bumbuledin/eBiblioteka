using eBiblioteka.Model.Requests;
using eBiblioteka.WebAPI.Database;
using eBiblioteka.WebAPI.Filters;
using eBiblioteka.WebAPI.Interfaces;
using eBiblioteka.WebAPI.Security;
using eBiblioteka.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBiblioteka.WebAPI
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
           

            services.AddMvc(x => x.Filters.Add<ErrorFilter>());
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eBiblioteka API", Version = "v1" });

                c.AddSecurityDefinition("BasicAuthentication", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "BasicAuthentication" }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddDbContext<eBibliotekaContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("Biblioteka")));

            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddMvc().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddScoped<IKorisnickiNalog, KoirsnickiNalogService>();
            services.AddScoped<IPreporukaService, PreporukaService>();

            services.AddScoped<ICRUDService<Model.Grad, string, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>, BaseCRUDService<Model.Grad, string, Database.Grad, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>>();
            services.AddScoped<ICRUDService<Model.VrstaUplate, string, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>, BaseCRUDService<Model.VrstaUplate, string, Database.VrstaUplate, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>>();
            services.AddScoped<IUposlenikService, UposlenikService>();
            services.AddScoped<IClanService, ClanService>();
            services.AddScoped<IUplataService, UplataService>();
            services.AddScoped<IService<Model.Uloga, object>, BaseService<Model.Uloga, object, Database.Uloga>>();
            services.AddScoped<ICRUDService<Model.Izdavac, IzdavacSearchRequest, IzdavacUpsertRequest, IzdavacUpsertRequest>, IzdavacService>();
            services.AddScoped<ICRUDService<Model.Autor, AutorSearchRequest, AutorUpsertRequest, AutorUpsertRequest>, AutorService>();
            services.AddScoped<ICRUDService<Model.Kategorija, JednaVarijablaSearchRequest, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>, BaseCRUDService<Model.Kategorija, JednaVarijablaSearchRequest, Database.Kategorija, JednaVarijablaUpsertRequest, JednaVarijablaUpsertRequest>>();
            services.AddScoped<IKnjigaService, KnjigaService>();
            services.AddScoped<ICRUDService<Model.Zaduzenje, ZaduzenjeSearchRequest, ZaduzenjeUpsertRequest, ZaduzenjeUpsertRequest>, ZaduzenjeService>();
            services.AddScoped<ICRUDService<Model.Rezervacija, RezervacijaSearchRequest, RezervacijaUpsertRequest, RezervacijaUpsertRequest>, RezervacijaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eBiblioteka API");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
