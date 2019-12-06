using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_03.Models;
using tutorial_03.Services.Abstraction;
using tutorial_03.Models;

namespace tutorial_03.Controllers
{
    //[Route("[controller]")]

    public class HomeController : Controller
    {
        IContactService _contactService;
        List<Position> _positions = new List<Position>
        {
            new Position() {Name="Junior policeman", Salary=1000 },
            new Position() {Name="Middle policeman", Salary=1500 },
            new Position() {Name="Thief", Salary=33333 }
        };
        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("")]
        [Route("/Index")]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("contact")]
        [Route("home/contact")]
        public IActionResult Contact()
        {
            var model = _contactService.GetContacts();
            return View(model);
        }

        [HttpGet("add")]
        [HttpGet("/home/add")]
        public IActionResult AddContact()
        {
            ViewData["positions"] = _positions;
            return View();
        }

        [HttpPost("save")]
        public IActionResult Create(Contact contact)
        {
            _contactService.AddContact(contact);
            return View("Contact", _contactService.GetContacts());
        }

        //public IActionResult Create(Contact contact)
        //{
        //    var model = (List<Contact>)_contactService.GetContacts();
        //    model.Add(contact);
        //    return View("Contact", model);
        //}

        //public IActionResult Create(string name, string phone) {
        //var newContact = new Contact { Name = name, Phone = phone };
        //var model = (List<Contact>)_contactService.GetContacts();
        //model.Add(newContact);
        //return View("Contact", model);
        //}
    }
}


