using System;
using System.Globalization;
using System.Text;
using System.Text.Encodings;

namespace practice_03
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("input Number to conver to currency value (for ex.: 2516453.397 ): ");
            var strPart1 = Console.ReadLine();
            var convertDecimal = Convert.ToDecimal(strPart1);
            string yourValue = (convertDecimal / 1m).ToString("C2");
            Console.WriteLine(yourValue);

            Console.WriteLine("input Number to conver to Exponential value (for ex.: 2300000.35 ): ");
            var strPart2 = Console.ReadLine();
            double.TryParse(strPart2, out double exDoublenumber);
            Console.WriteLine("{0:e}", exDoublenumber);

            Console.WriteLine("input Number to conver to percent value (for ex.: 45.86 ): ");
            var strPart3 = Console.ReadLine();
            double.TryParse(strPart3, out double percentNumber);
            Console.WriteLine("percentage: {0:0.00}%", percentNumber);

            Console.WriteLine("input String to conver to Hexadecimal value (for ex.: house ): ");
            var strPart4 = Console.ReadLine();

            byte[] ba = Encoding.Default.GetBytes(strPart4);
            var hexString = BitConverter.ToString(ba);
            Console.WriteLine($"{hexString}\n{hexString.Replace("-", "")}");

        }
    }
}

/*double test = double.Parse("1.50E-15", CultureInfo.InvariantCulture);
Console.WriteLine(test);
            CultureInfo cultureInfo = new CultureInfo("ka-GE");
var geoStyle = string.Format(cultureInfo, "{0:n}", 25437.5342);
Console.WriteLine("\n\a");
            Console.WriteLine("{0:c}", 23.33);
            Console.WriteLine("{0:e}", 230000000.35);
            Console.WriteLine("{0:f1}", 2333.335);
            Console.WriteLine("{0:g}", 2333.322395);
            Console.WriteLine("{0:n}", 2516453.3972235);
            Console.WriteLine("{0:X2}", 251645396);
            Console.WriteLine("Georian Style: " + geoStyle);
*/