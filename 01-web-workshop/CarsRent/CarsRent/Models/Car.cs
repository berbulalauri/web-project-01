using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsRent.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string _id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Mileage { get; set; }
    }
}
