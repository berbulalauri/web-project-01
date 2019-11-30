
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using workshop2.Models;

namespace workshop2.Helpers
{
    public class ApiForCountryHoliday
    {
        public static Dictionary<int, (string, string, string, string, string, string)> dict = new Dictionary<int, (string, string, string, string, string, string)>();
        public static string _nameurl;
        public async static Task<Dictionary<int, (string, string, string, string, string, string)>> GetHolidayAsync(string name)
        {
            try
            {
                _nameurl = $"https://date.nager.at/Api/v2/PublicHolidays/2019/{name}";

                HttpClient htpClient = new HttpClient();
                var requestResult = await htpClient.GetStringAsync(_nameurl);
                List<HolidayNameApiResponse> result = JsonConvert.DeserializeObject<List<HolidayNameApiResponse>>(requestResult);
                int i = 1;
                dict.Clear();

                result.ForEach(s => {
                    dict.Add(i, (s.Name, s.CountryCode, s.Date, s.Fixed, s.Global, s.LaunchYear));
                    i++;

                });
                return dict;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Goes Wrong! " + ex.Message);
            }

            dict.Clear();
            return dict;


        }
    }
}
