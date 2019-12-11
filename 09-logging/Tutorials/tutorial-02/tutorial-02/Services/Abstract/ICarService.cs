using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_02.Models;

namespace tutorial_02.Services.Abstract
{
    public interface ICarService
    {
        List<Car> GetCars();
        void AddCar(Car car);
    }
}
