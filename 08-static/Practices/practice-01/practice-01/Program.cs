using System;

namespace practice_01_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number: ");
            var userInput = Console.ReadLine();
            long.TryParse(userInput, out long userOutput);
            long mymyintoutput = userOutput.myintOutput();
            Console.WriteLine($"factorial of {userOutput}! is {mymyintoutput}");
        }
    }
    public static class ExtensionMethods
    {
        public static long myintOutput(this long source)
        {
            long result = 1;
            for (int i = 0; i < source; i++)
            {
                result = result * (source - i);
            }
            return result;
        }
    }

}
