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
        IAirlineService _contactService;
        
        string FilePath = "E:/myAirLineJson.json";
        List<Position> nnn = new List<Position>();
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
            if (!System.IO.File.Exists(FilePath))
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.Write("[]");
                }
            }
            var dataFromFile = System.IO.File.ReadAllText(FilePath);
            var list = JsonConvert.DeserializeObject<List<AirlineModel>>(dataFromFile);
            list.Add(mycontact);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, convertedJson);

            var data = JsonConvert.DeserializeObject<List<AirlineModel>>(convertedJson);
            for (int i = 0; i < data.Count; i++)
            {
                nnn.Add(new Position(data[i].AirlineName));
            }
            _positions = nnn;

            _contactService.AddAirline(contact);
            return View("GetAllAirline", _contactService.GetAirline());
        }
    }
}

/*
_positions = new List<Position>
{
 new Position("WizzAir Hungary Airline"),
 new Position("RainAir Ireland Airline"),
 new Position(contact.AirlineName)
};
*/
