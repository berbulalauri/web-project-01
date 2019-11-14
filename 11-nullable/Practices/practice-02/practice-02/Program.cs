using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(20, 20);
            Point p2 = new Point(25, 22);

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());

            var p3 =  (p1 == p2);
            var p4 =  p1 < p2;
            var p5 =  p1 > p2;
            var p6 =  p1 <= p2;

        }

        class Point
        {
            public static int counter { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public static Point operator >(Point p1, Point p2)
            {
                if (p1.X > p2.X && p1.Y > p2.Y)
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] > [{p2.X},{p2.Y}]\nResult: true");
                }
                else
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] > [{p2.X},{p2.Y}]\nResult: false");
                }
                return new Point(p1.X, p1.Y);
            }
            public static Point operator <(Point p1, Point p2)
            {
                if (p1.X < p2.X && p1.Y < p2.Y)
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] < [{p2.X},{p2.Y}]\nResult: true");
                }
                else
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] < [{p2.X},{p2.Y}]\nResult: false");
                }
                return new Point(p1.X, p1.Y);
            }
            public static Point operator >=(Point p1, Point p2)
            {
                if (p1.X >= p2.X && p1.Y >= p2.Y)
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] >= [{p2.X},{p2.Y}]\nResult: true");
                }
                else
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] >= [{p2.X},{p2.Y}]\nResult: false");
                }
                return new Point(p1.X, p1.Y);
            }
            public static Point operator <=(Point p1, Point p2)
            {
                if (p1.X <= p2.X && p1.Y <= p2.Y)
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] <= [{p2.X},{p2.Y}]\nResult: true");
                }
                else
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] <= [{p2.X},{p2.Y}]\nResult: false");
                }
                return new Point(p1.X, p1.Y);
            }
            public static Point operator ==(Point p1, Point p2)
            {
                if(p1.X == p2.X && p1.Y == p2.Y)
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] == [{p2.X},{p2.Y}]\nResult: true");
                } else
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] == [{p2.X},{p2.Y}]\nResult: false");
                }
                return new Point(p1.X, p1.Y);
            }
            public static Point operator !=(Point p1, Point p2)
            {
                if (p1.X != p2.X && p1.Y != p2.Y)
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] != [{p2.X},{p2.Y}]\nResult: true");
                }
                else
                {
                    Console.WriteLine($"[{p1.X},{p1.Y}] != [{p2.X},{p2.Y}]\nResult: false");
                }
                return new Point(p1.X, p1.Y);
            }
            public override string ToString()
            {
                counter = ++counter;

                return $"{counter} Point: [{X},{Y}] ";
            }
        }
    }
}