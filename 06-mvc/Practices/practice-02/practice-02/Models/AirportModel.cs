using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Models
{
    [Serializable]
    public class AirportModel
    {
        public string Name { get; set; }
        public string  City { get; set; }
        public bool  IsInternational{ get; set; }
        public string Position { get; set; }
    }
}
