using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List_Methods_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Names = new List<string>();
            Names.Add("milk");
            Names.Add("cheese");
            Names.Add("tea");
            Names.Add("apple");

            Console.WriteLine("=============================================== ");
            foreach (string Name in Names)
            {
                Console.WriteLine(Name);
            }
            Console.WriteLine("===============================================n");
            
            bool whilecheck = true;
            while (whilecheck)
            {
                Console.WriteLine("Please enter the name: ");
                var newUserInput = Console.ReadLine();

                if (newUserInput == "exit") { whilecheck = false; }
                else
                {
                    Names = Names.ConvertAll(d => d.ToLower());
                    var nameChecker = Names.Contains($"{newUserInput}");
                    if (!nameChecker)
                    {
                        Names.Add($"{newUserInput}");
                        Names = Names.ConvertAll(d => d.ToLower());

                        Console.WriteLine("=============================================== ");
                        foreach (string Name in Names) { Console.WriteLine(Name); }
                        Console.WriteLine("=============================================== ");

                    } else { Console.WriteLine($"{newUserInput} already exists in array"); }
                }
            
            }



        }
    }
}