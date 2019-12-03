using System;

namespace tutorial_02
{
    class Program
    {

        private static int PasswordLength = 8;
        private static int digitCount = 2;
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the password: ");
            var userPassword = Console.ReadLine();

            var isPasswordValidx = isPasswordValid(userPassword, out var errorMessage);
            var messageToOut = isPasswordValidx ? "Password is valid" : errorMessage;
            Console.WriteLine(messageToOut);

        }
        public static bool isPasswordValid(string password, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (password.Length < PasswordLength)
            {
                errorMessage += $"password must have at least eight characters. {Environment.NewLine}";
            }

            if (!isThisOnlyLettersOrDigit(password))
            {
                errorMessage += $"password must contain letter or digits. {Environment.NewLine}";
            }
            if (!doesPasswordContainsRequiredDigit(password, digitCount))
            {
                errorMessage += $"password must have at least two digits. {Environment.NewLine}";
            }
            if (password.Length < PasswordLength || !isThisOnlyLettersOrDigit(password) || !doesPasswordContainsRequiredDigit(password, digitCount))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool isThisOnlyLettersOrDigit(string password)
        {
            foreach (var c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool doesPasswordContainsRequiredDigit(string password, int requiredDigitCount)
        {
            int counter = 0;
            foreach (var c in password)
            {
                if (char.IsDigit(c)) { counter++; }

                if (counter >= requiredDigitCount) return true;
            }
            return false;
        }
    }
}
