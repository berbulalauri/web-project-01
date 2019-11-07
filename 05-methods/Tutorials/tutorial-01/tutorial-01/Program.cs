using System;

namespace tutorial_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the sentence: ");
            var userSentence = Console.ReadLine();
            var wordNumber = CalculateWords(userSentence);
            Console.WriteLine("word count: "+wordNumber);

        }
        public static int CalculateWords(string sentence)
        {
            var wordsArray = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var wordsCount = wordsArray.Length;
            return wordsCount;
        }

    }
}
