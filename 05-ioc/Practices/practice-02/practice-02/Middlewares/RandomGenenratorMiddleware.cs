using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice_02.Services;

namespace practice_02.Middlewares
{
    public class RandomGenenratorMiddleware
    {
        RequestDelegate _next;
        public RandomGenenratorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IGenerator brandService)
        {
            var sb = new StringBuilder();
            
            var secondParam = context.Request.Query.FirstOrDefault(x => x.Key == "select").Value;
            int.TryParse(secondParam, out int paramInt);

                if (paramInt == 1)
                    {
                    sb.Append("Random String: " + brandService.GenerateString(8));
                    }
                     else if (paramInt == 2)
                    {
                    sb.Append("Negative Number: " + brandService.GenerateNegativeIntegerNumber());
                    } else if (paramInt == 3)
                    {
                    sb.Append("Positive Number: " + brandService.GeneratePositiveIntegerNumber());
                    }
            var result = sb.ToString();
            string menuString = $"<br><h1 style='color:blue'>{result}</h1><h1>Menu</h1><h1>1. Random String</h1><h1>2. Negative Number</h1><h1>3. Positive Number</h1>";
            await context.Response.WriteAsync(menuString);
        }
    }
}
