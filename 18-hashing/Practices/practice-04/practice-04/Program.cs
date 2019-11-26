using System;
using System.IO;
using System.Security.Cryptography;
class ManagedAesSample
{
    public static string fileEncrypted = "../../../encryptAes.dat";
    public static void Main()
    {
        Console.Write("Input text to encrypt: ");
        string data = Console.ReadLine();
        EncryptAesManaged(data);
        Console.ReadLine();
    }
    static void EncryptAesManaged(string raw)
    {
        try
        {
            using (AesManaged aes = new AesManaged())
            {
                byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);
                Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
                string decrypted = Decrypt(aes.Key, aes.IV); //string decrypted = Decrypt(encrypted,aes.Key, aes.IV);
                Console.WriteLine($"Decrypted data: {decrypted}");
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.Message);
        }
        Console.ReadKey();
    }
    static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
    {
        byte[] encrypted;
        using (AesManaged aes = new AesManaged())
        {
            ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                        sw.Write(plainText);
                    encrypted = ms.ToArray();
                }
            }
        }
        File.WriteAllBytes(fileEncrypted, encrypted);
        Console.WriteLine($"file {fileEncrypted} has been created!");
        return encrypted;// return to print AEC ENCRYPTED TEXT in console!
    }
    static string Decrypt(byte[] Key, byte[] IV) //byte[] cipherText,
    {
        byte[] bytesToBeDecrypted = File.ReadAllBytes(fileEncrypted); // getting file content from DAT file
        string decryptedText = null;
        using (AesManaged aes = new AesManaged())
        {
            ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
            using (MemoryStream ms = new MemoryStream(bytesToBeDecrypted)) // starts decripting from file
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cs))
                        decryptedText = reader.ReadToEnd();
                }
            }
        }
        return decryptedText;
    }
}

/*
 
     using System;
using System.IO;
using System.Security.Cryptography;
class ManagedAesSample
{
    public static string fileEncrypted = "../../../encryptAes.dat";
    public static void Main()
    {
        Console.WriteLine("Enter text that needs to be encrypted..");
        string data = Console.ReadLine();
        EncryptAesManaged(data);
        Console.ReadLine();
    }
    static void EncryptAesManaged(string raw)
    {
        try
        {
            // Create Aes that generates a new key and initialization vector (IV).    
            // Same key must be used in encryption and decryption    
            using (AesManaged aes = new AesManaged())
            {
                // Encrypt string    
                byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);
                // Print encrypted string    
                Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
                // Decrypt the bytes to a string.    
                string decrypted = Decrypt(aes.Key, aes.IV); //string decrypted = Decrypt(encrypted,aes.Key, aes.IV);
                // Print decrypted string. It should be same as raw data    
                Console.WriteLine($"Decrypted data: {decrypted}");
            }
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.Message);
        }
        Console.ReadKey();
    }
    static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
    {
        byte[] encrypted;
        // Create a new AesManaged.    
        using (AesManaged aes = new AesManaged())
        {
            // Create encryptor    
            ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
            // Create MemoryStream    
            using (MemoryStream ms = new MemoryStream())
            {
                // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                // to encrypt    
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    // Create StreamWriter and write data to a stream    
                    using (StreamWriter sw = new StreamWriter(cs))
                        sw.Write(plainText);
                    encrypted = ms.ToArray();
                }
            }
        }
        File.WriteAllBytes(fileEncrypted, encrypted);
        // Return encrypted data    
        return encrypted;// return to print in console WriteLine for only console!
    }
    static string Decrypt(byte[] Key, byte[] IV) //byte[] cipherText,
    {

        byte[] bytesToBeDecrypted = File.ReadAllBytes(fileEncrypted); // getting file content from DAT file
        
        string decryptedText = null;
        // Create AesManaged    
        using (AesManaged aes = new AesManaged())
        {
            // Create a decryptor    
            ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
            // Create the streams used for decryption.    
            using (MemoryStream ms = new MemoryStream(bytesToBeDecrypted)) // starts decripting from file
            {
                // Create crypto stream    
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    // Read crypto stream    
                    using (StreamReader reader = new StreamReader(cs))
                        decryptedText = reader.ReadToEnd();
                }
            }
        }
        return decryptedText;
    }
}
*/
