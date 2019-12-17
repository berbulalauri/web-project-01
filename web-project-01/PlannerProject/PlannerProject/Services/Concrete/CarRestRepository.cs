using PlannerProject.Models;
using PlannerProject.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerProject.Services.Concrete
{
    public class CarRestRepository : IAsyncRepository<Car>
    {

        public Task Add(Car item)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Car item)
        {

            var client = new RestClient($"https://tbctest-d7a9.restdb.io/rest/events");
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-apikey", "6371523b60911d9468deebe0a547f1d191d04");
            //request.AddJsonBody(item);
            request.AddJsonBody(
            new
            {
                Name = item.Name,
                Description = item.Description,
                Author = item.Author,
                StartDateTime = item.StartDateTime.AddHours(4),
                EndDateTime = item.EndDateTime.AddHours(4)
            });
            var response = await client.ExecuteTaskAsync<List<Car>>(request);
        }
        public async Task Edit(string id, Car item)
        {

            var client = new RestClient($"https://tbctest-d7a9.restdb.io/rest/events/{id}"); // /{Id}
            var request = new RestRequest(Method.PUT);
            request.AddHeader("x-apikey", "6371523b60911d9468deebe0a547f1d191d04");
            //request.AddJsonBody(item);
            request.AddJsonBody(
            new
            {
                Name = item.Name,
                Description = item.Description,
                Author = item.Author,
                StartDateTime = item.StartDateTime.AddHours(4),
                EndDateTime = item.EndDateTime.AddHours(4)
            });
            var response = await client.ExecuteTaskAsync<List<Car>>(request);
        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            List<Car> result = null;

            try
            {
                var client = new RestClient("https://tbctest-d7a9.restdb.io/rest/events");
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
                var client = new RestClient($"https://tbctest-d7a9.restdb.io/rest/events/{Id}");
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

//request.AddJsonBody(
//new
//{
//    Name = item.Name,
//    MaxSpeed= item.MaxSpeed,
//    Mileage = item.Mileage,
//});