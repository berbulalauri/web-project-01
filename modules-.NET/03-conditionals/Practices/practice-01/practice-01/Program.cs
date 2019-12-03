using System;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("input number: ");
        var userInput = Console.ReadLine();
        var isParsed = int.TryParse(userInput, out int numberFromInput);
        if (isParsed)
        {
            if (numberFromInput % 5 == 0)
            {
                if (numberFromInput % 10 == 0)
                {
                    Console.WriteLine("Number is divisible by 5 and 10");
                }
                else { Console.WriteLine("Number is divisible only by 5"); }
            }
            else { Console.WriteLine("Number is NOT divisible by 5 or 10"); }

        }
        else { Console.WriteLine("Incorect Format! "); }

    }
}