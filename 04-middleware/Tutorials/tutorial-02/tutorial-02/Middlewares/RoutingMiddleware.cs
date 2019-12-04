using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Enums;

namespace tutorial_01.Middlewares
{
    public class RoutingMiddleware
    {
        Dictionary<string, string> _routes = new Dictionary<string, string>
        {
            {"/index","<h1>Home Page</h1>" },
            {"/secret","<h1>Secret open</h1>" }
        };
        RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value;
            if (_routes.Keys.Contains(path))
            {
                await context.Response.WriteAsync(_routes[path]);
            }
            throw new PageNotFoundException();
            //await _next.Invoke(context);
        }
    }
}
