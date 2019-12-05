using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace practice_02
{
    public class Startup
    {
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Map("", Home);
        }
        private static void Home(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<div class=\"container\"><table style=\"margin-left:1%; margin-top:1%; border: 1px solid black;\" class=\"table\"><thead><tr><th>Name</th><th>Author</th><th>Release Year</th></tr></thead><tbody><tr><td>William Shekespaere</td><td>Romeo And Juliet</td><td>1597</td></tr><tr class=\"success\"><td>Anton Checkov</td><td>Three sister</td><td>1900</td></tr></tbody></table></div>");
            });
        }

    }
}
