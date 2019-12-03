using System;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var someString = "here example";
            var commentedString = someString.RemoveSecondWordsPart();

            Console.WriteLine(commentedString);
        }

    }
    public static class ExtensionMethods
    {
        public static string AddHtmlComment(this string currentString)
        {
            return $"<-- {currentString}-->";
        }
        public static string CapitalizeFirstLetter(this string source)
        {
            if (!string.IsNullOrWhiteSpace(source))
            {
                return $"{char.ToUpper(source[0])}{source.Substring(1, source.Length-1)}"; 
            }
            return "";
        }
        public static string RemoveSecondWordsPart(this string source)
        {
            if (!string.IsNullOrWhiteSpace(source))
            {
                return $"{source.Substring(0,source.Length/2)}"; 
            }
            return "";
        }


    }

}
