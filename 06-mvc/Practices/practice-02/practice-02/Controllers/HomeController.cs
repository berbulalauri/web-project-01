using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_02.Models;
using practice_02.Services.Abstraction;
using practice_02.Models;

namespace practice_02.Controllers
{
    //[Route("[controller]")]

    public class HomeController : Controller
    {
        [Route("")]
        [Route("/Index")]
        [Route("/Airport/Index")]
        public IActionResult Index()
        {
            return View();
        }
        
    }
}


