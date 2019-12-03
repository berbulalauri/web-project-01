using System;
using System.Text.Encodings;

namespace practice_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "It is â t€st";

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(text);
            Console.Write("Byte Code: ");
            foreach (var items in bytes)
            {
                Console.Write($"{items} ");
            }
            Console.WriteLine();

            string toAscii = System.Text.Encoding.ASCII.GetString(bytes);
            
            Console.WriteLine($"ASCII: {toAscii}");
            Console.WriteLine($"UTF8: {text}");


        }
    }
}
