using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Tutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_Tutorial.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Created()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Game game )
        {
            if (ModelState.IsValid)
            {
                return View("Created", new List<Game> { game});
            }
            return View();
        }
    }
}