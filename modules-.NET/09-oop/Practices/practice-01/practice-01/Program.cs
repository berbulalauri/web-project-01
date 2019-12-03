using System;

namespace practice_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(180);
            Jeep myJeep = new Jeep(250);
        }
    }
    public class Car
    {
        public readonly double MaxSpeed = 220;
        public static double CurrentSpeed = 200;
        public Car(int a)
        {
            if (a > MaxSpeed)
            {
                a = (int)CurrentSpeed;
                Console.WriteLine("updated Speed: " + CurrentSpeed);
                Console.WriteLine("Current speed of Car: " + a);
            }
            else
            {
                Console.WriteLine("Current speed of Car: " + a);
            }
        }
        public Car(int a,int b) { }
    }
    public class Jeep : Car
    {
        public  Jeep(int b) : base(b,b)
        {
            if (b > MaxSpeed)
            {
                b = (int)CurrentSpeed;
                Console.WriteLine("updated Speed: " + CurrentSpeed);
                Console.WriteLine("Current speed of jeep: " + b);
            } else
            {
                Console.WriteLine("Current speed of jeep: " + b);
            }
        }
    }
}
