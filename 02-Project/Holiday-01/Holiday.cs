using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using workshop2.Helpers;

namespace workshop2
{
    public class Holiday
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string LaunchYear { get; set; }
        public DateTime Date { get; set; }
        public bool IsFixed { get; set; }
        public bool IsGlobal { get; set; }

        public string CommonNameFromApi { get; set; }
        public string CountryCodeFromApi { get; set; }
        public string OfficalNameFromApi { get; set; }

        public Holiday()
        {
        }

        public Holiday(string name,string countryCode, DateTime date, bool isFixed, bool isGlobal, string launchYear)
        {
            Name = name;
            CountryCode = countryCode;
            LaunchYear = launchYear;
            Date = date;
            IsFixed = isFixed;
            IsGlobal = isGlobal;
        }

        public override string ToString()
        {
            return $"Name: {Name} \n " +
                $"CountryCode: {CountryCode} \n " +
                $"LaunchYear: {LaunchYear} \n " +
                $"Date: {Date} \n " +
                $"IsFixed: {IsFixed} \n " +
                $"IsGlobal: {IsGlobal} \n ";
        }

        public async Task GenerateCustomContryCodeValues()
        {
            var names = await ApiForCountryName.GetNameAsync();

            OfficalNameFromApi = names.Item1;
            CommonNameFromApi = names.Item2;
            CountryCodeFromApi = names.Item3;
        }

    }
}
