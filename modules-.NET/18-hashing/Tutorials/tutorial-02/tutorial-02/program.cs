using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace hashing
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                Console.Write("Write some text here: ");
                var original = Console.ReadLine();
                //string original = "Here is some data to encrypt!";
                // Create a new instance of the RijndaelManaged
                // class.  This generates a new key and initialization 
                // vector (IV).
                using (RijndaelManaged myRijndael = new RijndaelManaged())
                {

                    myRijndael.GenerateKey();
                    Console.WriteLine($"Generated key: {Encoding.UTF8.GetString(myRijndael.Key)}");
                    
                    myRijndael.GenerateIV();
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = AESHelper.EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);
                    
                    Console.WriteLine($"Encryption String : {Encoding.UTF8.GetString(encrypted)}");

                    // Decrypt the bytes to a string.
                    string roundtrip = AESHelper.DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Decryption String : {0}", roundtrip);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
           
    }
    }
}
