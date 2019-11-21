using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace practice_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashedpass = "e79efc4520fbd4b25c3660f5b088bd388c6c61e3";

            var passcls = new PasswordCoverClass();

            passcls.passwordCover();

            var userInput = passcls.strReturn();

            var computedHash = SHAHelper.Hashsha1(userInput);

                while (computedHash != hashedpass)
                {
                    Console.WriteLine("\npassword is incorect. Please try again!\n");
                    passcls.passwordCover();
                    computedHash = SHAHelper.Hashsha1(passcls.strReturn());
                }
            var finalanswer = (computedHash == hashedpass) ? $"\npassword matched! \n{computedHash} and {hashedpass} matched" : ""; //
            Console.WriteLine(finalanswer);

        }
    }

    class PasswordCoverClass
    {
        public string pass { get; set; }
        public void passwordCover()
        {
            pass = "";
            Console.Write("Write the password: ");
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
                        break;
                    }
                }
            } while (true);

        }
        public string strReturn()
        {
            //Console.WriteLine($"\n1 class: retString class {pass}\n");
            return pass;
        }

    }
    class SHAHelper
    {
        public static string Hashsha1(string source)
        {
            var sb = new StringBuilder();
            using (SHA1 sha = new SHA1Managed())
            {
                var computehash = sha.ComputeHash(Encoding.UTF8.GetBytes(source));
                foreach (var b in computehash)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
     
    }
}
