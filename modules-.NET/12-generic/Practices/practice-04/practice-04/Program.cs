using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace practice_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage<int>();
            var stringStorage = new Storage<string>("my test");
            var dateStorage = new Storage<DateTime>(DateTime.Now);

            Console.WriteLine(storage);
            Console.WriteLine(stringStorage);
            Console.WriteLine(dateStorage);
        }
    }
    public class Storage<T>
    {
        public T X { get; set; }
        public DateTime Y { get; set; }
        public Storage() { }
        public Storage(T value)
        {
            X = value;
        }
        public Storage(DateTime value)
        {
            Y = value;
        }
        public override string ToString()
        {
            return $"{typeof(T)} : {X} ";
        }
    }
}
