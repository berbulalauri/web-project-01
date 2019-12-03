using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using workshop2.Repositories;

namespace workshop2
{
    class Program
    {

        static Dictionary<int, Action> ActionDictionary = new Dictionary<int, Action>
        {
            {1, ()=> { Console.WriteLine("you choose one");} },
            {2, ()=> { Console.WriteLine("you choose two");} },
            {3, ()=> { AddSubscriber().GetAwaiter().GetResult(); } },
            //{4, ()=> { loop = false; } }
        };

        static List<Subscriber> listOfSubscribers = new List<Subscriber>
            {
                new Subscriber("Vitalii", "Moshkin", "EF235134", new DateTime(1965, 9, 24), true),
                new Subscriber("Valerii", "Vynokurov", "EQ323354", new DateTime(1946, 11, 7), false),
            };
        static async Task Main(string[] args)
        {
            MainMenu();
            await MakeProgramGreatAgain();
        }
        static void MainMenu()
        {
        bool loop = true;
        int userChoice;
        Action actionToInvoke;

            try
            {
                while (loop)
                {
                        Console.WriteLine("1. Add New Subscriber: \n" +
                                        "2. Show All Subscriber: \n" +
                                        "3. Top Up Balance: ");

                    do
                    {
                        Console.WriteLine("please enter the value: ");
                        var userInput = Console.ReadLine();
                        int.TryParse(userInput, out userChoice);

                    } while (!ActionDictionary.TryGetValue(userChoice, out actionToInvoke));
                        
                    actionToInvoke?.Invoke();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async Task<bool> AddSubscriber()
        {
            var subscriberToAdd = new Subscriber();
            await subscriberToAdd.GenerateSubscribers();
            listOfSubscribers.Add(subscriberToAdd);
            Console.WriteLine($"sibscrobers first Name: {subscriberToAdd.FirstName} , last Name: {subscriberToAdd.LastName}");
            return true;
        }


        static async Task MakeProgramGreatAgain()
        {



            var jsonFileRepository = new JsonFileRepository<List<Subscriber>>(Configuration.FileName);

            await jsonFileRepository.CreateAsync(listOfSubscribers);
            var listFromFile = await jsonFileRepository.ReadAsync();

            listFromFile.ForEach(s => Console.WriteLine(s));
        }
    }
}
