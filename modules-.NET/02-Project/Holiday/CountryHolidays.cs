using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using workshop2.Helpers;

namespace workshop2
{
    class CountryHolidays
    {
        public string localNameFromApi { get; set; }
        public string nameFromApi { get; set; }
        public string countryCodeFromApi { get; set; }
        public string typeFromApi { get; set; }

        public CountryHolidays()
        {
        }

        public override string ToString()
        {
            return $"localNameFromApi: {localNameFromApi} \n " +
                $"CountryCode: {nameFromApi} \n " +
                $"countryCodeFromApi: {countryCodeFromApi} \n " +
                $"typeFromApi: {typeFromApi} \n ";
        }

        public async Task GenerateNewCountryHoliday()
        {
            var nameResult = await NewApiHelper.GetNameAsync();
            localNameFromApi = nameResult.Item1;
            nameFromApi = nameResult.Item2;
            countryCodeFromApi = nameResult.Item3;
            typeFromApi = nameResult.Item4;



        }
    }
}
