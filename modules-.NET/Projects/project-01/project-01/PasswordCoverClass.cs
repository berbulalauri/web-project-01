using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace project_01
{
    class PasswordCoverClass
    {
        public const string namePattern = @"^[\p{L} \.\-]{3,1115}$";
        private const string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])(?=.*[^\da-zA-Z]).{6,12}$";

        public string pass { get; set; }
        public void passwordCover()
        {
            do
            {
                pass = "";
                Console.Write("\nWrite the password: ");
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        this.pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }
                    }
                } while (true);

                if (pass.Length > 6 && validateFirstName(pass)) { break; } else { Console.WriteLine("YOUR PASSWORD IS INCORRECT. PLEASE TRY AGAIN!"); }
            }
            while (true);
        }

        public string hashedPassRtnr()
        {
            return pass;
        }
        public static bool validateFirstName(string frsname)
        {
            return Regex.IsMatch(frsname, passwordPattern);
        }

    }


}


