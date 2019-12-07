using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_02.Models;

namespace practice_02.Services.Abstraction
{
    public interface IAirlineService
    {
        public IEnumerable<AirlineModel> GetAirline();
        void AddAirline(AirlineModel contact);
    }
}
