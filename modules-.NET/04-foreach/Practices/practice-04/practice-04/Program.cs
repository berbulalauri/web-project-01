using System;
class MainClass
{
    public static void Main(string[] args)
    {
        int[] Arr = new int[5];
        int lg = Arr.Length - 1;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (j == i)
                {
                    Arr[lg - j] = 1;
                    for (int k = 0; k < 5; k++) { Console.Write(Arr[k] + " "); }
                    Console.WriteLine();
                    Arr[lg - j] = 0;
                }
                else
                {
                    Arr[j] = 0;
                }
            }
        }
    }
}
