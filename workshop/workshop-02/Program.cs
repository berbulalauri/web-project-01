using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using workshop2.Repositories;

namespace workshop2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await MakeProgramGreatAgain();
        }

        static async Task MakeProgramGreatAgain()
        {

            var listOfSubscribers = new List<Subscriber>
            {
                new Subscriber("Vitalii", "Moshkin", "EF235134", new DateTime(1965, 9, 24), true),
                new Subscriber("Valerii", "Vynokurov", "EQ323354", new DateTime(1946, 11, 7), false),
            };

            var jsonFileRepository = new JsonFileRepository<List<Subscriber>>(Configuration.FileName);

            await jsonFileRepository.CreateAsync(listOfSubscribers);
            var listFromFile = await jsonFileRepository.ReadAsync();

            listFromFile.ForEach(s => Console.WriteLine(s));
        }
    }
}
