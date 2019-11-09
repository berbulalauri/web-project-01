using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the first side A: ");
            var firstInput = Console.ReadLine();
            var checkFirstParam = double.TryParse(firstInput, out double FirstSide);
            if (checkFirstParam && FirstSide > 0)
            {
                Console.WriteLine("Input the first side B: ");
                var secondInput = Console.ReadLine();
                var checkSecondParam = double.TryParse(secondInput, out double SecondSide);
                if (checkSecondParam && SecondSide > 0)
                {
                    Console.WriteLine("Input the first side C: ");
                    var thirdInput = Console.ReadLine();
                    var checkThirdParam = double.TryParse(thirdInput, out double ThirdSide);
                    if (checkThirdParam && ThirdSide > 0)
                    {
                        Triangle triangle = new Triangle(FirstSide, SecondSide, ThirdSide);
                        var printedTransaction = triangle.PrintOutTransaction();
                        Console.WriteLine(printedTransaction);

                    } else { Console.WriteLine("Incorect Format... "); };
                } else { Console.WriteLine("Incorect Format... ");};
            } else { Console.WriteLine("Incorect Format... ");};
        }
    }
}
