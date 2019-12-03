using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace practice_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Choose the operation: ");
            Console.WriteLine("1. Array of number: ");
            Console.WriteLine("2. Array of strings: ");

            int.TryParse(Console.ReadLine(), out int elect);
            var callMethod = new CaseMethods();

            switch (elect){
                case 1:
                    callMethod.Case1();
                break;
                case 2:
                    callMethod.Case2();
                    break;
                default:

                break;
            }
        }
    }
    public class CaseMethods
    {
        public void Case1()
        {
            try
            {
                Console.WriteLine("Please Write the line (ONLY NUMBERS): ");
                var userInput = Console.ReadLine();
                List<double> listOfDouble = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => double.TryParse(x, out double val) ? val : 1).ToList();
                CountEqualValues<double> point2 = new CountEqualValues<double>(listOfDouble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Case2()
        {
            try
            {
                Console.WriteLine("Please Write the line (STRING / NUMBERS): ");
                var userInput = Console.ReadLine();
                List<string> listOfDouble = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                CountEqualValues<string> point2 = new CountEqualValues<string>(listOfDouble);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    class CountEqualValues<T>
    {
        public CountEqualValues(List<T> list)
        {
            try
            {
                var query = list.GroupBy(x => x)
                  .Where(g => g.Count() >= 1)
                  .Select(y => new { Element = y.Key, Counter = y.Count() })
                  .ToList();

                foreach (var items in query)
                {
                    Console.WriteLine($" {items.Element} has been called {items.Counter} times");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
