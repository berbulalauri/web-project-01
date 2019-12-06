using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Services.Abstraction;

namespace tutorial_01.Controllers
{
    public class HomeController : Controller
    {
        IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var model = _contactService.GetContacts();
            return View(model);
        }
    }
}
