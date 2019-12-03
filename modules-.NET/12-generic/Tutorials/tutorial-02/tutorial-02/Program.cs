using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tutorial_02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TemperatureValidator.CheckTemp(30); //100
                //var arr = new int[3];
                //var haha = arr[223];

                throw new OutOfMemoryException("out of memory !!!");

            } catch(IncreadibleTemperatureException ex)
            {
                Console.WriteLine(ex.Message);
            } catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("GENERAL BLOCK");
            }
            finally
            {
                Console.WriteLine("finally goes here!");
            }

        }
    }

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
