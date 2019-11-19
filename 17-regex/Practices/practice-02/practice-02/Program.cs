using System;
using System.Text.RegularExpressions;
namespace practice_02
{
    class Program
    {
        static void Main(string[] args)
        {
            new EmailValidator();
        }
    }
    public class EmailValidator
    {
        private const string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        static EmailValidator()
        {
            bool loopCheck = true;
            while (loopCheck)
            {
                Console.WriteLine("please Input email address: ");
                var emailtransfer = Console.ReadLine();
                if (emailtransfer != "exit")
                {
                    if (IsValid(emailtransfer)) { Console.WriteLine("Valid Address!"); } else { Console.WriteLine("Not Valid Address!!"); } 
                } else { loopCheck = false; }
            }
        }
        static bool IsValid(string email)
        {
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

    }
}
