﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practice_02.Models;
using practice_02.Services.Abstraction;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace practice_02.Controllers
{

    public class AirportController : Controller
    {
        string json;
        string FilePath = "E:/myjson.json";
        
        IAirportService _contactService;

        
        public AirportController(IAirportService contactService)
        {
            _contactService = contactService;
        }

        [Route("Get")]
        [Route("Airport/Get")]
        public IActionResult GetAllAiproprts()
        {
            var model = _contactService.GetAirport();
            return View(model);
        }

        [HttpGet("Create")]
        [HttpGet("/Airport/Create")]
        public IActionResult AddAirport()
        {
            ViewData["positions"] = AirlineController._positions;
            return View();
        }
        [HttpPost("saveAirport")]
        public IActionResult Create(AirportModel contact)
        {
            AirportModel mycontact = new AirportModel
            {
                Name = contact.Name,
                City = contact.City,
                IsInternational = contact.IsInternational
            };
            json = JsonConvert.SerializeObject(mycontact);
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.Write(json);
            }
            _contactService.AddAirport(contact);
            return View("GetAllAiproprts", _contactService.GetAirport());
        }
    }


}
