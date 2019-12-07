using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Services
{
    public class RandomGenerator : IGenerator
    {
        public Random random = new Random();
        public RandomGenerator()
        {
        }
        public int GeneratePositiveIntegerNumber()
        {
            return random.Next(0, 100000000);
        }
        public int GenerateNegativeIntegerNumber()
        {
            return random.Next(-100000000, 0);
        }
        public string GenerateString(int lenght)
        {
               var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
               var stringChars = new char[lenght];
               for (int i = 0; i < stringChars.Length; i++)
               {
                   stringChars[i] = chars[random.Next(chars.Length)];
               }
               string finalString = new String(stringChars);
            return finalString;
        }
    }
}

//public IEnumerable<Brand> GetBrands()
//{
//    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
//    var stringChars = new char[8];
//    var random = new Random();

//    for (int i = 0; i < stringChars.Length; i++)
//    {
//        stringChars[i] = chars[random.Next(chars.Length)];
//    }

//    string finalString = new String(stringChars);

//    return new List<Brand>
//    {
//        new Brand(finalString,random.Next(0, 100000000),random.Next(-100000000,0 ))
//    };
//}

//new Brand { Name = finalString },
//new Brand { PositiveNumber = random.Next(0, 100000000) },
//new Brand { NegativeNumber = random.Next(-100000000,0 ) }
