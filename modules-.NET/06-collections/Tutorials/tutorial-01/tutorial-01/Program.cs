using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Write the line: ");
            var userInput = Console.ReadLine();
            var result = CompleteTutorial1(userInput);
            Console.WriteLine(result);
        }

        static string CompleteTutorial1(string userInput)
        {
            string sortedString = String.Empty;

            List<double> listOfDouble = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Select(
                x => double.TryParse(x, out double val) ? val : 1).ToList();

            var orderList = listOfDouble.OrderByDescending(x => x).ToList();
            orderList.ForEach(x => sortedString += $"{x} ");

            var multiplicationResult = orderList.FirstOrDefault() * orderList.LastOrDefault();

            return ComposeStringResult(userInput,sortedString, multiplicationResult);
        }
        static string ComposeStringResult(string inputStirng, string sortedString, string resultOfMultiplication)
        {
            var result = $"Input String: {inputStirng}{Environment.NewLine}";
            result += $"sorted String: {sortedString}{Environment.NewLine}";
            result += $"Multiplication String: {resultOfMultiplication}{Environment.NewLine}";
            return result;
        }
        static string ComposeStringResult(string inputStirng, string sortedString, double resultOfMultiplication)
        {
            var result = $"Input String: {inputStirng}{Environment.NewLine}";
            result += $"sorted String: {sortedString}{Environment.NewLine}";
            result += $"Multiplication String: {resultOfMultiplication}{Environment.NewLine}";
            return result;
        }
    }
}
