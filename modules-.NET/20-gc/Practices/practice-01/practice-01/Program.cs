using System;
using System.Diagnostics;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BASIC INFORMATION ABOUT THE SYSTEM:");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"OS: {System.Environment.OSVersion} - .Net Framework: {Environment.Version}");

            Console.WriteLine("\nGC INFORMATION:");
            Console.WriteLine("---------------------------------------------------------------");
            Motorcycle motorcycle = new Motorcycle("yamaha", 135);
            Console.WriteLine($"Count of bytes in heap: {GC.GetTotalMemory(false)} Max Generation: {GC.MaxGeneration}");

            motorcycle.printer();
            Console.WriteLine($"Generation of object yamaha: {GC.GetGeneration(motorcycle)}");
            Console.WriteLine($"garbbige Collection ..");


            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            Console.WriteLine($"New generation of object: {GC.GetGeneration(motorcycle)}");

            //sw.Stop();
            //Console.WriteLine($"elapsed time for GC.collect: {sw.Elapsed.TotalSeconds}");
        }


    }
    public class Motorcycle
    {
        public static string Name { get; set; }
        public static int CurrentSpeed { get; set; }
        public Motorcycle(string name, int currentSpeed)
        {
            Name = name;
            CurrentSpeed = currentSpeed;
        }
        public void printer()
        {
            Console.WriteLine($"{Name} is going with {CurrentSpeed} mph");
        }

    }
}
