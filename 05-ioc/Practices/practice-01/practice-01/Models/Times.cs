using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_01.Models
{
    public class Times
    {
       public string Hour { get; set; }
       public string Minute { get; set; }
       public string Second { get; set; }

        public Times(string hour, string minute, string second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

    }
}
