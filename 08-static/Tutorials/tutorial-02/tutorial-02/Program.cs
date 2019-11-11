using System;

namespace tutorial_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Animal(4, "Monkey joy");
            Animal a2 = new Animal(4, "Donkey boy");

        }
    }

    public class Animal
    {
        public int PawCount { get; set; }
        public string Name { get; set; }

        static Animal()
        {
            Console.WriteLine($"hello from static constructor.");
        }
        public Animal(int pawCount, string name)
        {
            PawCount = pawCount;
            Name = name;
            Console.WriteLine($"hello {name} from constructor.");
        }
    }

}
