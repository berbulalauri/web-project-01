using System;
using workshop_02.Tariffs;
using Newtonsoft.Json;
using System.Threading.Tasks;
using workshop_02.Helpers;
using workshop2.Helpers;
using System.Collections.Generic;
using System.Text;
using workshop_02;

namespace workshop2
{
    class Airlines
    {
        public string AirlineName { get; set; }
        public int AircraftCount { get; set; }
        public int MaxLuggageWeigth { get; set; }
        public bool IsBusinessAvailiable { get; set; }
        public bool IsPetFriendly { get; set; }

        [JsonConverter(typeof(ConcreteConverter<BasicTypes>))]
        public AirLineTypes RegularOrLowcost { get; set; }

        public Airlines()
        {
        }
        public Airlines(string airlineName, int aircraftCount, bool isRegularAirLine, int maxLugWeigth, bool isBusinessAvail, bool isPetFriendly)
        {
            AirlineName = airlineName;
            AircraftCount = aircraftCount;
            MaxLuggageWeigth = maxLugWeigth;
            IsBusinessAvailiable = isBusinessAvail;
            IsPetFriendly = isPetFriendly;
            //AirlineType = isRegularAirLine ? new Regular(maxLugWeigth, isBusinessAvail, isPetFriendly) : (AirLineInterface)new Lowcost(maxLugWeigth);
            RegularOrLowcost = isRegularAirLine ? new Regular(maxLugWeigth, isBusinessAvail, isPetFriendly) : (AirLineTypes)new Lowcost(maxLugWeigth);

            Logger.Log("Airlines.Airlines method was called", $" Printing all Airlines", $"AirlineName: {AirlineName}; AircraftCount: {AircraftCount}; MaxLuggageWeigth: {MaxLuggageWeigth}; IsBusinessAvailiable: {IsBusinessAvailiable} ");
        }

        public override string ToString()
        {
         return $"\nAll AirlineName:  {AirlineName}\n" +
                $"Aircraft Count:   {AircraftCount}\n" +
                $"MaxLuggageWeigth: {MaxLuggageWeigth}\n" +
                $"Business Class:   {IsBusinessAvailiable}\n" +
                $"Pet Friendlyness: {IsPetFriendly}\n";
        }

    }
}

