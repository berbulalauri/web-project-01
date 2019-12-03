using System;
using System.Collections.Generic;
using System.Text;
using workshop_02;

namespace workshop2
{
    class Flight
    {
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public Airlines FlightAirline { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public double FlightTime { get; set; }

        //listOfFlights.Add(new Flight(listOfAirports[departureAirport - 1].Name, listOfAirports[arrivalAirport - 1].Name, listOfArilines[userAirline - 1].AirlineName, userDepartureTime, userFlightTime));

        public Flight(Airport departureAirport, Airport arrivalAirport, Airlines flightAirline, DateTime departureDateTime, double flightTime)
        {
                DepartureAirport = departureAirport;
                ArrivalAirport = arrivalAirport;
                FlightAirline = flightAirline;
                DepartureDateTime = departureDateTime;
                FlightTime = flightTime;
        }
        public override string ToString()
        {
            return  $"Departure: International Airport in {DepartureAirport.City}: {DepartureAirport.Name}\n" +
                    $"Arrival:   International Airport in {ArrivalAirport.City}: {ArrivalAirport.Name}\n" +
                    $"Departure time: {DepartureDateTime}\n" +
                    $"Airline: {FlightAirline.AirlineName}\n" +
                    $"Flight Time: {FlightTime}\n";
        }
    }
}

