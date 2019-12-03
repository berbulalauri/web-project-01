using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using workshop2.Repositories;

namespace workshop2
{
    class Program
    {
        public static bool isFixed;
        public static bool isGlobal;
        public static bool whilelooper;
        public static DateTime launchYear;

        public static List<Holiday> listOfSubscribers = new List<Holiday> { };

        public static JsonFileRepository<List<Holiday>> jsonFileRepository = new JsonFileRepository<List<Holiday>>(Configuration.FileName);


        static Dictionary<int, Action> actionsDictionery = new Dictionary<int, Action>
        {
            {1, ()=>{  Yourchoice().GetAwaiter().GetResult(); } },
            {2, ()=>{  PrintYourResult().GetAwaiter().GetResult(); } },
            {3, ()=>{  AddSubscriber().GetAwaiter().GetResult(); } },
            {4, ()=>{  AddTotallyNewSubscriber().GetAwaiter().GetResult(); } },
            {0, ()=>{  whilelooper = false; } }
        };
        static async Task Main(string[] args)
        {
            MainMenu();
            //await MakeProgramGreatAgain();
            //await Yourchoice();
        }


        static void MainMenu()
        {
            int userChoice;
            Action actionInvoke;
            whilelooper = true;
            try
            {
                while (whilelooper)
                {

                    Console.WriteLine("\n1. Add new holiday to holidays.json");
                    Console.WriteLine("2. Show all holidays from holidays.json");
                    Console.WriteLine("3. Show holidays in United States");
                    Console.WriteLine("4. Show list of holiday in ITALY");
                    Console.WriteLine("0. Exit\n");

                    do
                    {
                        Console.Write("Your choice? ");
                        var userInput = Console.ReadLine();
                        int.TryParse(userInput, out userChoice);
                    }

                    while (!actionsDictionery.TryGetValue(userChoice, out actionInvoke));
                    actionInvoke?.Invoke();
                     
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task Yourchoice()
        {

            Console.Write("Name: ");
            var userName = Console.ReadLine();

            Console.Write("Country code: ");
            var userCountryCode = Console.ReadLine();

            Console.Write("Date: ");
            var userInputDate = Console.ReadLine();
            DateTime.TryParse(userInputDate, out DateTime date);

            Console.Write("Fixed(y / n): ");
            var userInputIsFixed = Console.ReadLine();
            if (userInputIsFixed == "y")
            {
               isFixed = true;
            }
            else if (userInputIsFixed == "n")
            {
               isFixed = false;
            }

            Console.Write("Global(y / n): ");
            var userInputIsGlobal = Console.ReadLine();
            if (userInputIsGlobal == "y")
            {
                isGlobal = true;
            }
            else if (userInputIsGlobal == "n")
            {
                isGlobal = false;
            }

            Console.Write("Launch year: ");
            var userInputlaunchYear = Console.ReadLine();
            DateTime.TryParse(userInputlaunchYear, out launchYear);

            listOfSubscribers.Add(new Holiday(userName, userCountryCode, date, isFixed, isGlobal, launchYear));

            await jsonFileRepository.CreateAsync(listOfSubscribers);

        }

        static async Task PrintYourResult()
        {
            Console.WriteLine("| Name | Country code | Date | Fixed | Global | Launch year |");
            Console.WriteLine(".............................................................");
            var listFromFile = await jsonFileRepository.ReadAsync();
            listFromFile.ForEach(s => {
                Console.WriteLine($"{s.Name} | {s.CountryCode} | {s.Date} | {s.IsFixed} | {s.IsGlobal} | {s.LaunchYear}");
            });
        }

        static async Task<bool> AddSubscriber()
        {
            var subsciberToAdd = new Holiday();
            await subsciberToAdd.GenerateSubscriber();
            //listOfSubscribers.Add(subsciberToAdd);
            Console.WriteLine("CommonName From Api: " + subsciberToAdd.CommonNameFromApi + 
                "\nCountryCode From Api: " + subsciberToAdd.CountryCodeFromApi + 
                "\nOffical Name From Api: " + subsciberToAdd.OfficalNameFromApi);
            return true;
        }

        static async Task<bool> AddTotallyNewSubscriber()
        {
            var newSubsciberToAdd = new CountryHolidays();

            await newSubsciberToAdd.GenerateNewCountryHoliday();

            Console.WriteLine("Local Name From Api: " + newSubsciberToAdd.localNameFromApi + 
                "\nCountryCode From Api: " + newSubsciberToAdd.countryCodeFromApi + 
                "\nOffical Name From Api: " + newSubsciberToAdd.nameFromApi +
                "\nOffical Type From Api: " + newSubsciberToAdd.typeFromApi
                );
            return true;
        }

        static async Task MakeProgramGreatAgain()
        {

            //var listOfSubscribers = new List<Subscriber>
            //{
            //    new Subscriber("Vitalii", "Moshkin", "EF235134", new DateTime(1965, 9, 24), true),
            //    new Subscriber("Valerii", "Vynokurov", "EQ323354", new DateTime(1946, 11, 7), false),
            //};


/*            await jsonFileRepository.CreateAsync(listOfSubscribers);
            var listFromFile = await jsonFileRepository.ReadAsync();

            listFromFile.ForEach(s => Console.WriteLine(s));*/
        }
    }
}
