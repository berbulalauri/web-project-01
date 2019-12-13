using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace practice_01.Filters
{
    public class PreventIEFilter : IActionFilter
    {
        private Stopwatch _stopwatch;

        public PreventIEFilter()
        {
            _stopwatch = new Stopwatch();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //_stopwatch.Restart();
            _stopwatch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var response = httpContext.Response;

            if (filterContext.HttpContext.Request.Path == "/")
            {
                _stopwatch.Stop();
                filterContext.Result = new ContentResult { Content = $"Time elapsed (ms): {(_stopwatch.Elapsed.TotalMilliseconds*10)}" };
            }

        }


    }
}
