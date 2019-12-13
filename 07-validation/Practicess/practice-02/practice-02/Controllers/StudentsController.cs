using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_02.Models;
using Microsoft.AspNetCore.Mvc;
using practice_02.Services.Abstraction;
using System.IO;
using Newtonsoft.Json;

namespace practice_02.Controllers
{
    public class StudentsController : Controller
    {
        IAccountInfoService _contactService;
        public static StudentInformation myvalidAccount = new StudentInformation { };
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
            myvalidAccount = new StudentInformation
            {
                AccountGuidId = Guid.NewGuid(),
                FirstName = student.FirstName,
                LastName = student.LastName,
                CourseCount = student.CourseCount,
                BirthDate = student.BirthDate,
                Email = student.Email,
                Password = student.Password,
            };
            ViewData["message"] = $"Welcome {student.FirstName} {student.LastName}";
            //_contactService.AddAccountInfo(myvalidAccount);
            return View("SuccessMessage");
        }

        [HttpPost("Student/AddtionalInfoRegitered")]
        public IActionResult AddtionalInfoAction(StudentInformation studentInformation)
        {
            string FilePath = "StudentInfo.json";
            StudentInformation studentInfo = new StudentInformation
            {
                AccountGuidId = myvalidAccount.AccountGuidId,
                FirstName = myvalidAccount.FirstName,
                LastName = myvalidAccount.LastName,
                CourseCount = myvalidAccount.CourseCount,
                BirthDate = myvalidAccount.BirthDate,
                Email = myvalidAccount.Email,
                Password = myvalidAccount.Password,
                Autobiography = studentInformation.Autobiography,
                PhoneNumber = studentInformation.PhoneNumber,
                Disciplines = studentInformation.Disciplines,
            };
            if (!System.IO.File.Exists(FilePath))
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.Write("[]");
                }
            }
            var dataFromFile = System.IO.File.ReadAllText(FilePath);
            var list = JsonConvert.DeserializeObject<List<StudentInformation>>(dataFromFile);
            list.Add(studentInfo);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, convertedJson);


            //_contactService.AddAccountInfo(myvalidAccount);
            return RedirectToAction("Index");
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
        [HttpPost]
        public IActionResult AdvancedStudentInfo(Student student)
        {
            if (ModelState.IsValid)
            {
                return View("Created", new List<Student> { student});
            }
            return View();
        }
    }
}