using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApplication1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            */
            app.Use(async (context, next) => {
                logger.LogInformation(" Middleware 1: incoming request");
                await context.Response.WriteAsync(" Hello from Middle ware 1");
                await next();
                await context.Response.WriteAsync(" after await next() MW1");
                logger.LogInformation(" Middleware 1: outgoing response");
            });
            app.Use(async (context, next) => {
                logger.LogInformation(" Middle ware 2: incoming request");
                await context.Response.WriteAsync("Hello from Middle ware 2 ");
                await next();
                await context.Response.WriteAsync(" after await next() MW2");
                logger.LogInformation("Middleware 2: outgoing response");
            });
            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                //await context.Response.WriteAsync(env.EnvironmentName);
                //await context.Response.WriteAsync(configuration["MyOwnKey"]);
                await context.Response.WriteAsync(" Hello from Middle ware 3");
                logger.LogInformation("Middle ware 3: Request has been processed");
                await context.Response.WriteAsync(" Hello World!!");
            });






            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseMvc();
        }
    }
}
