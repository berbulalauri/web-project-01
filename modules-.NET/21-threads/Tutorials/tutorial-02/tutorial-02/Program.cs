
using System;
using System.Threading;

namespace tutorial_02
{
    class Program
    {
        static int count = 0;
        static object locker = new object();
        static void Main(string[] args)
        {
            Thread thread = new Thread(Proceed);
            thread.Start(1);

            Proceed(2);

        }
        static void Proceed(object diff)
        {
            for (int i = 0; i < 50; i++)
            {
                lock (locker)
                {
                    count += (int)diff;
                    Console.WriteLine($"ThreadID is {Thread.CurrentThread.ManagedThreadId} Count is {count}");
                    Thread.Sleep(50);
                }
            }
        }
    }
}


/*
using System;
using System.Threading;
namespace tutorial02
{
    class Program
    {
        static int count = 0;
        static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
            Thread[] thread = new Thread[100];
            for (int i = 0; i < thread.Length; i++)
            {
                thread[i] = new Thread(Proceed);
                thread[i].Start(1);
            }
            static void Proceed(object numberOfThread)
            {
                while (true)
                {
                    mutex.WaitOne();
                    var temp = count;
                    Console.WriteLine($"Thread {numberOfThread} is here reading");
                    Thread.Sleep(1000);
                    count = temp + 1;
                    Console.WriteLine($"Thread {numberOfThread} is here incremented to {count}");
                    Thread.Sleep(1000);
                    mutex.ReleaseMutex();
                }
            }
            //thread.Start(1);
            // Proceed(2);
        }
    }
}



 */
