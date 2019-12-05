using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tutorial_02.Services;

namespace tutorial_02.Middlewares
{
    public class TutorialMiddleware
    {
        RequestDelegate _next;
        public TutorialMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IBrandService brandService)
        {
            var sb = new StringBuilder();
            sb.Append("--------Brand List--------").Append(Environment.NewLine);
            foreach (var item in brandService.GetBrands())
            {
                sb.Append(item.Name).Append(Environment.NewLine);
            }
            var result = sb.ToString();

            await context.Response.WriteAsync(result);

        }
    }
}
