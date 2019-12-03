using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tutorial_01
{
    [Info("berdia bulalauri", 555, "descirpttion is here")]
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            Point<int> point = new Point<int>(2, 4);
            Console.WriteLine(point);
            InfoAttribute attr = (InfoAttribute)typeof(Program).GetCustomAttributes(false)[0];
        }
    }

    [Obsolete("here is functionality From attrs, use new class")]
    [Info("berdia bulalauri", 555, "descirpttion is here")]
    class Point<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }
        public void resetPoint()
        {
            X = default;
            Y = default;
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
