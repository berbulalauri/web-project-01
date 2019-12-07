using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Models
{
    public class Position
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Position(string name)
        {
            Name = name;

        }

    }
}
