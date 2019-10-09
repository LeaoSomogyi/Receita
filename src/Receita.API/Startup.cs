using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Receita.Domain.Infrastructure.Context;
using Receita.Domain.IoC;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

namespace Receita.API
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
            services.AddService();
            services.AddMvc(
                options =>
                {
                    options.RespectBrowserAcceptHeader = true;
                }

                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ReceitaContext>(options =>
            {
                options.UseSqlServer(Configuration["AppSettings:ConnectionString"]);
            });

            services.AddCors(x => x.AddPolicy("default",
                b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddAuthentication(

                o =>
                {
                    o.DefaultAuthenticateScheme = "Jwt";
                    o.DefaultChallengeScheme = "Jwt";

                }).AddJwtBearer("Jwt", o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Minha chave com pelo menos 16 cara")),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5),


                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseCors(c =>
            {

                c.AllowAnyHeader();
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
            });
            app.UseHttpsRedirection();
            app.UseMvc(
            routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
