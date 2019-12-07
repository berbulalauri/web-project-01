using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_02.Models;
using practice_02.Services.Abstraction;

namespace practice_02.Services.Concrete
{
    public class AirportService : IAirportService
    {

        List<AirportModel> _storage = new List<AirportModel>
        {
            new AirportModel   {
            Name="Rustaveli International Airport",
            City="Tbilisi",
            IsInternational=true,
            },
            new AirportModel   {
            Name="BaTumi International Airport",
            City="Batumi",
            IsInternational=false,
            }
            };

        public void AddAirport(AirportModel contact)
        {
            _storage.Add(contact);
        }
        public IEnumerable<AirportModel> GetAirport()
        {
            return _storage;
        }
    }
}
