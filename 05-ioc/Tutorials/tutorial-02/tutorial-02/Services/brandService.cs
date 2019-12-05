using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial_02.Models;

namespace tutorial_02.Services
{
    public class brandService : IBrandService
    {
        public brandService()
        {

        }
        public IEnumerable<Brand> GetBrands()
        {
            return new List<Brand>
            {
                new Brand { Name = "BMW" },
                new Brand { Name = "JapanMotor" },
                new Brand { Name = "RR" }
            };
        }

    }
}
