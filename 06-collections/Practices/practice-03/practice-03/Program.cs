using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List_Methods_Properties
{
    class Program
    {
        public enum operators
        {
            SIGNIN = 1,
            SIGNUP = 2,
            EXIT= 3
        }
        static void Main(string[] args)
        {
            var userData = new Dictionary<string, string>();
            userData.Add("giorgi", "grg123");
            userData.Add("davit", "qwe890");
            userData.Add("davit0", "zxc000");
            userData.Add("malvina", "paskey1");

            bool truefalse = true;
            while (truefalse)
            {
                Console.WriteLine("PLEASE SELECT OPTIONS: ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. SIGN IN");
                Console.WriteLine("2. SIGN UP ");
                Console.WriteLine("3. Exit");
                var userIntInput = Console.ReadLine();
                int.TryParse(userIntInput, out int userIntOutput);

                switch (userIntOutput)
                {
                    case (int)operators.SIGNIN:
                        Console.WriteLine("SIGNIN 1");
                        {
                            Console.WriteLine("please enter username: ");
                            var userInput = Console.ReadLine();

                            if (userData.TryGetValue(userInput, out string test))
                            {
                                Console.WriteLine("please enter password: ");
                                var passInput = Console.ReadLine();
                                if (test == passInput)
                                {
                                    Console.WriteLine($"password matched!!! SUCCESSFULL SIGNIN !!! {Environment.NewLine}");
                                }
                                else
                                {
                                    Console.WriteLine($"INCORECT PASSWORD!! {Environment.NewLine}");
                                }
                            }
                            else { Console.WriteLine($"A user with this name could not be found !!!{Environment.NewLine}"); }

                            foreach (KeyValuePair<string, string> item in userData)
                            {
                                Console.WriteLine("USERNAME: {0}, PASSWORD: {1}", item.Key, item.Value);
                            }

                        }
                        break;
                    case (int)operators.SIGNUP:
                        Console.WriteLine("2. PLEASE START SIGNUP");
                        {
                            Console.WriteLine("please enter new username: ");
                            var userInput = Console.ReadLine();

                            if (!userData.TryGetValue(userInput, out string userNameOutput))
                            {
                                Console.WriteLine("please enter new password: ");
                                var newPassInput = Console.ReadLine();
                                int Count = 0;
                                foreach (char c in newPassInput)
                                {
                                    Count++;
                                }
                                if (Count < 3)
                                {
                                    Console.WriteLine("PASSWORD IS LESS THAN 2");
                                } else
                                {
                                    userData.Add($"{userInput}", $"{newPassInput}");

                                    foreach (KeyValuePair<string, string> item in userData)
                                    {
                                        Console.WriteLine("USERNAME: {0}, PASSWORD: {1}", item.Key, item.Value);
                                    }


                                }


                            }
                            else { Console.WriteLine("Username is already taken.");  }
                        }

                        break;
                    case (int)operators.EXIT:
                        Console.WriteLine("EXIT 3");
                        truefalse = false;
                        break;
                }
               
            }



        }
    }
}