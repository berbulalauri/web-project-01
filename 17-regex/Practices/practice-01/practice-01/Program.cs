using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var escapedSymbols = new List<string>
            {
                Regex.Escape("&#160;")
            };
            var input = "What&#160;is&#160;your&#160;name&#160;&#38;&#160;adress&#63;";
            Console.WriteLine(input);

            foreach (var esc in escapedSymbols)
            {
                input = Regex.Replace(input, esc, " ");
            }
            input = Regex.Replace(input, "&#63;", "?");
            input = Regex.Replace(input, "&#38;", "&");

            Console.WriteLine(input);

        }
    }
}
