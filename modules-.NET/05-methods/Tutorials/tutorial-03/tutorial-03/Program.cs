using System;

namespace tutorial_03
{
    class Program
    {
        static void Main(string[] args)
        {
            if(int.TryParse(Console.ReadLine(), out int countOfMult))
            {
                Console.WriteLine($"{countOfMult} number was multiplied and result is {ManageMultipling(countOfMult)} ");
            }
            
        }

        public static int ManageMultipling(int countOfNumber)
        {
            var randomizer = new Random();
            switch (countOfNumber)
            {
                case 2:
                    return Multipy(randomizer.Next(), randomizer.Next());
                case 3:
                    return Multipy(randomizer.Next(), randomizer.Next(), randomizer.Next());
                default:
                    return -1;
            }
        }

        public static int Multipy(int x, int y)
        {
            return x * y;
        }
        public static int Multipy(int x, int y, int z)
        {
            return x * y * z;
        }

    }
}
