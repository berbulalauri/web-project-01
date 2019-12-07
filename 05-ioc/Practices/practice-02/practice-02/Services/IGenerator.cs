using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Services
{
    public interface IGenerator
    {
        //IEnumerable<Brand> GetBrands();
        int GeneratePositiveIntegerNumber();
        int GenerateNegativeIntegerNumber();
        string GenerateString(int lenght);
    }
}
