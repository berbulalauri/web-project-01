using System;

class MainClass {
  public static void Main (string[] args) {
  
    Console.WriteLine ("input year: ");
     int year = int.Parse(Console.ReadLine());
     Console.WriteLine("Is {0} a leap year? {1}",year, DateTime.IsLeapYear(year));

  }
}
