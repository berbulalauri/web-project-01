using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Models;
using tutorial_01.Services.Abstract;

namespace tutorial_01.Services.Concrete
{
    public class CarService : ICarService
    {
        IRepository<Car> _repository;

        public CarService(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public void AddCar(Car car)
        {
            _repository.Add(car);
        }

        public List<Car> GetCars()
        {
            var cars = _repository.GetAll();
            return cars.OrderBy(x => x.MaxSpeed).ToList();

        }
    }
}
