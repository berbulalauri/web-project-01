using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace tutorial_01
{
    class Program
    {
        private const string namePattern = @"^[\p{L} \.\-]{3,1115}$";

        static void Main(string[] args)
        {
            string _holiday = "encryptMd5.dat";
            var saltString = "COJV34";
            var saltedPassword = "";
            var firstName = "";
            bool register = true;
            bool foundMatch = false;
            int i = 0;
            Dictionary<int, (string, string, string)> dict = new Dictionary<int, (string, string, string)>();

            Stream writeStream = null;
            Stream readStream = null;

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                while (register)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("1. Sign up");
                    Console.WriteLine("2. Sign In");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Select Option: ");
                    int.TryParse(Console.ReadLine(), out int switchSelector);

                    switch (switchSelector)
                    {
                        case 1:
                            {
                                using (writeStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Write))
                                {
                                    var passcls = new PasswordCoverClass();

                                    Console.Write("\nInput name: ");
                                    firstName = Console.ReadLine();

                                    while (!validateFirstName(firstName))
                                    {
                                        Console.Write("\nName is not valid! Please try again!\nInput name: ");
                                        firstName = Console.ReadLine();
                                    }

                                    passcls.passwordCover();

                                    var hashedpasswd = passcls.hashedPassRtnr();

                                    var computedHash = SHAHelper.Hashsha1(hashedpasswd);

                                    saltedPassword = SHAHelper.Hashsha1(computedHash + saltString);

                                    dict[i] = ($"{firstName}",$"{saltedPassword}",$"{hashedpasswd}");

                                    i++;

                                    Console.WriteLine($"Data Saved successfully");

                                    binaryFormatter.Serialize(writeStream, dict);
                                }
                            }
                            break;
                        case 2:
                            {
                                using (readStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Read))
                                {
                                    Dictionary<int, (string, string, string)> holidayBinnary = (Dictionary<int, (string, string, string)>)binaryFormatter.Deserialize(readStream);
                                    int j = 0;
                                    Console.WriteLine($"Currently Exist {holidayBinnary.Count} object!");

                                    //Printing result after inputing data 3 times!!
                                    while (holidayBinnary.Count > j)
                                    {
                                        Console.WriteLine($"user:{holidayBinnary[j].Item1} - password:{holidayBinnary[j].Item3} - hash: {holidayBinnary[j].Item2}");
                                        j++;
                                    }
                                    do
                                    {
                                        Console.WriteLine("\ninput name: ");
                                        var userInput = Console.ReadLine();
                                        
                                        foreach (var mm in holidayBinnary)
                                        {
                                            if (mm.Value.Item1 == userInput)
                                            {
                                                Console.WriteLine($"{userInput} exist!");
                                                do
                                                {
                                                    var passcls = new PasswordCoverClass();
                                                    passcls.passwordCover();
                                                    var hashedpasswd = passcls.hashedPassRtnr();
                                                    var computedHash = SHAHelper.Hashsha1(hashedpasswd);
                                                    saltedPassword = SHAHelper.Hashsha1(computedHash + saltString);
                                                    if (mm.Value.Item2 == saltedPassword)
                                                    {
                                                        Console.WriteLine($"Your Password Matched!\nWELCOME {userInput} - {hashedpasswd}\n");
                                                        break;
                                                    }
                                                    else { Console.WriteLine("YOUR PASSWORD IS INCORRECT. PLEASE TRY AGAIN!"); }

                                                } while (true);
                                                foundMatch = true;
                                                break;
                                            }
                                        }
                                        if (foundMatch) { break; } else { Console.WriteLine("Can't Found Match. try again!"); }

                                    } while (true);
                                }
                            }
                            break;
                        case 3:
                            register = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something went wrong {ex.Message}");
            }
        }
        public static bool validateFirstName(string frsname)
        {
            return Regex.IsMatch(frsname, namePattern);
        }
    }
    class PasswordCoverClass
    {
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

                if (pass.Length > 6) { break; } else { Console.WriteLine("YOUR PASSWORD IS INCORRECT. PLEASE TRY AGAIN!"); }
            }
            while (true);
        }

        public string hashedPassRtnr()
        {
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
