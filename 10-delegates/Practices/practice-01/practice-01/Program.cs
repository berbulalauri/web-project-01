using System;

namespace practice_01
{
    class Program
    {
        static void Main(string[] args)
        {

            var mm = new whileAndSwitchCase();
            mm.whileClass();
        }
    }

    public class whileAndSwitchCase
    {
        public bool truefalse = true;
        public int FirstVal { get; set; }
        public int SecondVal { get; set; }

        public delegate void addnum(int a, int b);
        public void sum(int a, int b)
        {
            Console.WriteLine("Result of ({0} + {1}) = {2}",a,b,a+b);
        }

        public void subtract(int a, int b)
        {
            Console.WriteLine("Result of ({0} - {1}) = {2}", a, b, a - b);
        }

        public void multiplication(int a, int b)
        {
            Console.WriteLine("Result of ({0} * {1}) = {2}", a, b, a*b);
        }

        public void devision(int a, int b)
        {
            Console.WriteLine("Result of ({0} / {1}) = {2}", a, b, a/b);
        }

        public void reminder(int a, int b)
        {
            Console.WriteLine("Result of division reminder is: ({0} % {1}) = {2}", a, b, a%b);
        }

        public void printMenu()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("             MENU");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. The remainder of division");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Select an action: ");
        }
        public void InputNumbers()
        {
            Console.WriteLine("Enter A: ");
            var firstInputNUmber = Console.ReadLine();
            Console.WriteLine("Enter B: ");
            var SecondInputNUmber = Console.ReadLine();
            int.TryParse(firstInputNUmber, out int firstVal);
            int.TryParse(SecondInputNUmber, out int secondVal);
            this.FirstVal = firstVal;
            this.SecondVal = secondVal;
        }
        public void whileClass()
        {
            whileAndSwitchCase obj = new whileAndSwitchCase();
            var del_obj1 = new addnum(obj.sum);
            var del_obj2 = new addnum(obj.subtract);
            var del_obj3 = new addnum(obj.multiplication);
            var del_obj4 = new addnum(obj.devision);
            var del_obj5 = new addnum(obj.reminder);

            while (truefalse)
            {
                printMenu();
                var inputBool = Console.ReadLine();
                int.TryParse(inputBool, out int outputBool);
                switch (outputBool)
                {
                    case 1:
                        InputNumbers();
                        del_obj1(FirstVal, SecondVal);
                        break;
                    case 2:
                        InputNumbers();
                        del_obj2(FirstVal, SecondVal);
                        break;
                    case 3:
                        InputNumbers();
                        del_obj3(FirstVal, SecondVal);
                        break;
                    case 4:
                        InputNumbers();
                        del_obj4(FirstVal, SecondVal);
                        break;
                    case 5:
                        InputNumbers();
                        del_obj5(FirstVal, SecondVal);
                        break;
                    case 0:
                        truefalse = false;
                        break;
                    default:
                        Console.WriteLine("incorect Entry. please try again ");
                        break;
                }

            }
        }

    }
}
