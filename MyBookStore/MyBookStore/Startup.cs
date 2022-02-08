using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from first custom middleware");

                await next();

                await context.Response.WriteAsync("Hello from first-second custom middleware");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from second-first custom middleware");

                await next();

                await context.Response.WriteAsync("Hello from second-second custom middleware");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from third-first custom middleware");

                await next();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/dhaval", async context =>
                {
                    await context.Response.WriteAsync("Hello Dhaval!");
                });
            });

            //We can also use Map insted of MapGet 
            //difference is that MapGet can only handle get requests while Map can handle all type of requests

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.Map("/dhaval", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Vikas!");
            //    });
            //});
        }
    }
}
