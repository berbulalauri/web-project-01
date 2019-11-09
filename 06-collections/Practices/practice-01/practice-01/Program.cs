using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List_Methods_Properties
{
    class Program
    {
        static void Main(string[] args)
        {

            var userData =  new Dictionary<string, string>();
            userData.Add("giorgi", "grg123");
            userData.Add("davit", "qwe890");
            userData.Add("davit0", "zxc000");
            userData.Add("malvina", "paskey1");


            Console.WriteLine("please enter username: ");
            var userInput = Console.ReadLine();

            if (userData.TryGetValue(userInput, out string test)) 
            {
                Console.WriteLine("please enter password: ");
                var passInput = Console.ReadLine();
                if (test == passInput) { Console.WriteLine($"password matched!!! {Environment.NewLine}"); } else { Console.WriteLine($"INCORECT PASSWORD!! {Environment.NewLine}"); }

            } else { Console.WriteLine($"A user with this name could not be found !!!{Environment.NewLine}");}


            foreach (KeyValuePair<string, string> item in userData)
            {
                Console.WriteLine("USERNAME: {0}, PASSWORD: {1}", item.Key, item.Value);
            }
            /*            foreach (KeyValuePair<string, string> item in userData) 
                        {   if(userInput == item.Key) { Console.WriteLine($"Item Key printing !! {item.Key}{Environment.NewLine}"); }
                            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value); }
            */
        }
    }
}