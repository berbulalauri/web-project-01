using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Middlewares
{
    public class RoutingMiddleware
    {
        public static double paramInt;
        Dictionary<string, string> _routes = new Dictionary<string, string>
        {
            {"/", "<h1>Payment Page! </h1>" },
            {"error","<h1> Payment is not valid. It should be type of number and greater than 0.01 </h1>" },
        };
        RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var secondParam = context.Request.Query.FirstOrDefault(x => x.Key == "payment").Value;
            double.TryParse(secondParam, out paramInt);

            string path = context.Request.Path.Value;
            if (_routes.Keys.Contains(path) && paramInt > 0)
            {
                await context.Response.WriteAsync($"{_routes[path]} <h1>value is: {paramInt}</h1>");
            } else if (_routes.Keys.Contains(path) && paramInt <= 0)
            {
                await context.Response.WriteAsync(_routes["error"]);
            }
            throw new PageNotFoundException();
        }
    }
}
