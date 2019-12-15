using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarsRent.Helpers
{
    public class Sha1Helper
    {
        public static string HashHash(string source)
        {
            var result = new StringBuilder();
            using (var sha1=new SHA1Managed())
            {
               var hashedBytes= sha1.ComputeHash(Encoding.UTF8.GetBytes(source));
                foreach (var smthng in hashedBytes)
                {
                    result.Append(smthng.ToString("x2"));
                }
            }
            return result.ToString();
        }
    }
}
