using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using practice_02.Middlewares;
using practice_02.Services;

namespace practice_02
{
    public class Startup
    {
        IServiceCollection _services;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGenerator, RandomGenerator>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<RandomGenenratorMiddleware>();
        }
    }
}
