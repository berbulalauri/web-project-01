using System;

class MainClass
{

    public enum datapicker
    {
        exit = 0,
        month = 1,
        day = 2,
        year = 3
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("======= Menu ======");
        Console.WriteLine("1. The current month");
        Console.WriteLine("2. The current day of week");
        Console.WriteLine("3. The current year");
        Console.WriteLine("0. Exit");
        Console.WriteLine("===================");

        Console.WriteLine("Select Menu number:");
        var userInput = Console.ReadLine();
        var isParsed = int.TryParse(userInput, out int numberFromInput);
        var line1 = string.Empty;
        var line2 = string.Empty;

        if (isParsed)
        {
            // result = ((datapicker)numberFromInput).ToString();

            switch (numberFromInput)
            {

                case (int)datapicker.exit:
                    line2 = $"exiting now...";
                    break;
                case (int)datapicker.month:
                    line1 = $"The current date: {DateTime.Now.ToString("dd.MM.yyyy h:mm:ss")}";
                    line2 = $"Month: {DateTime.Now.ToString("MM")}";
                    break;
                case (int)datapicker.day:
                    line1 = $"The current date: {DateTime.Now.ToString("dd.MM.yyyy h:mm:ss")}";
                    line2 = $"day: {DateTime.Now.ToString("dddd")}";
                    break;
                case (int)datapicker.year:
                    line1 = $"The current date: {DateTime.Now.ToString("dd.MM.yyyy h:mm:ss")}";
                    line2 = $"year: {DateTime.Now.ToString("yyyy")}";
                    break;
                default: // optional. can be removed
                    line2 = $"please select from menu number";
                    break;
            }
            Console.WriteLine(line1);
            Console.WriteLine(line2);

        }
        else
        {
            Console.WriteLine("incorect format");
        }




    }
}