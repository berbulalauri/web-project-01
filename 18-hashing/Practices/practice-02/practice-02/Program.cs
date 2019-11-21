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

            Dictionary<int, (string,string) > dict = new Dictionary<int, (string, string)>();

            Stream writeStream = null;
            Stream readStream = null;

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                int i = 0;
                while (3 > i)
                {
                    using (writeStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        var passcls = new PasswordCoverClass();

                        Console.Write("Input name: ");
                        firstName = Console.ReadLine();

                        while (!validateFirstName(firstName))
                        {
                            Console.Write("Name is not valid! Please try again!\nInput name: ");
                            firstName = Console.ReadLine();
                        }

                        passcls.passwordCover();

                        var hashedpasswd = passcls.hashedPassRtnr();

                        var computedHash = SHAHelper.Hashsha1(hashedpasswd);

                        saltedPassword = SHAHelper.Hashsha1(computedHash + saltString);

                        dict[i] = ($"{firstName}", $"{saltedPassword}");

                        Console.WriteLine($"Data Saved successfully");

                        binaryFormatter.Serialize(writeStream, dict);
                    }
                    i++;
                    //writeStream.Close();
                }

                using (readStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Read))
                {

                    Dictionary<int, (string, string)> holidayBinnary = (Dictionary<int, (string, string)>)binaryFormatter.Deserialize(readStream);
                    int j = 0;
                    Console.WriteLine($"count: : : {holidayBinnary.Count}");
                    
                    //Printing result after inputing data 3 times!!
                    while (holidayBinnary.Count > j)
                    {
                        Console.WriteLine(holidayBinnary[j]);
                        j++;
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
        //private const string passwordPattern = "^{8,}$"; //@"^([+]995)([\d]{7})"
        public string pass { get; set; }
        public void passwordCover()
        {
            do
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
                            Console.WriteLine();
                            break;
                        }
                    }
                } while (true);

                if (pass.Length > 6) { break; } else { Console.WriteLine("\nYOUR PASSWORD IS INCORRECT. PLEASE TRY AGAIN!"); }
            }
            while (true);

        }

        public string hashedPassRtnr()
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
