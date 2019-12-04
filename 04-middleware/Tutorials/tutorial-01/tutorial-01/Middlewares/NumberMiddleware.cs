using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Enums;

namespace tutorial_01.Middlewares
{
    public class NumberMiddleware
    {

        RequestDelegate _next;
        public NumberMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            int userNumber;
            int.TryParse(context.Request.Query.FirstOrDefault(q => q.Key == "number").Value, out userNumber);
            if (userNumber < 10 && userNumber >= 0)
            {
                var result = ((NumberEnum)userNumber).ToString();
                Debug.WriteLine(result);

            }

            await _next.Invoke(context);
        }
    }
}
