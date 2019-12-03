using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using workshop2.Models;

namespace workshop2.Helpers
{
    public class ApiHelper
    {
        private const string _nameurl = "https://date.nager.at/Api/v2/CountryInfo?countryCode=US";
        public async static Task<(string,string,string)> GetNameAsync()
        {
            HttpClient htpClient = new HttpClient();

            var requestResult = await htpClient.GetStringAsync(_nameurl);

            NameApiResponse result = JsonConvert.DeserializeObject<NameApiResponse>(requestResult);
            return (result.officialName, result.CommonName, result.CountryCode);

        }
    }
}
