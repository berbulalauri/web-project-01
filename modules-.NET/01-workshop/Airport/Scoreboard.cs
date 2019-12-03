using System;
using System.Collections.Generic;
using System.Text;
using workshop_02;

namespace workshop2
{
    class Scoreboard
    {


        public Scoreboard(List<Flight> flights)
        {
            int increseDateTimeValue = 300;
            DateTime increasedDateTime = DateTime.Now.AddHours(increseDateTimeValue);

            string nameSaver ="";
            int userInput = 0;
            string departTime;
            string arrivalTime;
            Dictionary<int, (string, string,DateTime,double, string, string)> dict = new Dictionary<int, (string, string, DateTime,double, string, string)>();
            List<string> mylist = new List<string>();

            int i = 0;
            Console.WriteLine("--------------------------------------------------------------");
            flights.ForEach(s => {
                dict.Add(i,(s.DepartureAirport.City, s.DepartureAirport.Name, s.DepartureDateTime, s.FlightTime, s.ArrivalAirport.City, s.ArrivalAirport.Name));
                i++;
            });

            i = 0;
            flights.ForEach(s => {
                if (nameSaver != s.DepartureAirport.Name)
                {
                    Console.WriteLine($"{i + 1}. International Airport In {s.DepartureAirport.City}: {s.DepartureAirport.Name}");
                    i++;
                    mylist.Add(s.DepartureAirport.Name);
                }
                nameSaver = s.DepartureAirport.Name;
            });

            Console.Write("Check Departure: ");
            int.TryParse(Console.ReadLine(), out int custUserInput);

            int mm = 1;
            flights.ForEach(s => {

                if (mylist[custUserInput - 1] == s.DepartureAirport.Name)
                {
                    userInput = mm;
                }
                mm++;
            });

            i = 0;
            Console.WriteLine(
                "\n\n| ARRIVAL                      | DEPARTURE TIME | ARRIVAL TIME |\n" +
                "| ................................................................ | ");


            flights.ForEach(s => {

                if (dict[userInput-1].Item2 == dict[i].Item2)
                {
                    if (dict[i].Item3 < increasedDateTime)
                    {
                        DateTime mm = dict[i].Item3;
                        DateTime mmx = mm.AddHours(dict[i].Item4);
                        departTime = mm.ToString("MM/dd/yyyy HH:mm");
                        arrivalTime = mmx.ToString("MM/dd/yyyy HH:mm");
                        Console.WriteLine($"| {dict[i].Item6} | {departTime}          | {arrivalTime}");
                    }
                }
                i++;
            });


        Logger.Log("Airlines.Scoreboard method was called", $" Printing all Scoreboard", $"Departure Airport: {dict[1].Item1} Arrival Airport: {dict[1].Item2}; IsInternational: {dict[1].Item3}; BindedAirLineToAirport: {dict[1].Item4} ");
        }
        public string ShowUpcomingFlights(Airport departureAirport)
        {
            return "";
        }
    }
}
