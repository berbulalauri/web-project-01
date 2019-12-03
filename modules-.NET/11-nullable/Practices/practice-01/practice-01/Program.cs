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
            Point p2 = new Point(20, 20);
            Point p3 = new Point(20, 20);
            int value = 2;

            var p4 = ++p1;
            var p5 = --p2;
            var p6 = p3 * value;

            Console.WriteLine(p4.ToString());
            Console.WriteLine(p5.ToString());
            Console.WriteLine(p6.ToString());
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public static Point operator ++(Point p1)
            {
                p1.X = ++p1.X;
                p1.Y = ++p1.Y;
                return new Point(p1.X, p1.Y );
            }
            public static Point operator --(Point p1)
            {
                p1.X = --p1.X;
                p1.Y = --p1.Y;
                return new Point(p1.X, p1.Y);
            }
            public static Point operator *(Point p1, int value)
            {
                return new Point(p1.X*value, p1.Y*value);
            }
         public override string ToString()
            {
                return $"Point x: {X}, Point y: {Y} ";
            }
        }
    }
}
