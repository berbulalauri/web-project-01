using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_01.Models;
using tutorial_01.Services.Abstract;

namespace tutorial_01.Services.Concrete
{
    public class CarRepository : IRepository<Car>
    {
        List<Car> _cars = new List<Car>();
        public void Add(Car item)
        {
            _cars.Add(item);
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars;
        }
    }
}
