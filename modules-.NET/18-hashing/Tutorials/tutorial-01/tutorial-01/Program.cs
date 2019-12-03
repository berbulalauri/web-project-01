using System;

namespace hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write some text here: ");
            var userInput = Console.ReadLine();
            //SHAHelper hash = new SHAHelper();
            var computedHash = SHAHelper.Hashsha1(userInput);
            var computedSalt = SHAHelper.Generatedsalt();

            Console.WriteLine($"Generated hash: {computedHash}");
            Console.WriteLine($"Generated salt: {computedSalt}");
            Console.WriteLine($"Generated hash with salt: {SHAHelper.Hashsha1(computedHash + computedSalt)}");

        }
    }
}
