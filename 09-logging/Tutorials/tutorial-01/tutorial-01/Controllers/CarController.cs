﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tutorial_01.Models;
using tutorial_01.Services.Abstract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tutorial_01.Controllers
{
    public class CarController : Controller
    {
        ICarService _carService;
        public CarController(ICarService carService)
        {
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
