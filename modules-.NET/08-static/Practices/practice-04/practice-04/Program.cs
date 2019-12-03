using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // var commentedString = ExtensionMethods.RemoveSecondWordsPart(userInput);
            Console.WriteLine("enter you numbers: ");
            var userInput = Console.ReadLine();
            var commentedString = userInput.RemoveSecondWordsPart();
            Console.WriteLine(commentedString);
        }
    }
    public static class ExtensionMethods
    {
  
        public static string RemoveSecondWordsPart(this string source)
        {
            int[] mm = new int[2];
            int i = 0;
            char[] spearator = { '/', ' ' };
            String[] strlist = source.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            foreach (String s in strlist)
            {
                int.TryParse(s, out int strOutput);
                mm[i] = strOutput;
                i++;
            }
            if (mm[0] % mm[1] != 0 )
            {
                    for (int k = 2; mm[0] > k;k++)
                    {
                        while((mm[0] % k) == 0 && (mm[1] % k) == 0)
                        {
                        //Console.WriteLine(mm[0] + "  " + mm[1] + "  "+k);
                            mm[0] = mm[0] / k;
                            mm[1] = mm[1] / k;
                        }
                    }
                    return $"{ mm[0].ToString() } / {mm[1].ToString()}";
            } 
            else {
                    return $"simple result: { (mm[0] / mm[1]).ToString() }";
                 }

            return "";
        }
    }

}
