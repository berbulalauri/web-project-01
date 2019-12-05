using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace practice_01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/home/dog", Dog);
            app.Map("/home/cat", Cat);
            app.Map("", Home);
            //app.MapWhen(context => context.Request.Query.FirstOrDefault(q => q.Key == "name").Value == "user", SecretPage);
        }
        private static void Home(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1 style=\"color: red; font-family:verdana; \">Animal Not Found</h1>");
            });
        }
        private static void Dog(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1 style=\"color: blue; font-family:verdana; \">It is A dog</h1>");
            });
        }
        private static void Cat(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1 style=\"color: blue; font-family:verdana; \">It is A Cat</h1>");
            });
        }
    }
}
