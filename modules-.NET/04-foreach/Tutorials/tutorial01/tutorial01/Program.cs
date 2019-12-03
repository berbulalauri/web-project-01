using System;

namespace tutorial01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input first number: ");
            var firstInput = Console.ReadLine();
            var parsingResult = int.TryParse(firstInput, out var firstValue);

            if (!parsingResult)
            {
                Console.WriteLine("Incorect Input... ");
                return;
            }
            Console.WriteLine("please input second number: ");
            var secondInput = Console.ReadLine();
            parsingResult = int.TryParse(secondInput, out var secondValue);

            if (!parsingResult)
            {
                Console.WriteLine("Incorect Input... ");
                return;
            }
            if (firstValue > secondValue)
            {
                Console.WriteLine("range can't be calculated");
            }
            for (int i = firstValue + 1; i < secondValue; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
