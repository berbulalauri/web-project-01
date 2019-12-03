using System;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Fox fox = new Fox(4);
            fox.makeASound();

            Snake snake = new Snake(0);
            snake.makeASound();

        }
    }
    public class Animal
    {
        public int PawCount
        {
            get;
        }

        public Animal(int pawCount)
        {
            PawCount = pawCount;
            Console.WriteLine("hellow from Animal const");
        }
        public virtual void makeASound()
        {
            Console.WriteLine("silence");

        }
    }
    internal class Fox : Animal
    {
        public Fox(int pawCount):base(pawCount)
        {
            Console.WriteLine($"hello form fox ctor, fox was created and it has {pawCount} paws");
        }

        public override void makeASound()
        {
            Console.WriteLine("fox make a sound auu!");
        }
    }
    internal class Snake : Animal
    {
        public Snake(int pawCount) : base(pawCount)
        {
            Console.WriteLine("hello form fox ctor, snake was created");
        }

        public override void makeASound()
        {
            Console.WriteLine("snake make a sound ssssssssssssssss");
        }
    }

}
