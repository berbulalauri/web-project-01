using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Middlewares
{
    public class ExceptionHandlingMiddleware
    {

        RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {

            await _next.Invoke(context);
            }
            catch (AccessDeniedExcepiton ex)
            {
                context.Response.StatusCode = 402;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync($"<h1>Page Not Found!</h1>"); //Something Weng Wring. {ex.Message} 
            }

        }
    }
}
