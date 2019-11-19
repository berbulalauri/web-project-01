using System;
using System.Diagnostics;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowGCstats();
            Console.WriteLine($"max generation of battery {GC.MaxGeneration}");
            //Console.WriteLine($"total memory used {GC.GetTotalMemory(false)/1000} kb");
            
            Battery battery = new Battery("duracell", 220);
            Console.WriteLine($"generation of battery {GC.GetGeneration(battery)}");
            Console.WriteLine($"total memory used {GC.GetTotalMemory(false) / 1000} kb");
            
            object[] bigArray = new object[10000000];
            for (int i = 0; i < bigArray.Length; i++)
            {
                bigArray[i] = new object();
            }
            Console.WriteLine($"generation of bigArray {GC.GetGeneration(bigArray)}");
            ShowGCstats();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bigArray = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();

            sw.Stop();
            Console.WriteLine($"elapsed time for GC.collect: {sw.Elapsed.TotalSeconds}");

            ShowGCstats();



        }
        static void ShowGCstats()
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"Total memory used: {GC.GetTotalMemory(false)/1000} kb");
            Console.WriteLine($"generation 0 Cleaned {GC.CollectionCount(0)} times");
            Console.WriteLine($"generation 1 Cleaned {GC.CollectionCount(1)} times");
            Console.WriteLine($"generation 2 Cleaned {GC.CollectionCount(2)} times");
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
    class Battery
    {
        public string Name { get; set; }
        public int CurrentCharge { get; set; }
        public Battery(string name, int currentCharge)
        {
            Name = name;
            CurrentCharge = currentCharge;
        }

    }
}
