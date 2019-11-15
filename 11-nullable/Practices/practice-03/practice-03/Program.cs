using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace practice_03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool whileLoop = true;
            while (whileLoop)
            {
                Myform.AskQuestins();
                Console.WriteLine("Do You Want to continue? Y/N");
                if(Console.ReadLine() == "y") { whileLoop = true; } else { whileLoop = false; }
            }
        }
    }
    public class Myform
    {
        public static int counter { get; set; }
        string Name { get; set; }
        public static string nameInput { get; set; }
        public static DateTime? DateOfBirth { get; set; }
        public static int? CountOfChildrens { get; set; }
        public static int? CountOfPets { get; set; }
        public static bool? AreProposalEmailsNeeded { get; set; }
        public static bool nameCheck { get; set; }

        public static Dictionary<int, (string a, DateTime? b, int? c, int? d, bool? e)> mydict = new Dictionary<int, (string a, DateTime? b, int? c, int? d, bool? e)>();

        public bool whileLoop = true;
        public static void AskQuestins()
        {
            nameCheck = true;
            while (nameCheck)
            {
                Console.WriteLine("Input your name:");
                nameInput = Console.ReadLine();
                nameCheck = string.IsNullOrEmpty(nameInput);
                if (nameCheck) { Console.WriteLine("Name is required! Let's try one more time"); }
            }

            Console.WriteLine("Input your date of birth: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime userDate);
            DateOfBirth = userDate;

            Console.WriteLine("How many childrens do you have? ");
            int.TryParse(Console.ReadLine(), out int userChildCount);
            CountOfChildrens = userChildCount;

            Console.WriteLine("How many pets do you have?");
            int.TryParse(Console.ReadLine(), out int userPetCount);
            CountOfPets = userPetCount;

            Console.WriteLine("Do you want to get proposal emails ? Y/N");
            var emailAnswer = Console.ReadLine();

            if (emailAnswer == "y") { AreProposalEmailsNeeded = true; } else { AreProposalEmailsNeeded = true; }
            if (emailAnswer == "n") { AreProposalEmailsNeeded = false; }

            Myform index = new Myform(nameInput, DateOfBirth, CountOfChildrens, CountOfPets, AreProposalEmailsNeeded);

        }
        public Myform(string a, DateTime? b, int? c, int? d, bool? e)
        {
            counter = ++counter;
            mydict[counter] = (a,  b,  c,  d,  e);
            printer(mydict);
        }
        
        public void printer(IEnumerable<KeyValuePair<int, (string a, DateTime? b, int? c, int? d, bool? e)>> dict)
        {
            foreach (KeyValuePair<int, (string a, DateTime? b, int? c, int? d, bool? e)> item in dict)
            {
                Console.WriteLine("==================================");
                Console.WriteLine("  |{0} | {1} | {2} | {3} | {4}|", item.Value.a, item.Value.b, item.Value.c, item.Value.d,item.Value.e);
                Console.WriteLine("==================================");
            }
        }

    }


}
