using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace tutorial_01
{
    public class Startup
    {
        IServiceCollection _services;
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(composeServiceListToWrite(_services.FirstOrDefault()));
                });
            });
        }
        string composeServiceListToWrite(ServiceDescriptor services)
        {
            var sb = new StringBuilder();

            sb.Append($"{services.ServiceType.Name}")
                .Append(Environment.NewLine);

            sb.Append($"{services.ServiceType.GUID}")
                .Append(Environment.NewLine);

            sb.Append($"{services.ServiceType.Assembly.ManifestModule.Name}")
                .Append(Environment.NewLine);

            //string delimiter = " | ";
            //foreach (var s in services)
            //{
            //    sb.Append(s.ServiceType)
            //        .Append(delimiter)
            //        .Append(s.Lifetime.ToString())
            //        .Append(delimiter)
            //        .Append(s.ToString())
            //        .Append(Environment.NewLine);
            //}

            return sb.ToString();
        }

    }
}
