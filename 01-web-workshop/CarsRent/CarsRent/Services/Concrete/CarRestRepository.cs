using CarsRent.Models;
using CarsRent.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsRent.Services.Concrete
{
    public class CarRestRepository : IAsyncRepository<Car>
    {

        public Task Add(Car item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            List<Car> result = null;

            try
            {
                var client = new RestClient("https://tbctest-d7a9.restdb.io/rest/cars");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-apikey", "6371523b60911d9468deebe0a547f1d191d04");
                var response = await client.ExecuteTaskAsync<List<Car>>(request);

                result = response.Data;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public Task Update(Car item)
        {
            throw new NotImplementedException();
        }

        
        public async Task Delete(string Id)
        {
            try
            {
                var client = new RestClient($"https://tbctest-d7a9.restdb.io/rest/cars/{Id}");
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("x-apikey", "6371523b60911d9468deebe0a547f1d191d04");
                var response = await client.ExecuteTaskAsync<List<Car>>(request);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
