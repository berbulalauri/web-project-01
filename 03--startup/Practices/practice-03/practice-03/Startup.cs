using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace practice_03
{
    public class Startup
    {
        public static StringValues urlParamValue;
        public static int myIntegerValue;
        public static string middleString;
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.MapWhen(context => context.Request.Query.TryGetValue("number", out urlParamValue), SecretPage);
            app.Map("", Home);
        }
        private static void Home(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("<h1 style=\"font-family:verdana; \">Welcome to Home page<br> Multiply on 100 App</h1>");
            });
        }
        public static void SecretPage(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                middleString = Convert.ToString(urlParamValue);
                if (int.TryParse(middleString, out myIntegerValue))
                {
                    await context.Response.WriteAsync($"<h1 style=\"font-family:verdana; color:red;\"> n = {urlParamValue}, {urlParamValue} * 100 = {int.Parse(urlParamValue) * 100}</h1>");
                } else
                {
                    await context.Response.WriteAsync($"<h1 style=\"font-family:verdana; color:red;\"> {urlParamValue} is not Valid number!!!</h1>");
                }

            });
        }
    }
}
