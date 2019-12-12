using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tutorial_02.Filters
{
    public class PreventIEFilter : IResourceFilter
    {
        private string _browserNonGran = "Edge";
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

            var userAgent = context.HttpContext.Request.Headers.FirstOrDefault(h=> h.Key =="User-Agent").Value;
            if (!string.IsNullOrWhiteSpace(userAgent) && new Regex(_browserNonGran).IsMatch(userAgent))
            {
                context.Result = new ContentResult { Content = $"Switch Brawser Please" };
                //context.Result = new ViewResult
                //{ 
                //ViewName = "Error"
                //};

            }
        }
    }
}
