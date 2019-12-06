using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using practice_01.Middlewares;
using practice_01.Services;

namespace practice_01
{
    public class Startup
    {
        IServiceCollection _services;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITimeService, CurrentTimeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<TimeServiceMiddleware>();
        }
    }
}
