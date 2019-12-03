using System;

// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net
namespace StringToMorseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToChange = "";
            Console.Write("Enter text that you want to convert to Morse code: ");
            textToChange = Console.ReadLine();
            textToChange = textToChange.ToLower();
            EncoderToMorse encode = new EncoderToMorse(textToChange);
        }
        public class EncoderToMorse
        {
            public EncoderToMorse(string textToChange)
            {
                string newText = "";
                char[] letters = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '!' };
                string[] morseLetters = { "    ", ". ___", "___ . . .", "___ . ___ .", "___ . .", ".", ". . ___ .", "___ ___ .", ". . . .", ". .", ". ___ ___ ___", "___ . ___", ". ___ . .", "___ ___", "___ .", "___ ___ ___", ". ___ ___ .", "___ ___ . ___", ". ___ .", ". . .", "_", ". . ___", ". . . ___", ". ___ ___", "___ . . ___", "___ . ___ ___", "___ ___ . .", ". ___ ___ ___ ___", ". . ___ ___ ___", ". . . ___ ___", ". . . . ___", ". . . . .", "___ . . . .", "___ ___ . . .", "___ ___ ___ . .", "___ ___ ___ ___ .", "___ ___ ___ ___ ___", "_._.__" };
                for (int i = 0; i < textToChange.Length; i++)
                {
                    for (short j = 0; j < 37; j++)
                    {
                        if (textToChange[i] == letters[j])
                        {
                            newText += morseLetters[j];
                            newText += "   ";
                            break;
                        }
                    }
                }
                Console.WriteLine("Text in Morse Code");
                Console.WriteLine(newText);
            }
        }
    }
}