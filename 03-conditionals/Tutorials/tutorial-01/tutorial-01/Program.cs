using System;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Type First Number: ");
            var firstInput = Console.ReadLine();
            Console.WriteLine("Please Type First Number: ");
            var secondInput = Console.ReadLine();
            Console.WriteLine("Please Type First Number: ");
            var thirdInput = Console.ReadLine();
            double finalpoint;

            var firstDouble = Convert.ToDouble(firstInput);
            var secondDouble = Convert.ToDouble(secondInput);
            var thirdDouble = Convert.ToDouble(thirdInput);
            if (firstDouble > secondDouble)
            {
                if (firstDouble > thirdDouble) { finalpoint = firstDouble; } else { finalpoint = thirdDouble; }
            }
            else
            {
                if (secondDouble > thirdDouble) { finalpoint = secondDouble; } else { finalpoint = thirdDouble; }
            }

            Console.WriteLine("greatest number is: " + finalpoint);

            if (firstDouble < 0 || secondDouble < 0 || thirdDouble < 0)
            {

                Console.WriteLine("negative number contained");
            }
        }
    }
}
