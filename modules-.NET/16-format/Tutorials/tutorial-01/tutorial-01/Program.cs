using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            CultureInfo cultureInfo = new CultureInfo("ka-GE");
            Console.Write("{0,0:d}\t",date);
            Console.Write("{0,10:D}\t",date);
            Console.Write("{0,20:yyyy}\t",date);
            Console.Write("{0,40:U}\t",date);

            var geoStyle = string.Format(cultureInfo, "{0:n}",25437.5342);

            Console.WriteLine("\n\a");
            Console.WriteLine("{0:c}",23.33);
            Console.WriteLine("{0:e}",230000000.35);
            Console.WriteLine("{0:f1}",2333.335);
            Console.WriteLine("{0:g}",2333.322395);
            Console.WriteLine("{0:n}",2516453.3972235);

            Console.WriteLine("{0:X2}",251645396);
            Console.WriteLine("Georian Style: "+geoStyle);


/*            CultureInfo cultureInfo = new CultureInfo("ka-GE");
            DateTime dt = DateTime.Now;
            Console.WriteLine("Current date: {0,0:d} Number {1,10:F}", dt, 2);
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.CurrencySymbol = "₾";
            culture.NumberFormat.CurrencyDecimalSeparator = ",";
            culture.NumberFormat.CurrencyGroupSeparator = " ";
            decimal number = 100000;
            string bekamoney = number.ToString("c", culture);
            Console.WriteLine(bekamoney);
*/            
            //Console.WriteLine(date.ToShortDateString());
        }
    }
}
