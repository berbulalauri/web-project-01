using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Models
{
    [Serializable]
    public class AirportNameModel
    {
        public string Name { get; set; }
        public AirportNameModel(string name)
        {
            Name = name;
        }
    }
}
