using System;
using System.Text.RegularExpressions;

namespace practice_03
{
    class Program
    {
        static void Main(string[] args)
        {
            new FacebookAccount();
        }
    }

    class FacebookAccount
    {
        private const string namePattern = @"^[\p{L} \.\-]+$";
        private const string usernamePattern = @"^(?=[A-Za-z0-9])[A-Za-z0-9._()\[\]-]{3,15}$"; 
        private const string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])(?=.*[^\da-zA-Z]).{6,12}$";
        private const string phonePattern = @"^([+]995)([\d]{7})"; 

        static FacebookAccount()
        {
            Console.WriteLine("Create an account quick and easy.");

            Console.WriteLine("Your first name*:");
            var _firstname = Console.ReadLine();

            while (!validateFirstName(_firstname))
            {
                Console.WriteLine("YOUR FIRST NAME IS INCORRECT. PLEASE TRY AGAIN!\nYour first name*: ");
                _firstname = Console.ReadLine();
            }

            Console.WriteLine("Your second name*:");
            var _secondname = Console.ReadLine();
            while (!validateSecondName(_secondname))
            {
                Console.WriteLine("YOUR SECOND NAME IS INCORRECT. PLEASE TRY AGAIN!\nYour second name*: ");
                _secondname = Console.ReadLine();
            }

            Console.WriteLine("Date of birth:");
            var _dateofbirth = Console.ReadLine();

            Console.WriteLine("Phone number (input only 10 digit! ex:+9952151515)*:");
            var _phonenumber = Console.ReadLine();
            while (!validatePhoneNumber(_phonenumber))
            {
                Console.WriteLine("YOUR PHONE NUMBER IS INCORRECT. PLEASE TRY AGAIN!\nPhone number*:");
                _phonenumber = Console.ReadLine();
            }

            Console.WriteLine("Your UserName*:");
            var _UserName = Console.ReadLine();
            while (!validateUserName(_UserName))
            {
                Console.WriteLine("YOUR USERNAME IS INCORRECT. PLEASE TRY AGAIN!\nUserName*:");
                _UserName = Console.ReadLine();
            }

            Console.WriteLine("Password*:");
            var _Password = Console.ReadLine();
            while (!validatePassword(_Password))
            {
                Console.WriteLine("YOUR PASSWORD IS INCORRECT. PLEASE TRY AGAIN!\nPassword*:");
                _Password = Console.ReadLine();
            }

            printfinal(_firstname, _secondname, _UserName, _phonenumber, _Password, _dateofbirth);
        }

        public static void printfinal(string a, string b, string c, string d, string e, string f )
        {
            Console.WriteLine("\nRegistation is completed.");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"{a} | {b} | {c} | {d} | {e} | {f} |");
        }
        public static bool validateFirstName(string frsname)
        {
            return Regex.IsMatch(frsname, namePattern);
        }
        public static bool validateSecondName(string secname)
        {
            return Regex.IsMatch(secname, namePattern);
        }
        public static bool validateUserName(string usrname)
        {
            return Regex.IsMatch(usrname, usernamePattern);
        }
        public static bool validatePhoneNumber(string phname)
        {
            return Regex.IsMatch(phname, phonePattern);
        }
        public static bool validatePassword(string passname)
        {
            return Regex.IsMatch(passname, passwordPattern);
        }
    }
}
