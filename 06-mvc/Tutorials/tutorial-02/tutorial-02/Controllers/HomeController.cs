using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_02.Models;
using tutorial_02.Services.Abstraction;

namespace tutorial_02.Controllers
{
    [Route("[controller]")]

    public class HomeController : Controller
    {
        IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("")]
        [Route("/")]
        [Route("/Index")]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            var model = _contactService.GetContacts();
            return View(model);
        }

        [HttpGet("add")]
        public IActionResult AddContact()
        {
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


