using System;

class MainClass
{

    public enum Rainbow
    {
        red = 1,
        orange = 2,
        yellow = 3,
        green = 4,
        blue = 5,
        indigo = 6,
        violet = 7
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        var userInput = Console.ReadLine();
        int numberFromInput;
        var isParsed = int.TryParse(userInput, out numberFromInput);
        var result = string.Empty;

        if (isParsed)
        {
            // result = ((Rainbow)numberFromInput).ToString();

            switch (numberFromInput)
            {

                case (int)Rainbow.red:
                    result = $"color: {Rainbow.red.ToString()}";
                    break;
                case (int)Rainbow.orange:
                    result = $"color: {Rainbow.orange.ToString()}";
                    break;
                case (int)Rainbow.yellow:
                    result = $"color: {Rainbow.yellow.ToString()}";
                    break;
                case (int)Rainbow.green:
                    result = $"color: {Rainbow.green.ToString()}";
                    break;
                case (int)Rainbow.blue:
                    result = $"color: {Rainbow.blue.ToString()}";
                    break;
                case (int)Rainbow.indigo:
                    result = $"color: {Rainbow.indigo.ToString()}";
                    break;
                case (int)Rainbow.violet:
                    result = $"color: {Rainbow.violet.ToString()}";
                    break;
                default:
                    Console.WriteLine("color is white");
                    break;
            }
            Console.WriteLine(result);

        }
        else
        {
            Console.WriteLine("incorect format");
        }




    }
}