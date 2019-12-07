using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_02.Models;
using practice_02.Services.Abstraction;

namespace practice_02.Services.Concrete
{
    public class AirlineService : IAirlineService
    {

        List<AirlineModel> _storage = new List<AirlineModel>
        {
            new AirlineModel   {
            AirlineName="WizzAir Hungary Airline",
            AircraftCount=51,
            MaximumLuggageWeight=13,
            AirlineFoundingCity="Budapest",
            IsInternational=true,
            },
            new AirlineModel   {
            AirlineName="RainAir Ireland Airline",
            AircraftCount=123,
            MaximumLuggageWeight=31,
            AirlineFoundingCity="Dublin",
            IsInternational=false,
            }
            };

        public void AddAirline(AirlineModel contact)
        {
            _storage.Add(contact);
        }
        public IEnumerable<AirlineModel> GetAirline()
        {
            return _storage;
        }
    }
}
