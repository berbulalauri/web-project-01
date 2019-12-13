using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_03.Models;
using practice_03.Services.Abstraction;

using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace practice_03.Controllers
{
    //[Route("[controller]")]

    public class HomeController : Controller
    {
    string FilePath = "AccountListJson.json";
    IAccountInfoService _contactService;
    public HomeController(IAccountInfoService contactService)
    {
        _contactService = contactService;
    }

    [Route("")]
    [Route("/Index")]
    [Route("/Home")]
    [Route("/Home/Index")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Get")]
    [Route("Home/Get")]
    public IActionResult GetAllAccount()
    {
        var model = _contactService.GetAccountInfo();
        return View(model);
    }

    [HttpGet("Create")]
    [HttpGet("/Home/Create")]
    public IActionResult AddAccount()
    {
        return View();
    }
    [HttpGet("login")]
    [HttpGet("/Home/login")]
    public IActionResult LogInAccount()
    {
        return View();
    }

    [HttpPost("Home/Welcome")]
    public IActionResult LogInChecker(ValidateUsers accountContent)
    {
        AccountInfo myvalidAccount = new AccountInfo
        {
            UserName = accountContent.UserName,
            Password = accountContent.Password
        };
      
        var dataUserAccounts = System.IO.File.ReadAllText(FilePath);
        var listFromUserAccounts = JsonConvert.DeserializeObject<List<AccountInfo>>(dataUserAccounts);
            for (int i = 0; i < listFromUserAccounts.Count; i++)
            {
                if (listFromUserAccounts[i].UserName == accountContent.UserName)
                {
                    if (listFromUserAccounts[i].Password == accountContent.Password)
                    {
                        _contactService.AddAccountInfo(myvalidAccount);
                        return View("LoginWelcome", _contactService.GetAccountInfo());
                    }
                }
            }
        return View("LoginError", _contactService.GetAccountInfo());
    }


    [HttpPost("Home/save")]
    public IActionResult Create(AccountInfo accountContent)
    {
        _contactService.AddAccountInfo(accountContent);
        return View("GetAllAccount", _contactService.GetAccountInfo());
    }

    [HttpPost("Home/Success")]
    public IActionResult Success(AccountInfo accountContent)
    {
    AccountInfo myAccount = new AccountInfo
        {
            ClientId = Guid.NewGuid(),
            UserName = accountContent.UserName,
            CodeAnswer = accountContent.CodeAnswer,
            CodeQuestion = accountContent.CodeQuestion,
            Password = accountContent.Password
        };
        if (!System.IO.File.Exists(FilePath))
        {
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.Write("[]");
            }
        }
        var dataFromFile = System.IO.File.ReadAllText(FilePath);
        var list = JsonConvert.DeserializeObject<List<AccountInfo>>(dataFromFile);
        list.Add(myAccount);
        var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
        System.IO.File.WriteAllText(FilePath, convertedJson);


        _contactService.AddAccountInfo(myAccount);
        //_contactService.AddAccountInfo(contact);
        return View("Success", _contactService.GetAccountInfo());
    }
}
}


