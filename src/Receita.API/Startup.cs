using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Receita.Domain.Infrastructure.Context;
using Receita.Domain.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace Receita.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddService();
            services.AddMvc(
                options =>
                {
                    options.RespectBrowserAcceptHeader = true;
                }

                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };

                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    opt.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    opt.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
                    opt.SerializerSettings.Culture = new System.Globalization.CultureInfo("en-US");
                    opt.SerializerSettings.Formatting = Formatting.None;
                    opt.SerializerSettings.FloatFormatHandling = FloatFormatHandling.DefaultValue;
                    opt.SerializerSettings.FloatParseHandling = FloatParseHandling.Double;
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.TypeNameHandling = TypeNameHandling.None;
                });

            services.AddDbContext<ReceitaContext>(options =>
            {
                options.UseSqlServer(Configuration["AppSettings:ConnectionString"]);
            });

            services.AddCors(x => x.AddPolicy("default",
                b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Receitas", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receitas V1"));

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
