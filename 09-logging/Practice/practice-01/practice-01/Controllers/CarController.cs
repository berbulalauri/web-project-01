using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practice_01.Models;
using practice_01.Services;
using practice_01.Services.Abstract;


namespace practice_01.Controllers
{
    public class CarController : Controller
    {
        ILogger _logger;
        IAccountInfoService _carService;
        public CarController(IAccountInfoService carService, ILogger logger)
        {
            _logger = logger;
            _carService = carService;
        }
        public IActionResult Index()
        {
            var model = _carService.GetAccountInfo();
            return View(model);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(AccountInfo newCar)
        {
            _logger.LogInfo($"Tried to add new car with name {newCar.Name} with maxSpeed {newCar.MaxSpeed}");
            if (newCar.Name =="error")
            {
                throw new ArgumentException("Argument localhost!!!!!!!!");
            }
            _carService.AddAccountInfo(newCar);

            return RedirectToAction("Index");
            //return View("Index");
        }

    }
}
