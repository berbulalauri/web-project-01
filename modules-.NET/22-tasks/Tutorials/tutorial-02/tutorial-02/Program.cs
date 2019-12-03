using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace tutorial_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int breakIndex = 3;
            var random = new Random();
            var locker = new object();

            Parallel.For(1, 20, (i, state) => {
                Console.WriteLine($"Begining Iteration {i}");

                lock (locker)
                {
                    var delay = random.Next(500, 3000);
                    Task.Delay(delay).GetAwaiter().GetResult();

                }

                if (i == breakIndex)
                {
                    Console.WriteLine($"Breaking Iteration {i}");
                    state.Break();
                }
                Console.WriteLine($"Compliting Iteration {i}");
            });
        }
    }
}
