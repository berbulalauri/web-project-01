using System;
using System.IO;
namespace myhomework
{
    public class Resources
    {
        public int id { get; set; }
        public Resources(int x)
        {
            id = x;
        }
        ~Resources()
        {
            Console.WriteLine($"Resource {id} was created");
            Console.ReadKey();
        }
    }

    class Procedure
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Important notice: Some version of .NET Core can't corectlly compile GC destructor.\nin order to see the result. Please compile in only .NET Framework or copy code to repl.it \n");
            // Console.WriteLine($"max generation of resource {GC.MaxGeneration}");
            int x = 1; // int x = GC.MaxGeneration;

            Resources resources = new Resources(x);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

    }

}
