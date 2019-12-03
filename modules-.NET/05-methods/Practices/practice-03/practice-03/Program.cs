using System;

class MainClass
{
    public static void Main(string[] args)
    {
        int m = 0;
        Console.WriteLine("input a: ");
        var aInput = Console.ReadLine();
        double.TryParse(aInput, out double aInt);
        if (aInt < 1) { Console.WriteLine("A should be more than 1cm"); } else
        {
            Console.WriteLine("input c: ");
            var cInput = Console.ReadLine();
            double.TryParse(cInput, out double cInt);
            if (cInt < 1) { Console.WriteLine("C should be more than 1cm"); } else
            {
                Console.WriteLine("input angle°: ");
                var angleInput = Console.ReadLine();
                double.TryParse(angleInput, out double angleInt);
                if (angleInt > 179 || angleInt < 1) { Console.WriteLine("Angle value should be in range 1 ... 179"); } //

                CalculateTriangleArea(aInt, cInt, angleInt);

            }


        }
    }
    public static int CalculateTriangleArea(double a, double c, double angle)
    {
        int myval = 0;
        double count = angle * Math.PI / 180.0;
        double sum = a * c * Math.Sin(count) / 2;
        Console.WriteLine("result: " + sum); //area of the triangle 

        // it would be better to NOT return anything because it will turn partial number to full number and change Result!!!
        // myval = Convert.ToInt32(sum);
        return myval;
    }
}

