using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using workshop_02.Models;

namespace workshop_02.Helpers
{
    class ApiHelper
    {
        private const string _nameUrl= "https://uinames.com/api/?region=australia";
        public async static Task<(string, string)> GetNameAsync()
        {
            HttpClient httpClient = new HttpClient();
            var requestResult = await httpClient.GetStringAsync(_nameUrl);

            NameApiResponse result = JsonConvert.DeserializeObject<NameApiResponse>(requestResult);

            return (result.name, result.surname);

/*          var jsonFileRepository = new JsonFileRepository<List<Subscriber>>(Configuration.FileName);
            await jsonFileRepository.CreateAsync(listOfSubscribers);
            var listFromFile = await jsonFileRepository.ReadAsync();
*/
        }
    }
}

