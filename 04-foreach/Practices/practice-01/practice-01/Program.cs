using System;

class MainClass
{

    public static void Main(string[] args)
    {
        int i = 0;
        bool trueorfalse = true;
        while (trueorfalse)
        {
            Console.WriteLine("Input the number:");
            var userInput = Console.ReadLine();
            var isParsed = int.TryParse(userInput, out int numberFromInput);
            if (isParsed)
            {
                if (numberFromInput != 0)
                {
                    i++;
                }
                else { trueorfalse = false; }
            }
            else
            {
                trueorfalse = true;
            }
        }
        Console.WriteLine("Count of entered numbers before zero: " + i);
    }
}

