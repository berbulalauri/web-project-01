using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string _holiday = "userdata.dat";
            Holiday holiday = new Holiday
            {
                LoginUser = "",
                FirstName = "",
                LastName = "",
                Email = "",
                Password = "",

            };

            Stream writeStream = null;
            Stream readStream = null;

            bool isWhileTrue = true;
            
            while (isWhileTrue)
            {
                menuPrinter();
                int.TryParse(Console.ReadLine(), out int switchSelector);
                switch (switchSelector)
                {
                    case 1:
                        try
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            using (readStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Read))
                            {
                                Holiday holidayBinnary = (Holiday)binaryFormatter.Deserialize(readStream);

                                Console.WriteLine("your login name: ");
                                var validlogin = Console.ReadLine();
                                if (validlogin == holidayBinnary.LoginUser)
                                {
                                    Console.WriteLine("your password name: ");
                                    var validpass = Console.ReadLine();
                                    if (validpass == holidayBinnary.Password)
                                    {
                                        Console.WriteLine($"welcome {holidayBinnary.FirstName} {holidayBinnary.LastName}\n");
                                    }

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"something went wrong {ex.Message}");
                        }

                        

                        break;
                    case 2:
                        Console.WriteLine("your first name: ");
                        holiday.FirstName = Console.ReadLine();
                        Console.WriteLine("your last name: ");
                        holiday.LastName = Console.ReadLine();
                        Console.WriteLine("your login username: ");
                        holiday.LoginUser =Console.ReadLine();
                        Console.WriteLine("your email address: ");
                        holiday.Email = Console.ReadLine();
                        Console.WriteLine("your password name: ");
                        holiday.Password = Console.ReadLine();

                        Console.WriteLine($"User data object was created : ");
                        Console.WriteLine($"{holiday}");
                        try
                        {
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            using (writeStream = new FileStream($"../../../{_holiday}", FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                binaryFormatter.Serialize(writeStream, holiday);
                                Console.WriteLine($"object was serialized in {_holiday}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"something went wrong {ex.Message}");
                        }
                        break;

                    case 0:
                        isWhileTrue = false;
                        break;
                    default:
                        break;
                }
            }

        }

        public static void menuPrinter()
        {
            Console.WriteLine("===================");
            Console.WriteLine("1.Sign In");
            Console.WriteLine("2.Sign Up");
            Console.WriteLine("0.Exit");
            Console.WriteLine("===================");
            Console.WriteLine("Select you choice: ");
        }
    }
    [Serializable]
    public class Holiday
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string LoginUser { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"first name: {FirstName}\nlast name: {LastName}\nlogin name: {LoginUser}\nemail address: {Email}";
        }

    }
}
