using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter some word: ");
            var userInput = Console.ReadLine();

            var pattern = "^[A-a][a-z]+g$";

            Regex regex = new Regex(pattern);

            Console.WriteLine(regex.IsMatch(userInput) ? "validated" :"not validated");
        }
    }
}
