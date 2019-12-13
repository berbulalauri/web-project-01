using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsRent.Models;
using CarsRent.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarsRent.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        IAsyncRepository<Car> _carRepo;
        public CarController(IAsyncRepository<Car> carRepo, ILogger<CarController> logger)
        {
            _carRepo = carRepo;
            _logger = logger;
        }
        // GET: Car
        public async Task<ActionResult> Index()
        {
            _logger.LogInformation("Get all Cars");
            var cars = await _carRepo.GetAll();
            return View(cars);
        }

       

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Update(int id)
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Update(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            await _carRepo.Delete(id);
            _logger.LogInformation($"Delete Car with ID={id}");
            return RedirectToAction(nameof(Index));
        }

        
    
    }
}