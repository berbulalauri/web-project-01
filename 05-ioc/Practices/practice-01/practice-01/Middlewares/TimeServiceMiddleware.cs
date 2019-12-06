using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice_01.Services;

namespace practice_01.Middlewares
{
    public class TimeServiceMiddleware
    {
        RequestDelegate _next;
        public TimeServiceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITimeService TimeService)
        {
            var sb = new StringBuilder();
            sb.Append("--------Current Time--------").Append(Environment.NewLine);
            sb.Append(TimeService.GetTime());
            var result = sb.ToString();
            await context.Response.WriteAsync(result);

        }
    }
}

//foreach (var item in brandService.GetTime())
//{
//    sb.Append(item.Hour)
//      .Append(item.Minute)
//      .Append(item.Second)
//      .Append(Environment.NewLine);
//}
