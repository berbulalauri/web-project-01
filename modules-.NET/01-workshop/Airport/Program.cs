using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using workshop_02.Repositories;
using workshop2;

namespace workshop_02
{
    class Program
    {

        public static List<Airlines> listOfArilines = new List<Airlines> { };
        public static List<Airport> listOfAirports = new List<Airport> { };
        public static List<Flight> listOfFlights = new List<Flight> { };

        public static string AirlineFilePath = "../../../Airlines.json"; 
        public static string AirportFilePath = "../../../Airports.json";
        public static string FlightFilePath = "../../../Flights.json";

        static Dictionary<int, Action> ActionDictionary = new Dictionary<int, Action>
        {
            {1, ()=> { AirlineMainMethod().GetAwaiter().GetResult(); } },
            {2, ()=> { MakeAirportsGreatAgain().GetAwaiter().GetResult(); } },
            {3, ()=> { PrintAirLines().GetAwaiter().GetResult(); } },
            {4, ()=> { PrintAirPorts().GetAwaiter().GetResult(); } },
            {5, ()=> { AddNewFlight().GetAwaiter().GetResult(); } },
            {6, ()=> { ListAllFlight().GetAwaiter().GetResult(); } },
            {7, ()=> { ShowUpcomingFlight().GetAwaiter().GetResult(); } },
            {0, ()=> { loopMainMenu = false; } },
        };

        public static JsonFileRepository<List<Airlines>> jsonAirlineFileRepository = new JsonFileRepository<List<Airlines>>(AirlineFilePath);
        public static JsonFileRepository<List<Airport>> jsonAirportFileRepository = new JsonFileRepository<List<Airport>>(AirportFilePath);
        public static JsonFileRepository<List<Flight>> jsonFlightFileRepository = new JsonFileRepository<List<Flight>>(FlightFilePath);

        public static bool loopMainMenu;
        public static int MaxLugWeight { get; set; }
        public static bool BusinessClassAvailable { get; set; }
        public static bool PetsAllowed { get; set; }
        public static bool isRegularAirLine { get; set; }
        public static bool isAirportInternational { get; set; }
        public static string bindedAirLineToAirport { get; set; }

        static async Task Main(string[] args)
        {

            MainMenu();
        }
        static async Task ShowUpcomingFlight()
        {
            var listOfFlight = await jsonFlightFileRepository.ReadAsync();
            new Scoreboard(listOfFlight);


        }

