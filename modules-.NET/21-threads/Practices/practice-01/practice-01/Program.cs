using System;
using System.Threading;

class PrintNumbers
{
    public void Job()
    {
        Console.WriteLine("-> Primary is executing PrintNumbers()");
        Console.Write("Your numbers: ");
        for (int X = 1; X <= 10; X++)
        {
            Console.Write(X + " ");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }
}
public class Program
{
    public static void Main()
    {
        PrintNumbers obj = new PrintNumbers();

        Thread thr = new Thread(new ThreadStart(obj.Job));
        Console.WriteLine("How many threads do you want? (Choose: 1 or 2)");
        int.TryParse(Console.ReadLine(), out int userInput);
        if (userInput == 1)
        {
            Console.WriteLine("-> Primary is executing Main()");
            thr.Start();
            thr.Join();
        }
        else if (userInput == 2)
        {
            Thread.Sleep(60);
            thr.Start();
            Console.WriteLine("-> Primary is executing Main()");
        }
        Console.WriteLine("Last step in the main method");

    }
}