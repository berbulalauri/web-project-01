using System;
using System.Threading;
namespace Program
{
    class Program
    {
        static Thread[] thread = new Thread[5];
        static Semaphore semaphore = new Semaphore(2, 2);
        static void ShowThreadInfo()
        {
            Console.WriteLine("{0} is waiting", Thread.CurrentThread.Name);
            semaphore.WaitOne();
            Console.WriteLine("{0} begins!", Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            Console.WriteLine("{0} is releasing...", Thread.CurrentThread.Name);
            semaphore.Release();
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                thread[i] = new Thread(ShowThreadInfo);
                thread[i].Name = "Thread " + i;
                thread[i].Start();
            }
        }
    }
}