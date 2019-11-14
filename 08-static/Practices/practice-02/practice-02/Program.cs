using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace practice_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("John Doe", 19);
            Student s2 = new Student("Oliver Smith", 20);
            Console.WriteLine("Number of Instance is: "+Student.CountOfIntances());
        }

    }
    public class Student
    {
        public static int initNumber = 0;
        public static int increasedNumber;

        public Student(string a, int b)
        {
            increasedNumber = ++initNumber;
        }
        public static int CountOfIntances()
        {
            return increasedNumber;
        }
    }
}