        static async Task ListAllFlight()
        {

            var listFromFlightFile = await jsonFlightFileRepository.ReadAsync();
            Console.WriteLine("\n-----------------------List of flights-----------------------------------");
            listFromFlightFile.ForEach(s => Console.WriteLine(s));
            Console.WriteLine("-------------------------------------------------------------------------\n");
        }
        static async Task AddNewFlight()
        {
            var listOfAirportFlight = await jsonAirportFileRepository.ReadAsync();
            var listOfAirlineFlight = await jsonAirlineFileRepository.ReadAsync();

            int j = 1;
            var listFromAirportFile = await jsonAirportFileRepository.ReadAsync();
            var PrintListOfAirLineFile = await jsonAirlineFileRepository.ReadAsync();
            
            Console.WriteLine();
            Console.WriteLine("Add new flight ");


            Console.WriteLine("Select an Airports: ");
            Console.WriteLine("-------------------------------List Of Airports------------------------------------");
            listFromAirportFile.ForEach(s => {
            
            Console.WriteLine($"{j}. {s.Name}");
            j++;
            });
            Console.WriteLine("-----------------------------------------------------------------------------------");
            
            j = 1;
            int departureAirport;
            int arrivalAirport;
            int mm = 0;

                do
                {
                    if (j > 1) { Console.WriteLine($"Departure and Arrival Airport is similar Or Airport's Airlines don't match each others!\n" +
                        $"Please try differant Airports!\n"); }
                    Console.Write("Departure: ");
                    int.TryParse(Console.ReadLine(), out departureAirport);
                    Console.Write("Arrival:   ");
                    int.TryParse(Console.ReadLine(), out arrivalAirport);
                    j++;
                } while (listOfAirportFlight[departureAirport - 1] == listOfAirportFlight[arrivalAirport - 1] ||
                listOfAirportFlight[departureAirport - 1].BindedAirLineToAirport != listOfAirportFlight[arrivalAirport - 1].BindedAirLineToAirport );
            
            j = 1;
            Console.WriteLine("Select an airline: ");
            Console.WriteLine("-------------------------------List Of AirLines------------------------------------");
            PrintListOfAirLineFile.ForEach(s => {
            Console.WriteLine($"{j}. {s.AirlineName}");
            j++;
            });
            Console.WriteLine("-----------------------------------------------------------------------------------");

            j = 1;
            int userAirline;
            do
            {
                if (j > 1) { Console.WriteLine("Airlines Don't Match Each Others. Please Try Different Airlines!"); }
                Console.Write("\nAirline: ");
                int.TryParse(Console.ReadLine(), out userAirline);
                j++;
            } while (listOfAirportFlight[departureAirport - 1].BindedAirLineToAirport != listOfAirlineFlight[userAirline - 1].AirlineName ||
                listOfAirportFlight[arrivalAirport - 1].BindedAirLineToAirport != listOfAirlineFlight[userAirline - 1].AirlineName);

            j = 1;
            DateTime userDepartureTime;
            do
            {
                if (j > 1) { Console.WriteLine("User departure time is Incorect. please Write correct time"); }
                Console.Write("Departure date and time: ");
                DateTime.TryParse(Console.ReadLine(), out userDepartureTime);
                j++;
            } while (userDepartureTime < DateTime.Now.AddHours(12));

            j = 1;
            double userFlightTime;
            do
            {
                if (j > 1) { Console.WriteLine("Flight time is less than 20 minutes. please write correct time."); }
                Console.Write("Flight time (in hours): ");
                double.TryParse(Console.ReadLine(), out userFlightTime);
                j++;
            } while (userFlightTime < 0.34);

            listOfFlights.Add(new Flight(listOfAirportFlight[departureAirport-1], listOfAirportFlight[arrivalAirport-1], listOfAirlineFlight[userAirline-1], userDepartureTime, userFlightTime));
            
            Console.WriteLine("\nFlight was created\n");

            await jsonFlightFileRepository.CreateAsync(listOfFlights);
        }
        static void MainMenu()
        {
            loopMainMenu = true;
            int userChoice;
            Action actionToInvoke;

            try
            {
                while (loopMainMenu)
                {
                    Console.WriteLine("1. Add new airline \n" +
                        "2. Add new airport \n" +
                        "3. List of airlines \n" +
                        "4. List of airports \n" +
                        "5. Add new flight  \n" +
                        "6. List of flights \n" +
                        "7. Show Upcoming Flights \n" +
                        "0. Exit ");
                    do
                    {
                        Console.Write("please enter the value: ");
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
        static async Task AirlineMainMethod()
        {
            bool isCountOfAirlinesInteger;
            int countOfAirLines;
            int j = 0;
            do
            {
                if (j > 0) { Console.WriteLine("Count of Ailines is not valid. Try again:"); }
                
                Console.Write("How much Airlines?  ");
                isCountOfAirlinesInteger = int.TryParse(Console.ReadLine(), out countOfAirLines);

                for (int i = 0; i < countOfAirLines; i++)
                {
                    Console.WriteLine("--------------------------------------------------------------------------");

                    int ll = 0;
                    string nameOfAirline;
                    do
                    {
                        if (ll > 0) { Console.WriteLine("Incorect Name. Please Try again:");}
                        Console.Write("Name:                                 ");
                         nameOfAirline = Console.ReadLine();
                        ll++;
                    } while (!ValidationHelper.IsNameValid(nameOfAirline));


                     ll = 0;
                    int countOfAircraft;
                    bool isCountOfAircraftInteger;
                    do
                    {
                        if (ll > 0) { Console.WriteLine("Count of aircrafts is not valid. Try again:");}
                        Console.Write("Count of aircrafts:                   ");
                         isCountOfAircraftInteger = int.TryParse(Console.ReadLine(), out countOfAircraft);
                        ll++;
                    } while (countOfAircraft < 0 || !isCountOfAircraftInteger);

                    ll = 0;
                    int ansRegularOrLowCost;
                    do
                    {
                        if (ll > 0) { Console.WriteLine("Incorect Input. Please wirte only 1 or 2."); }

                        Console.Write("Regular(1) / LowCost(2):              ");
                        int.TryParse(Console.ReadLine(), out ansRegularOrLowCost);
                        if (ansRegularOrLowCost == 1)
                        {
                            isRegularAirLine = true;

                            int maxLugWeight;
                            bool isMaxLugWeightInteger;
                            int ii = 0;
                            do
                            {
                                if (ii > 0) { Console.WriteLine("Maximum luggage weight is incorrect. Please wirte correct weight."); }
                                Console.Write("Maximum luggage weight:               ");
                                isMaxLugWeightInteger = int.TryParse(Console.ReadLine(), out maxLugWeight);
                                MaxLugWeight = maxLugWeight;
                                ii++;
                            } while (maxLugWeight < 0 || !isMaxLugWeightInteger);


                            Console.Write("Business class available (y/n):       ");
                            var userBusinessAnswer = Console.ReadLine();
                            if (userBusinessAnswer == "y")
                            {
                                BusinessClassAvailable = true;
                            }
                            else if (userBusinessAnswer == "n")
                            {
                                BusinessClassAvailable = false;
                            }
                            Console.Write("Pets allowed (y/n):                   ");
                            var userPetsAnswer = Console.ReadLine();
                            if (userPetsAnswer == "y")
                            {
                                PetsAllowed = true;
                            }
                            else if (userPetsAnswer == "n")
                            {
                                PetsAllowed = false;
                            }

                            listOfArilines.Add(new Airlines(nameOfAirline, countOfAircraft, isRegularAirLine, maxLugWeight, BusinessClassAvailable, PetsAllowed));

                            await jsonAirlineFileRepository.CreateAsync(listOfArilines);
                            var listFromAirLineFile = await jsonAirlineFileRepository.ReadAsync();
                            listFromAirLineFile.ForEach(s => Console.WriteLine(s));

                        }
                        else if (ansRegularOrLowCost == 2)
                        {
                            isRegularAirLine = false;

                            int maxLugWeight;
                            bool isMaxLugWeightInteger;
                            int ii = 0;
                            do
                            {
                                if (ii > 0) { Console.WriteLine("Maximum luggage weight is incorrect. Please wirte correct weight."); }
                                Console.Write("Maximum luggage weight:               ");
                                isMaxLugWeightInteger = int.TryParse(Console.ReadLine(), out maxLugWeight);
                                MaxLugWeight = maxLugWeight;
                                ii++;
                            } while (maxLugWeight < 0 || !isMaxLugWeightInteger);


                            listOfArilines.Add(new Airlines(nameOfAirline, countOfAircraft, isRegularAirLine, maxLugWeight, false, false));
                            await jsonAirlineFileRepository.CreateAsync(listOfArilines);

                            var listFromAirLineFile = await jsonAirlineFileRepository.ReadAsync();
                            listFromAirLineFile.ForEach(s => Console.WriteLine(s));
                        }
                        //else { Console.WriteLine("Incorect Input. Try again."); }
                        ll++;
                    } while (ansRegularOrLowCost != 2 && ansRegularOrLowCost != 1);

                }
                j++;
            } while (countOfAirLines < 0 || !isCountOfAirlinesInteger);

        }

        static async Task MakeAirportsGreatAgain()
        {
            bool isTrue = true;

            isAirportInternational = true;

            while (isTrue)
            {
                int jj = 0;
                int l = 0;
                string airportcity;
                string airportname;
                do
                {
                    if (l > 0) { Console.WriteLine("Your Name is not correct. please try again");}
                    Console.Write("Enter Name of Airport's City: ");
                    airportcity = Console.ReadLine();
                    l++;
                } while (!ValidationHelper.IsNameValid(airportcity));

                l = 0;
                do
                {
                    if (l > 0) { Console.WriteLine("Your Name is not correct. please try again"); }
                    Console.Write("Enter Name of Airport: ");
                    airportname = Console.ReadLine();
                    l++;
                } while (!ValidationHelper.IsNameValid(airportname));

                Console.Write("is Airport International? y/n: ");
                var answerOfAirport = Console.ReadLine();
                if (answerOfAirport == "y") { isAirportInternational = true; } else if (answerOfAirport == "n") { isAirportInternational = false; }


                l = 0;
                int userAnswerAboutAirlines;
                do
                {
                    if (l > 0) { Console.WriteLine("Incorect Input. Please wirte only 1 or 2.");  }

                    Console.Write("Select existing airlines(1) or add new(2)?: ");
                    int.TryParse(Console.ReadLine(), out userAnswerAboutAirlines);

                    var listFromAirLineForBindingToAirport = await jsonAirlineFileRepository.ReadAsync();

                    if (userAnswerAboutAirlines == 1)
                {
                    Console.WriteLine("-----------------------List of airlines-----------------------");
                    listFromAirLineForBindingToAirport.ForEach(s => {
                        jj++;
                        Console.WriteLine($"{jj}. {s.AirlineName}");
                    });
                    Console.WriteLine("--------------------------------------------------------------");

                    Console.Write("Chose airlines: ");
                    int.TryParse(Console.ReadLine(), out int userChoiceAirlines);
                    bindedAirLineToAirport = listFromAirLineForBindingToAirport[userChoiceAirlines-1].AirlineName;

                }
                else if (userAnswerAboutAirlines == 2)
                {
                    await AirlineMainMethod();

                    listFromAirLineForBindingToAirport = await jsonAirlineFileRepository.ReadAsync();
                    int airLineQty = listFromAirLineForBindingToAirport.Count;

                    Console.WriteLine($"New Airline Has been Created: {listFromAirLineForBindingToAirport[airLineQty-1].AirlineName}. \n" +
                        $"Total Airline in the list: {listFromAirLineForBindingToAirport.Count}");

                    bindedAirLineToAirport = listFromAirLineForBindingToAirport[airLineQty-1].AirlineName;
                }
                    l++;
                } while (userAnswerAboutAirlines != 2 && userAnswerAboutAirlines != 1);


                //else { Console.WriteLine("Incorect Input. Try again."); }

                listOfAirports.Add(new Airport(airportcity, airportname, isAirportInternational, bindedAirLineToAirport));

                Console.Write("do you want to add more Airport? y/n: ");
                var answer = Console.ReadLine();
                if (answer == "y") { isTrue = true; } else if (answer == "n") { isTrue = false; }
            }

            await jsonAirportFileRepository.CreateAsync(listOfAirports);
            var listFromAirportFile = await jsonAirportFileRepository.ReadAsync();

            listFromAirportFile.ForEach(s => Console.WriteLine(s));

            Logger.Log("Program.MakeAirportsGreatAgain method was called", $" Printing all Airports");

        }

        static async Task PrintAirLines()
        {
            var PrintListOfAirLineFile = await jsonAirlineFileRepository.ReadAsync();
            Console.WriteLine("-------------------------------List Of AirLines------------------------------------");
            PrintListOfAirLineFile.ForEach(s => {
                Console.WriteLine($"Airline: {s.AirlineName}");
            });
            Console.WriteLine("-----------------------------------------------------------------------------------");

            Logger.Log("Program.PrintAirLines method was called", $" Printing all AirLines");

        }
        static async Task PrintAirPorts()
        {
            var listFromAirportFile = await jsonAirportFileRepository.ReadAsync();
            Console.WriteLine("-------------------------------List Of Airports------------------------------------");
            listFromAirportFile.ForEach(s => Console.WriteLine(s));
            Console.WriteLine("-----------------------------------------------------------------------------------");

            Logger.Log("Program.PrintAirPorts method was called", $" Printing all Airport");
        }

    }
}

