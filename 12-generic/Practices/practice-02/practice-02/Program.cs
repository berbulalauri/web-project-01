using System;

namespace practice_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var mm = new SecondClass();
            mm.whileClass();

        }
    }
    public class SecondClass
    {
        public bool nameCheck { get; set; }
        public bool valueCheck { get; set; }
        public static  int FirstNumOutput { get; set; }
        public static int SecondNumOutput { get; set; }

        public delegate void addnum(int a, int b);
        public void sum(int a, int b)
        {
            Console.WriteLine("Result of ({0} + {1}) = {2}", a, b, a + b);
        }
        public void subtract(int a, int b)
        {
            Console.WriteLine("Result of ({0} - {1}) = {2}", a, b, a - b);
        }

        public void multiplication(int a, int b)
        {
            Console.WriteLine("Result of ({0} * {1}) = {2}", a, b, a * b);
        }

        public void division(int a, int b)
        {
            try
            {
                int divresult = a / b;
                Console.WriteLine("Result of ({0} / {1}) = {2}", a, b, divresult);
            } catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

          }

        public void InputNumbers()
        {
            valueCheck = false;
            while (!valueCheck)
            {
                Console.WriteLine("Input first number: ");
                valueCheck = int.TryParse(Console.ReadLine(), out int firstnumoutput);
                if (!valueCheck) { Console.WriteLine("Invalid operation: Input string was not in a correct format"); }
                FirstNumOutput = firstnumoutput;
            }
            valueCheck = false;
            while (!valueCheck)
            {
                Console.WriteLine("Input Second number: ");
                valueCheck = int.TryParse(Console.ReadLine(), out int secondnumoutput);
                if (!valueCheck) { Console.WriteLine("Invalid operation: Input string was not in a correct format"); }
                SecondNumOutput = secondnumoutput;
            }

        }
        public void whileClass()
        {
            SecondClass obj = new SecondClass();
            var del_obj1 = new addnum(obj.sum);
            var del_obj2 = new addnum(obj.subtract);
            var del_obj3 = new addnum(obj.multiplication);
            var del_obj4 = new addnum(obj.division);

            Console.WriteLine("Select following operation : [+, -, *, /] ");
            var userInputOper = Console.ReadLine();

            if (userInputOper == "+")
            {
                InputNumbers();
                del_obj1(FirstNumOutput, SecondNumOutput);
            } else if (userInputOper == "-")
            {
                InputNumbers();
                del_obj2(FirstNumOutput, SecondNumOutput);
            } else if (userInputOper == "*")
            {
                InputNumbers();
                del_obj3(FirstNumOutput, SecondNumOutput);
            } else if (userInputOper == "/")
            {
                InputNumbers();
                del_obj4(FirstNumOutput, SecondNumOutput);
            } else if(userInputOper != "+" || userInputOper != "-" || userInputOper != "*" || userInputOper != "/"){ Console.WriteLine("Invalid operation: Operation is not valid"); }

        }

    }
    }
