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

    public class AirportController : Controller
    {
        string FilePath = "E:/myjson.json";
        
        IAirportService _contactService;

        List<AirportNameModel> AirportModelList = new List<AirportNameModel>(); 
        List<AirportNameModel> _airportname = new List<AirportNameModel>
        {
         new AirportNameModel("IStanbul AtaTurk Airport"),
        };
        public AirportController(IAirportService contactService)
        {
            _contactService = contactService;
        }

        [Route("Get")]
        [Route("Airport/Get")]
        public IActionResult GetAllAiproprts()
        {
            //ViewData["positions"] = _airportname;
            //var model = _contactService.GetAirport();
            //return View();

            var model = _contactService.GetAirport();
            return View(model);
        }

        [HttpGet("Create")]
        [HttpGet("/Airport/Create")]
        public IActionResult AddAirport()
        {
            List<Position> _FromAirlinePositions;
            List<Position> _AirlineSecondList = new List<Position>();
            string AirlineFilePath = "E:/myAirLineJson.json";

            var dataFromFile = System.IO.File.ReadAllText(AirlineFilePath);
            var data = JsonConvert.DeserializeObject<List<AirlineModel>>(dataFromFile);
            for (int i = 0; i < data.Count; i++)
            {
                _AirlineSecondList.Add(new Position(data[i].AirlineName));
            }
            _FromAirlinePositions = _AirlineSecondList;

            ViewData["positions"] = _FromAirlinePositions;
            //ViewData["positions"] = AirlineController._positions;
            return View();
        }

        [HttpPost("saveAirport")]
        public IActionResult Create(AirportModel contact)
        {
            AirportModel myAirportModel = new AirportModel
            {
                Name = contact.Name,
                City = contact.City,
                IsInternational = contact.IsInternational
            };
            if (!System.IO.File.Exists(FilePath))
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.Write("[]");
                }
            }
            var AirportDataFromFile = System.IO.File.ReadAllText(FilePath);
            var listOfAirport = JsonConvert.DeserializeObject<List<AirportModel>>(AirportDataFromFile);
            listOfAirport.Add(myAirportModel);
            var convertedJsonFromAirport = JsonConvert.SerializeObject(listOfAirport, Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, convertedJsonFromAirport);

            var AirportJsonDeserData = JsonConvert.DeserializeObject<List<AirportModel>>(convertedJsonFromAirport);
            for (int i = 0; i < AirportJsonDeserData.Count; i++)
            {
                AirportModelList.Add(new AirportNameModel(AirportJsonDeserData[i].Name));
            }
            _airportname = AirportModelList;

            _contactService.AddAirport(contact);
            return View("GetAllAiproprts", _contactService.GetAirport());
        }
    }


}
