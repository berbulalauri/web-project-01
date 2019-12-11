using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tutorial_02.Models;
using tutorial_02.Services.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tutorial_02.Controllers
{
    public class CarController : Controller
    {
        ILogger _logger;
        ICarService _carService;
        public CarController(ICarService carService, ILogger logger)
        {
            _logger = logger;
            _carService = carService;
        }
        public IActionResult Index()
        {
            var model = _carService.GetCars();
            return View(model);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car newCar)
        {
            _logger.LogInfo($"Tried to add new car with name {newCar.Name} with maxSpeed {newCar.MaxSpeed}");
            if (newCar.Name =="error")
            {
                throw new ArgumentException("Argument localhost!!!!!!!!");
            }
            _carService.AddCar(newCar);

            return RedirectToAction("Index");
            //return View("Index");
        }

    }
}
