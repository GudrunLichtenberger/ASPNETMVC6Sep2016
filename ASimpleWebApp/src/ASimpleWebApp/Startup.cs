using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ASimpleWebApp.Services;
using ASimpleWebApp.Controllers;
using ASimpleWebApp.Middleware;

namespace ASimpleWebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
            }
            Configuration = builder.Build();
        }


        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISampleService, SampleService>();
            services.AddTransient<SimpleController>();
            services.AddDistributedMemoryCache();
            services.AddSession();

            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            // app.UseH1Middleware();

            app.Map("/session", app1 =>
            {
                app1.Run(async context =>
                {
                    await SessionSample.SessionAsync(context);
                });
            });

            app.Map("/di", app1 =>
            {
                app1.Run(async context =>
                {
                    var controller = Container.GetService<SimpleController>();
                    string result = controller.Action1("action1");
                    await context.Response.WriteAsync(result);
                });
            });
            app.Map("/json", app1 =>
            {
                app1.Run(async context =>
                {
                    string resp = RequestResponseSample.GetJson(context.Response);
                    await context.Response.WriteAsync(resp);
                });
            });

            app.MapWhen(context =>
            {
                return context.Request.Path.Value.Contains("one");
            }, app1 =>
            {
                app1.Run(async context =>
                {
                    string resp = RequestResponseSample.GetForm(context.Request);
                    await context.Response.WriteAsync(resp);
                });
            });

            app.Map("/reqsample", app1 =>
            {
                app1.Run(async context =>
                {
                    await RequestResponseSample.JustReturn(context);
                });
            });

            app.Map("/sample1", app1 =>
            {
                app1.Run(async context =>
                {
                    await context.Response.WriteAsync("<h1>This is Sample1</h1>");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1>Hello World!</h1>");
            });
        }
    }
}
