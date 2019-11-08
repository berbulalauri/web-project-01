using System;

class MainClass
{
    public enum operators
    {
        Add = 1,
        Subtract = 2,
        Multiply = 3,
        Divide = 4
    }
    public static void Main(string[] args)
    {
        int i = 0;
        string[] Arr = new string[15];
        bool yesno = true;
        while (yesno)
        {
            int result = 0;
            Double divResult = 0;
            string line;
            string myoperator = " ";
            Console.WriteLine("Input number X: ");
            var x = Console.ReadLine();
            var xchecker = int.TryParse(x, out int xa);
            if (xchecker)
            {
                Console.WriteLine("Input number Y: ");
                var y = Console.ReadLine();
                var ychecker = int.TryParse(y, out int ya);
                if (ychecker)
                {

                    Console.WriteLine("Choose a mathematical operation from the following list: ");
                    Console.WriteLine("1 - Add");
                    Console.WriteLine("2 - Subtract");
                    Console.WriteLine("3 - Multiply");
                    Console.WriteLine("4 - Divide");
                    var mathOperator = Console.ReadLine();
                    int.TryParse(mathOperator, out int intMathOp);
                    switch (intMathOp)
                    {
                        case (int)operators.Add:
                            Console.WriteLine("Option 1");
                            result = xa + ya;
                            myoperator = "+";
                            break;
                        case (int)operators.Subtract:
                            Console.WriteLine("Option 2");
                            result = xa - ya;
                            myoperator = "-";
                            break;
                        case (int)operators.Multiply:
                            Console.WriteLine("Option 3");
                            result = xa * ya;
                            myoperator = "*";
                            break;
                        case (int)operators.Divide:
                            Console.WriteLine("Option 4");
                            divResult = Convert.ToDouble(xa) / Convert.ToDouble(ya);
                            myoperator = "/";
                            break;
                        default:
                            Console.WriteLine("please choose correct operation");
                            break;
                    }
                    if (ya == 0)
                    {
                        line = $"Inaccessible operation: You cannot divide by zero.";
                        Arr[i] = line;
                        Console.WriteLine(Arr[i]);
                        i++;
                    }
                    else
                    {
                        if (divResult != 0)
                        {
                            line = $"result: {xa} {myoperator} {ya} = {divResult}";
                            Arr[i] = line;
                            Console.WriteLine(Arr[i]);
                            i++;
                        }
                        else
                        {
                            line = $"result: {xa} {myoperator} {ya} = {result}";
                            Arr[i] = line;
                            Console.WriteLine(Arr[i]);
                            i++;
                        }

                    }
                }
                else
                {
                    line = $"Inaccessible operation: {y} is not a number";
                    Arr[i] = line;
                    Console.WriteLine(Arr[i]);
                    i++;
                }
            }
            else
            {
                line = $"Inaccessible operation: {x} is not a number";
                Arr[i] = line;
                Console.WriteLine(Arr[i]);
                i++;
            }
            Console.WriteLine("Continue (y/n): ");
            var continueChecker = Console.ReadLine();
            if (continueChecker == "y")
            {
                yesno = true;
                Console.WriteLine("==============================");
            }
            else if (continueChecker == "n")
            {
                yesno = false;
                Console.WriteLine("-------History-------");
                for (int b = 0; b < Arr.Length; b++)
                {
                    Console.WriteLine(Arr[b]); //$"{b+1}) "+
                }
            }
        }


    }
}