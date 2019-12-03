using System;

namespace tutorial02
{
    class Program
    {
        static void Main(string[] args)
        {
         // int[,] array = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            int[,] array = new int [5,5];

            for (int i=0; i<5; i++)
            {
                for(int j=0; j<5; j++)
                {
                    if (i == j) {
                        array[i, j] = 1;
                    } else
                    {
                        array[i, j] = 0;
                    }
                    Console.Write($"{array[i, j]}");

                }
                Console.WriteLine($"{Environment.NewLine}");
            }
            Console.ReadLine();
        }
    }
}
