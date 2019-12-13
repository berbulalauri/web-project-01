using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace tutorial_01.Controllers
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