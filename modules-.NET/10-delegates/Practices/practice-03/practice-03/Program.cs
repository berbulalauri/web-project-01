using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string AccountType { get; set; }
        public static int AcountNumber { get; set; }
        public int case2 { get; set; }
        public static Dictionary<int, (string name, string surname, string acctype, int amount)> dict = new Dictionary<int, (string name, string surname, string acctype, int amount)>();

        public delegate void addnum(int a, int b);
        public void sum(int a, int b)
        {
            dict[100] = (FirstName, LastName, AccountType, a + b);
            printer(dict);
        }
        public void subtraction(int a, int b)
        {
            dict[100] = (FirstName, LastName, AccountType, a - b);
            printer(dict);
        }

        public void whileClass()
        {
            whileAndSwitchCase obj = new whileAndSwitchCase();
            var del_obj1 = new addnum(obj.sum);
            var del_obj2 = new addnum(obj.subtraction);

            Console.WriteLine("Enter First Name: ");
            var userInputFirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            var userInputLastName = Console.ReadLine();

            while (truefalse)
            {
                printMenu();
                var inputBool = Console.ReadLine();
                int.TryParse(inputBool, out int outputBool);
                switch (outputBool)
                {
                    case 1:
                        Console.WriteLine("Enter the amount to create an account: ");
                        var userInputMoneyAmount = Console.ReadLine();
                        int.TryParse(userInputMoneyAmount, out int userOutputMoneyAmount);

                        Console.WriteLine("Choose account type: \n1. Deposit\n2. Demand");
                        Console.WriteLine("Select an action: ");
                        var userInputAccountType = Console.ReadLine();
                        int.TryParse(userInputAccountType, out int accountType);

                        switch (accountType)
                        {
                            case 1:
                                AccountType = "Deposit";
                                break;
                            case 2:
                                AccountType = "Demand";
                                break;
                            default:
                                break;
                        }
                        AcountNumber = 100;
                        FirstName = userInputFirstName;
                        LastName = userInputLastName;
                        dict.Add(AcountNumber, (userInputFirstName, userInputLastName, AccountType, userOutputMoneyAmount));
                        printer(dict);
                        break;

                    case 2:
                        Console.WriteLine("Enter account number: ");
                        int.TryParse(Console.ReadLine(), out int userIdentifyWithdraw);
                        foreach (KeyValuePair<int, (string a, string b, string c, int d)> item in dict)
                        {
                            if (item.Key == userIdentifyWithdraw)
                            {
                                Console.WriteLine($"Welcome {item.Value.a} {item.Value.b} !");
                            }
                            case2 = item.Value.d;
                        }
                        Console.WriteLine("EXSISTING AMOUNT OF MONEY: " + case2);
                        Console.WriteLine("Indicate How Much You Want To WITHDRAW -: ");
                        int.TryParse(Console.ReadLine(), out int userWithdrawAmount);

                        del_obj2(case2, userWithdrawAmount);

                        break;


                    case 3:
                        Console.WriteLine("Enter account number: ");
                        int.TryParse(Console.ReadLine(), out int userIdentifyAdding);
                        foreach (KeyValuePair<int, (string a, string b, string c, int d)> item in dict)
                        {
                            if (item.Key == userIdentifyAdding)
                            {
                                Console.WriteLine($"Welcome {item.Value.a} {item.Value.b} !");
                            }
                            case2 = item.Value.d;
                        }
                        Console.WriteLine("EXSISTING AMOUNT OF MONEY: " + case2);
                        Console.WriteLine("Indicate The Amount To Be ADDED +: ");
                        int.TryParse(Console.ReadLine(), out int userAddAmount);
                        del_obj1(case2, userAddAmount);

                        break;


                    case 4:
                        Console.WriteLine("Enter account number: ");
                        int.TryParse(Console.ReadLine(), out int userIdentifyClosed);

                        dict[userIdentifyClosed] = ("", "", "", 0);
                        printer(dict);
                        Console.WriteLine($"your Account {FirstName} {LastName} with ID: {AcountNumber} has been Closed! ");
                        FirstName = " ";
                        LastName = " ";
                        AcountNumber = 0;
                        AccountType = " ";
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
        public void printer(IEnumerable<KeyValuePair<int, (string a, string b, string c, int d)>> dict)
        {
            foreach (KeyValuePair<int, (string a, string b, string c, int d)> item in dict)
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("FirstName: {0}\nLastName: {1}\nAccount Number: {2}\nAccount Type: {3}\nMONEY AMOUNT: {4}", item.Value.a, item.Value.b, item.Key, item.Value.c, item.Value.d);
                Console.WriteLine("==================================\n");
            }
        }
        public void printMenu()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("             MENU");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Open an account");
            Console.WriteLine("2. Withdraw funds");
            Console.WriteLine("3. Add funds to the account");
            Console.WriteLine("4. Close account");
            Console.WriteLine("0. Exit the program");
            Console.WriteLine("==================================");
            Console.WriteLine("Select an action: ");
        }



    }
}