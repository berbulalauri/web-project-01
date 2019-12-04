using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Enums;

namespace tutorial_01.Middlewares
{
    public class AuthenticationMiddleware
    {
        private const string _tokenkey = "token";
        private const string _tokenValue = "2b74aca4-b3b9-454e-94d5-5f07eb3327fb";
        RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.FirstOrDefault(x => x.Key == _tokenkey).Value == _tokenValue)
            {
                await _next.Invoke(context);
            }
            throw new AccessDeniedExcepiton();
        }
    }
}
