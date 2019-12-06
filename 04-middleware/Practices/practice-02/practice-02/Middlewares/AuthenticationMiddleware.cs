using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Middlewares
{
    public class AuthenticationMiddleware
    {
        private const string firstParam = "payment";
        RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var secondParam = context.Request.Query.FirstOrDefault(x => x.Key == firstParam).Value;
            bool isParamInt = double.TryParse(secondParam, out double paramInt);

            if (isParamInt)
            {
                await _next.Invoke(context);
            }
            throw new AccessDeniedExcepiton();
        }
    }
}
