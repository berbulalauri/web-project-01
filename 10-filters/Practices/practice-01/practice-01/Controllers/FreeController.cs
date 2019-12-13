using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practice_01.Filters;
using practice_01.Models;

namespace practice_01.Controllers
{
    public class FreeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FreeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("/Free")]
        [Route("/Free/Index")]
        public IActionResult Index()
        {
            return View("FreeIndexPage");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
