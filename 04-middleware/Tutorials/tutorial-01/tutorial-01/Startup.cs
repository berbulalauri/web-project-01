using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tutorial_01.Enums;
using tutorial_01.Middlewares;

namespace tutorial_01
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<NumberMiddleware>();
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Number MiddleWare 2");
            });


        }
    }
}
