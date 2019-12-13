using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_01.Models;
using Microsoft.AspNetCore.Mvc;
using practice_01.Services.Abstraction;

namespace practice_01.Controllers
{
    public class StudentsController : Controller
    {
        IAccountInfoService _contactService;
        public StudentsController(IAccountInfoService contactService)
        {
            _contactService = contactService;
        }

        [Route("")]
        [Route("/Index")]
        [Route("/Student")]
        [Route("/Student/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Created()
        {
            return View();
        }

        [HttpPost("Student/Welcome")]
        public IActionResult RegisterAction(Student student)
        {
            Student myvalidAccount = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            _contactService.AddAccountInfo(myvalidAccount);
            return View("SuccessMessage", _contactService.GetAccountInfo());
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                return View("Created", new List<Student> { student});
            }
            return View();
        }
    }
}