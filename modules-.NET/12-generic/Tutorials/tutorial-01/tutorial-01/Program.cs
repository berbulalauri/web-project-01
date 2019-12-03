using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Point<int> point1 = new Point<int>(3, 6);
            Point<double> point2 = new Point<double>(3.03, 6.23);

            Console.WriteLine(point1);
            Console.WriteLine(point2);
            point1.resetPoint();
            point2.resetPoint();
            Console.WriteLine(point1);
            Console.WriteLine(point2);

        }
    }

    class Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Point(T x,T y)
        {
            X = x;
            Y = y;
        }
        public void resetPoint()
        {
            X=default;
            Y=default;
        }
        public override string ToString()
        {
            //return $"X:{X}, Y:{Y}";
            return $"{typeof(T)} point: [{X},{Y}]";
        }
    }
    public interface IFuelable
    {
        int tankCapacity { get; set; }
        void FuelUp();
    }

}
