using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var escapedSymbols = new List<string>
            {
                Regex.Escape("\n"),
                Regex.Escape("\t")
            };

            var input = "here we are \n \t we need to make it without \n sssss";
            Console.WriteLine(input);

            foreach (var esc in escapedSymbols)
            {
                input = Regex.Replace(input, esc, string.Empty);
            }

            Console.WriteLine(input);

/*
            var userInput = Console.ReadLine();

            var pattern = "^[A-a][a-z]+g$";

            Regex regex = new Regex(pattern);

            Console.WriteLine(regex.IsMatch(userInput) ? "validated" : "not validated");*/
        }
    }
}
