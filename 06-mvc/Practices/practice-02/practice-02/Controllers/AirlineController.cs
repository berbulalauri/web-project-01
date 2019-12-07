using System;
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

    public class AirlineController : Controller
    {
        string json;
        string FilePath = "E:/myAirLineJson.json";
        
        IAirlineService _contactService;

        public static List<Position> _positions = new List<Position>
        {
         new Position("WizzAir Hungary Airline"),
         new Position("RainAir Ireland Airline"),
        };
        public AirlineController(IAirlineService contactService)
        {
            _contactService = contactService;
        }

        [Route("Get")]
        [Route("Airline/Get")]
        public IActionResult GetAllAirline()
        {
            var model = _contactService.GetAirline();
            return View(model);
        }

        [HttpGet("Create")]
        [HttpGet("/Airline/Create")]
        public IActionResult AddAirline()
        {
            return View();
        }
        [HttpPost("saveAirline")]
        public IActionResult Create(AirlineModel contact)
        {
            AirlineModel mycontact = new AirlineModel
            {
                AirlineName = contact.AirlineName,
                AircraftCount = contact.AircraftCount,
                MaximumLuggageWeight = contact.MaximumLuggageWeight,
                AirlineFoundingCity = contact.AirlineFoundingCity,
                IsInternational = contact.IsInternational
            };

            _positions = new List<Position>
            {
             new Position("WizzAir Hungary Airline"),
             new Position("RainAir Ireland Airline"),
             new Position(contact.AirlineName)
            };

            json = JsonConvert.SerializeObject(mycontact);
            using (StreamWriter writer = new StreamWriter(FilePath, true)) { writer.Write(json+","); }

            _contactService.AddAirline(contact);
            return View("GetAllAirline", _contactService.GetAirline());
        }
    }
}
