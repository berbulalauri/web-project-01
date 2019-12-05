using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace tutorial_03
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapWhen(context => context.Request.Query.FirstOrDefault(q => q.Key == "name").Value == "user", SecretPage);
            app.Map("/contact", Contact);
            app.Map("", Home);
        }
        private static void Home(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1 style=\"font-family:verdana; \">Welcome to Home page</h1>");
            });
        }
        private static void Contact(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1 style=\"font-family:verdana; \">Contact Us</h1>");
            });
        }
        private static void SecretPage(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1 style=\"font-family:verdana; color:red;\">Secret Page</h1>");
            });
        }
    }
}
