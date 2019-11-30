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

        public static List<Holiday> listOfSubscribers = new List<Holiday> { };
        public static JsonFileRepository<List<Holiday>> jsonFileRepository = new JsonFileRepository<List<Holiday>>(Configuration.FileName);

        static Dictionary<int, Action> actionsDictionery = new Dictionary<int, Action>
        {
            {1, ()=>{  Yourchoice().GetAwaiter().GetResult(); } },
            {2, ()=>{  PrintAddedByYouHolidayResult().GetAwaiter().GetResult(); } },
            {3, ()=>{  PrintCustomCountryCodeResult().GetAwaiter().GetResult(); } },
            {4, ()=>{  GenerateSelectedCountrysHolidayList().GetAwaiter().GetResult(); } },
            {0, ()=>{  whilelooper = false; } }
        };
        static async Task Main(string[] args)
        {
            MainMenu();
        }
        static void MainMenu()
        {
            int userChoice;
            Action actionInvoke;
            whilelooper = true;
            bool intChecker;
            int p;
            try
            {
                while (whilelooper)
                {

                    Console.WriteLine("\n1. Add new holiday to holidays.json");
                    Console.WriteLine("2. Show all holidays from holidays.json");
                    Console.WriteLine("3. Show Date From Haiti");
                    Console.WriteLine("4. Show holidays by selected country");
                    Console.WriteLine("0. Exit\n");

                    do
                    {
                        p=0; 
                        do
                        {
                            if (p > 0) { Console.WriteLine("Incorect Input. Please Use Only numbers."); }
                            Console.Write("Your choice? ");
                            var userInput = Console.ReadLine();
                            intChecker = int.TryParse(userInput, out userChoice);
                            p++;
                        } while (!intChecker);

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
            int j = 0;
            string holidayName;
            do
            {
                if (j > 0) { Console.WriteLine("Incorect Holiday Name. Please Use Only Letters."); }
                Console.Write("Name:          ");
                holidayName = Console.ReadLine();
                j++;
            } while (!ValidationHelper.IsNameValid(holidayName));


             j = 0;
            string countryCodeName;
            do
            {
                if (j > 0) { Console.WriteLine("Incorect Country Code. Please Use Only Letters And Number of Symbols Must be Less Than 3."); }
                Console.Write("Country code:  ");
                countryCodeName = Console.ReadLine();
                j++;
            } while (!ValidationHelper.CountryCodeValid(countryCodeName));

            j = 0;
            bool isDateTimeBool; 
            DateTime outputDateTimeValue;
            do
            {
                if (j > 0) { Console.WriteLine("Incorect Date. Please Write Date like this - MM.DD.YYYY"); }
                Console.Write("Date:          ");
                var userInputDate = Console.ReadLine();
                isDateTimeBool = DateTime.TryParse(userInputDate, out outputDateTimeValue);
                j++;
            } while (!isDateTimeBool);


            j = 0;
            string userInputForIsFixed;
            do
            {
                if (j > 0) { Console.WriteLine("Incorect Input. Please Try Again:"); }
                Console.Write("Fixed(y / n):  ");
                userInputForIsFixed = Console.ReadLine();
                if (userInputForIsFixed == "y") { isFixed = true; }
                else if (userInputForIsFixed == "n") { isFixed = false; }
                j++;

            } while (userInputForIsFixed != "n"  && userInputForIsFixed != "y" );

            j = 0;
            string userInputForIsGlobal;
            do
            {
                if (j > 0) { Console.WriteLine("Incorect Input. Please Try Again.\n"); }
                Console.Write("Global(y / n): ");
                userInputForIsGlobal = Console.ReadLine();
                if (userInputForIsGlobal == "y") { isGlobal = true; }
                else if (userInputForIsGlobal == "n") { isGlobal = false; }
                j++;

            } while (userInputForIsGlobal != "n" && userInputForIsGlobal != "y" );

            j = 0;
            bool isLaunchYearBool;
            string launchYear="";
            int launchYearOutput;
            do
            {
                if (j > 0) { Console.WriteLine("Incorect Input. Please Try Again.\n"); }
                Console.Write("Launch year:   ");
                var userInputlaunchYear = Console.ReadLine();

                if (String.IsNullOrEmpty(userInputlaunchYear)) { break; }
                else
                {
                    isLaunchYearBool = int.TryParse(userInputlaunchYear, out launchYearOutput);
                    launchYear = launchYearOutput.ToString();
                }
                j++;
            } while (!isLaunchYearBool || launchYearOutput > 2019 || launchYearOutput < 1);

            listOfSubscribers.Add(new Holiday(holidayName, countryCodeName, outputDateTimeValue, isFixed, isGlobal, launchYear));

            await jsonFileRepository.CreateAsync(listOfSubscribers);
        }
        static async Task PrintAddedByYouHolidayResult()
        {
            Console.WriteLine("|{0,30}|{1,12}|{2,13}|{3,8}|{4,8}|{5,11}|", "Name", "Country Code", "Date", "Fixed", "Global", "Launch Year");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            var listFromFile = await jsonFileRepository.ReadAsync();
            listFromFile.ForEach(s => {
            Console.WriteLine(String.Format("|{0,30}|{1,12}|{2,13}|{3,8}|{4,8}|{5,11}|",
                s.Name, s.CountryCode, s.Date.ToString("MM/dd/yyyy"), s.IsFixed, s.IsGlobal, s.LaunchYear));
            });
        }
        static async Task<bool> PrintCustomCountryCodeResult()
        {
            var customCountryCodeValues = new Holiday();
            await customCountryCodeValues.GenerateCustomContryCodeValues();

            Console.WriteLine("Common Name:   " + customCountryCodeValues.CommonNameFromApi + 
                              "\nCountry Code:  " + customCountryCodeValues.CountryCodeFromApi + 
                              "\nOffical Name:  " + customCountryCodeValues.OfficalNameFromApi);
            return true;
        }
        static async Task<bool> GenerateSelectedCountrysHolidayList()
        {
            bool whileLooper;
            int i = 0;
            do
            {
                if (i > 0) { Console.WriteLine("Please Write Correct Country Code!\n"); }

                Console.Write("please Input Code: ");
                var userInputCode = Console.ReadLine();
                whileLooper = await CountryHolidays.GenerateNewCountryHoliday(userInputCode);
                i++;
            } while (!whileLooper);

            return true;
        }
    }
}
