using System;

class MainClass
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Input length of array:");
        var x = Console.ReadLine();
        var arrlng = int.TryParse(x, out int y);
        byte[] Arr = new byte[y];
        if (arrlng)
        {
            byte highChecker = 0;
            for (int i = 0; i < y;)
            {
                Console.WriteLine("Input Number:");
                var k = Console.ReadLine();
                var byteParsed = byte.TryParse(k, out byte j);
                if (byteParsed)
                {
                    Arr[i] = j;
                    i++;
                    if (highChecker < j) { highChecker = j; }
                }
                else
                {
                    Console.WriteLine("Number is not a byte! Try again.");
                }
            }
            Console.WriteLine("array is: " + "[{0}]", string.Join(", ", Arr));
            Console.WriteLine("highest number in Array is: " + highChecker);

        }
        else { Console.WriteLine("Incorrect format"); }


    }
}