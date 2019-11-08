using System;

class MainClass
{
    public static bool isVowel(char letter)
    {
        bool myval = false;
        string[] vowelarr = new string[6] { "a", "e", "i", "o", "u", "y" };
        for (int i = 0; i < vowelarr.Length; i++)
        {
            if (letter.ToString() == vowelarr[i]) { myval = true; }
        }
        return myval;
    }
    public static void Main(string[] args)
    {
        int m = 0;
        Console.WriteLine("input string: ");
        var text = Console.ReadLine();
        char[] Arr = text.ToCharArray();
        for (int k = 0; k < Arr.Length; k++)
        {
            if (isVowel(Arr[k])) { m++; }
        }
        Console.WriteLine($"Number of vowels: {m}");

    }
}

