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
            Point p1 = new Point(10, 20);
            Point p2 = new Point(15, 22);

            var p3 = p1 + p2;
            Point p4 = 100;
            Console.WriteLine(p4.ToString());
            //Console.WriteLine(p3.ToString());
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point (int x,int y)
            {
                X = x;
                Y = y;
            }
            public static Point operator +(Point p1,Point p2)
            {
                return new Point(p1.X + p2.X, p1.Y + p2.Y);
            }
            public static Point operator -(Point p1,Point p2)
            {
                return new Point(p1.X - p2.X, p1.Y - p2.Y);
            }
            public static implicit operator Point(int xy)
            {
                return new Point(xy / 2, xy / 2);
            }
            public override string ToString()
            {
                return $"Point x: {X}, Point y: {Y} ";
            }
        }
    }
}
