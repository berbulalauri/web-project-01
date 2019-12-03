using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using workshop2.Models;

namespace workshop2.Helpers
{
    public class NewApiHelper
    {
        private const string _nameurl = "https://date.nager.at/Api/v2/PublicHolidays/2019/US";
        public async static Task<(string, string, string, string)> GetNameAsync()
        {
            HttpClient htpClient = new HttpClient();

            var requestResult = await htpClient.GetStringAsync(_nameurl);

            List<HolidayNameApiResponse> result = JsonConvert.DeserializeObject<List<HolidayNameApiResponse>>(requestResult);

            return (result[0].localName, result[0].name, result[0].countryCode, result[0].type);

        }
    }
}
