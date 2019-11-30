using System;
using workshop_02.Tariffs;
using Newtonsoft.Json;
using System.Threading.Tasks;
using workshop_02.Helpers;
using workshop2.Helpers;

namespace workshop_02
{
    public class Airport
    {
        public string Name { get; set; }
        public string City { get; set; }
        public bool IsInternational { get; set; }
        public string BindedAirLineToAirport { get; set; }

        public Airport()
        {
        }
        public Airport(string city, string name, bool isInternational, string bindedAirLineToAirport)
        {
            Name = name;
            City = city;
            IsInternational = isInternational;
            BindedAirLineToAirport = bindedAirLineToAirport;
            //Tariff = isInternetNeed ? (ITariff)new ZipperTariff() : (ITariff)new CheetahTariff();

            Logger.Log("Airport.Airport method was called", $" Printing all Airport", $"Name: {Name} City: {City}; IsInternational: {IsInternational}; BindedAirLineToAirport: {BindedAirLineToAirport} ");
        }
        public override string ToString()
        {
            var printAnswer = IsInternational ? "International" : "";
            var BindedString = (BindedAirLineToAirport != null) ? $"Airline which is operating in {City} is: {BindedAirLineToAirport.ToUpper()}" : "";


            return $"{Name}\n" +
                $"{BindedString}";
        }

    }
}


