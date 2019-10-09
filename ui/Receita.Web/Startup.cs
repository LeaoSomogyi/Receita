using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using Polly.Extensions.Http;
using Receita.Web.HttpClients;
using Receita.Web.HttpClients.Interfaces;
using System;
using System.Net.Http;

namespace Receita.Web
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
            ConfigureHttpClients(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Receita}/{action=Index}/{id?}");
            });
        }

        private void ConfigureHttpClients(IServiceCollection services) 
        {
            services.AddHttpClient<IReceitaClient, ReceitaClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["ApiUrl"]);

            }).AddPolicyHandler(GetRetryPolicy());
        }

        private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() 
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => 
                {
                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                });
        }
    }
}
