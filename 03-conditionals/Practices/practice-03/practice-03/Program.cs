using System;

class MainClass
{

    public enum datapicker
    { January = 1, February = 2, March = 3, April = 4, May = 5, June = 6, July = 7, august = 8, September = 9, October = 10, November = 11, December = 12 }

    public static void Main(string[] args)
    {
        Console.WriteLine("Input the number of month:");
        var userInput = Console.ReadLine();
        var isParsed = int.TryParse(userInput, out int numberFromInput);
        var line1 = string.Empty;

        if (isParsed)
        {
            var monthPlaceHolder = ((datapicker)numberFromInput).ToString();
            switch (numberFromInput)
            {
                case 1:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 2:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 3:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 4:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 5:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 6:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 7:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 8:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 9:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 10:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 11:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                case 12:
                    line1 = $"Month: {monthPlaceHolder}";
                    break;
                default:
                    line1 = $"Month {numberFromInput} does not exists";
                    break;
            }
            Console.WriteLine(line1);

        }
        else
        {
            Console.WriteLine("incorect format");
        }




    }
}