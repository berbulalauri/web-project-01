using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using workshop2.Models;

namespace workshop2.Helpers
{
    public class ApiForCountryName
    {
        private const string _countryinfoUrl = "https://date.nager.at/Api/v2/CountryInfo?countryCode=HT";
        public async static Task<(string,string,string)> GetNameAsync()
        {
            HttpClient htpClient = new HttpClient();

            var requestResult = await htpClient.GetStringAsync(_countryinfoUrl);

            NameApiResponse result = JsonConvert.DeserializeObject<NameApiResponse>(requestResult);
            return (result.officialName, result.CommonName, result.CountryCode);

        }
    }
}
