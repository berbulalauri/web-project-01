using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_02.Filters
{
    public class CookieFilter : IActionFilter
    {
        readonly string _lastVisitedKey = "LastVisited";
        public void OnActionExecuted(ActionExecutedContext context)
        {
        context.HttpContext.Response.Cookies.Append(_lastVisitedKey, DateTime.Now.ToString("mm.dd.yyyy-hh.mm.ss"));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Query.ToList().ForEach(
                q=>
                {
                    context.HttpContext.Response.Cookies.Append(q.Key,q.Value);

                }
                );
        }
    }
}
