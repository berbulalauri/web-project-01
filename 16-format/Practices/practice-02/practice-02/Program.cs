using System;
using System.Collections;
using System.Globalization;

namespace practice_02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool whileLoop = true;

            while (whileLoop)
            {
                menuPrinter();
                Console.WriteLine("Select your choose: ");
                int.TryParse(Console.ReadLine(), out int optionSelector);
                switch (optionSelector)
                {
                    case 1:
                        DateTime currentDate = DateTime.Now;
                        DateTimeFormatSelector(currentDate);
                        break;
                    case 2:
                        customDateInputMethod();
                        break;
                    case 3:
                        whileLoop = false;
                        break;
                    default:
                        break;
                }
            }


        }
        public static void menuPrinter()
        {
            Console.WriteLine("=========================MENU===========================");
            Console.WriteLine("1. Use current date");
            Console.WriteLine("2. Enter the date");
            Console.WriteLine("3. Exit");
            Console.WriteLine("========================================================");

        }

        public static void customDateInputMethod()
        {
            Console.WriteLine("Enter the year:");
            int.TryParse(Console.ReadLine(), out int yearInt);

            Console.WriteLine("Enter the month:");
            int.TryParse(Console.ReadLine(), out int monthInt);
            Console.WriteLine("Enter the day:");
            int.TryParse(Console.ReadLine(), out int dayInt);
            Console.WriteLine("Enter the hour:");
            int.TryParse(Console.ReadLine(), out int hourInt);
            Console.WriteLine("Enter the minutes:");
            int.TryParse(Console.ReadLine(), out int minuteInt);
            Console.WriteLine("Enter the seconds:");
            int.TryParse(Console.ReadLine(), out int secondInt);

            var dateTimeStr = $"{monthInt}/{dayInt}/{yearInt} {hourInt}:{minuteInt}:{secondInt}";
            DateTime dateTime = DateTime.Parse(dateTimeStr);
            Console.WriteLine($"Your date is: {dateTime}");

            DateTimeFormatSelector(dateTime);

            // DateTime customDate = "06/22/1916 3:20:14 PM"; // {monthInt}/{dayInt}/{yearInt} {hourInt}:{minuteInt}:{secondInt} //5, 2019 10:05:00
        }
        public static void DateTimeFormatSelector(DateTime dateTime)
        {
            CultureInfo iv = CultureInfo.InvariantCulture;
            bool dateSelector = true;
            while (dateSelector)
            {
                Console.WriteLine($"Available formats: ");
                customDateOptionSelector();
                Console.WriteLine("Select your choose: ");
                int.TryParse(Console.ReadLine(), out int optionDateFormatSelector);
                Console.WriteLine("\n================================================");
                switch (optionDateFormatSelector)
                {
                    case 1:
                        Console.WriteLine(dateTime.ToString("dd.MM.yyyy hh:mm:ss"));
                        break;
                    case 2:
                        Console.WriteLine("{0:U}\t", dateTime);
                        break;
                    case 3:
                        Console.WriteLine(dateTime.ToString("f", iv));
                        break;
                    case 4:
                        Console.WriteLine(dateTime.ToString("F", iv));
                        break;
                    case 5:
                        Console.WriteLine(dateTime.ToString("g", iv));
                        break;
                    case 6:
                        Console.WriteLine(dateTime.ToString("G", iv));
                        break;
                    case 7:
                        Console.WriteLine(dateTime.ToString("MM.dd"));
                        break;
                    case 8:
                        Console.WriteLine("{0:u}", dateTime);
                        break;
                    case 9:
                        Console.WriteLine("{0:r}", dateTime);
                        break;
                    case 10:
                        Console.WriteLine("{0:s}", dateTime);
                        break;
                    case 11:
                        Console.WriteLine("{0:t}", dateTime);
                        break;
                    case 12:
                        Console.WriteLine("{0:T}", dateTime);
                        break;
                    case 13:
                        Console.WriteLine("{0:u}", dateTime);
                        break;
                    case 14:
                        Console.WriteLine(dateTime.ToString("U", iv));
                        break;
                    case 15:
                        Console.WriteLine(dateTime.ToString("yyyy.MM"));
                        break;
                    case 0:
                        dateSelector = false;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("================================================\n");

            }

        }
        public static void customDateOptionSelector()
        {
            Console.WriteLine("1. Short date pattern");
            Console.WriteLine("2. Long date pattern");
            Console.WriteLine("3. Full date/ time pattern(short time).");
            Console.WriteLine("4. Full date/ time pattern(long time).");
            Console.WriteLine("5. General date/ time pattern(short time).");
            Console.WriteLine("6. General date/ time pattern(long time).");
            Console.WriteLine("7.  Month / day pattern.");
            Console.WriteLine("8. Round - trip date / time pattern.");
            Console.WriteLine("9. RFC1123 pattern.");
            Console.WriteLine("10.Sortable date/ time pattern.");
            Console.WriteLine("11.Short time pattern.");
            Console.WriteLine("12.Long time pattern.");
            Console.WriteLine("13.Universal sortable date / time pattern.");
            Console.WriteLine("14.Universal full date / time pattern.");
            Console.WriteLine("15.Year month pattern.");
            Console.WriteLine("0. EXIT FROM HERE");
        }
    }
}
