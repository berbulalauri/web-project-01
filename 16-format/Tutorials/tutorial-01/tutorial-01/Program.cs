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
            CultureInfo cultureInfo = new CultureInfo("ka-GE");
            DateTime dt = DateTime.Now;
            Console.WriteLine("Current date: {0,0:d} Number {1,10:F}", dt, 2);
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.NumberFormat.CurrencySymbol = "₾";
            culture.NumberFormat.CurrencyDecimalSeparator = ",";
            culture.NumberFormat.CurrencyGroupSeparator = " ";
            decimal number = 100000;
            string bekamoney = number.ToString("c", culture);
            Console.WriteLine(bekamoney);
            
            //Console.WriteLine(date.ToShortDateString());
        }
    }
}
