using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Models
{
    [Serializable]
    public class AirlineModel
    {
        public string AirlineName { get; set; }
        public int AircraftCount { get; set; }
        public int MaximumLuggageWeight { get; set; }
        public string AirlineFoundingCity { get; set; }
        public bool  IsInternational{ get; set; }
    }
}
