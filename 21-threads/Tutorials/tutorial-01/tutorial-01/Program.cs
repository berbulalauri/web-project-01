using System;
using System.Threading;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteDot);
            thread.IsBackground = true;
            thread.Start();
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write("-");
                    Thread.Sleep(10);
                    if (i > 500)
                    {
                        thread.Abort();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"something went wrong !: {ex.Message}");
            }
        }

        static void WriteDot()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write(".");
                Thread.Sleep(10);
            }
        }
    }
}
