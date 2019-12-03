using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using project_01;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace tutorial_01
{
    class Program
    {
        private const string namePattern = @"^[\p{L} \.\-]{2,1115}$";
        private const string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public static bool validateFirstName(string frsname)
        {
            return Regex.IsMatch(frsname, namePattern);
        }

        public static bool validateEmailAddress(string emailaddress)
        {
            return Regex.IsMatch(emailaddress, emailPattern);
        }

        public static Holiday holiday = new Holiday { };
        public static CatCounter myCatCounter = new CatCounter { };
        public static CustomerRegistration customerReg = new CustomerRegistration { };

        public static object SHAHelper { get; private set; }

        public static void singUpMethod(int k)
        {
            string _holiday = $"../../../UserID_{k}.json";

            using (StreamWriter file = File.CreateText(_holiday))
            {
                JsonSerializer serializer = new JsonSerializer();
                holiday.Increment_Others_OWE_You = "";
                holiday.Decrement_You_OWE_Others = "";
                for (int i = 0; i < k; i++)
                {
                    holiday.Increment_Others_OWE_You += $"0 ";
                    holiday.Decrement_You_OWE_Others += $"0 ";
                }
                serializer.Serialize(file, holiday);
            }
        }
        public static void userupdate(int k, int IncrNumber)
        {
            string newString = "";
            string xreader = "";
            string _holiday = $"../../../UserID_{k}.json";

            Holiday Holiday1 = JsonConvert.DeserializeObject<Holiday>(File.ReadAllText(_holiday));
            using (StreamReader file = File.OpenText(_holiday))
            {
                JsonSerializer serializer = new JsonSerializer();
                Holiday movie2 = (Holiday)serializer.Deserialize(file, typeof(Holiday));
                xreader = movie2.Increment_Others_OWE_You;
            }

            List<string> listOfDouble = xreader.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            listOfDouble[k - 1] = IncrNumber.ToString();
            foreach (var item in listOfDouble)
            {
                newString += $"{item} ";

            }

            using (StreamWriter file = File.CreateText(_holiday))
            {
                JsonSerializer serializer = new JsonSerializer();
                holiday.Increment_Others_OWE_You = "";
                holiday.Increment_Others_OWE_You = $"{newString}";
                serializer.Serialize(file, holiday);
            }

        }


        public static void SeeUrTotalBalance(int currentUserId) 
        {
            string xreader = "";
            string xreader2 = "";
            int sumForIncrement = 0;
            int sumForDecrement = 0;
            int totalSum = 0;
            string UserPath = $"../../../UserID_{currentUserId}.json";
            Holiday readCatInfo = JsonConvert.DeserializeObject<Holiday>(File.ReadAllText(UserPath));
            using (StreamReader file = File.OpenText(UserPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                Holiday UsrFinInfo = (Holiday)serializer.Deserialize(file, typeof(Holiday));
                xreader = UsrFinInfo.Increment_Others_OWE_You;
                xreader2 = UsrFinInfo.Decrement_You_OWE_Others;
            }

            List<string> listOfDouble = xreader.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> listOfDouble2 = xreader2.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < listOfDouble.Count; i++)
            {
                int.TryParse(listOfDouble[i], out int digitOfIncrem);
                int.TryParse(listOfDouble2[i], out int digitOfDecrem);

                sumForIncrement = sumForIncrement + digitOfIncrem;
                sumForDecrement = sumForDecrement + digitOfDecrem;
            }
            totalSum = sumForIncrement - sumForDecrement;

            string creader1;
            string User_list = $"../../../User_list.json";
            using (StreamReader file = File.OpenText(User_list))
            {
                JsonSerializer serializer = new JsonSerializer();
                CustomerRegistration custRegOut = (CustomerRegistration)serializer.Deserialize(file, typeof(CustomerRegistration));
                creader1 = custRegOut.CustomerName;
            }
            List<string> listOfName = creader1.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();


            Console.WriteLine($"TOTAL BALANCE: {totalSum}$\n");
            for (int i = 0; i < listOfDouble.Count; i++)
            {
                int.TryParse(listOfDouble[i], out int digitOfInc);
                int.TryParse(listOfDouble2[i], out int digitOfDec);

                if (digitOfInc != 0) Console.WriteLine($"{listOfName[i]} Owes to you {digitOfInc}$");
                if (digitOfDec != 0) Console.WriteLine($"You Owe to {listOfName[i]} {digitOfDec}$");
            }

            
            Console.WriteLine("1.Add expense");
            Console.WriteLine("2.View history");
            Console.WriteLine("3.Exit");

            int.TryParse(Console.ReadLine(), out int switch_on);
            switch (switch_on)
            {
                case 1:
                    AddingExpense(currentUserId);
                    break;
                case 2:
                    string historycatPath = $"../../../history.txt";
                    string[] lines = System.IO.File.ReadAllLines(historycatPath);
                    foreach (string line in lines)
                    {
                        Console.WriteLine("\n" + line);
                    }

                    break;
                case 3:
                    //exit false
                    break;
                default:
                    break;
            }

        }

        public static void AddingExpense(int currentUserId)
        {
            Console.Write("How Much Money? ");
            int.TryParse(Console.ReadLine(), out int Moneyamount);


            string User_list = $"../../../User_list.json";
            string creader1;

            using (StreamReader file = File.OpenText(User_list))
            {
                JsonSerializer serializer = new JsonSerializer();
                CustomerRegistration custRegOut = (CustomerRegistration)serializer.Deserialize(file, typeof(CustomerRegistration));
                creader1 = custRegOut.CustomerName;
            }
            List<string> listOfName = creader1.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Console.WriteLine("Who was with you? Select id or ids from list: ");
            for (int i = 0; i < listOfName.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {listOfName[i]}");
            }

            Console.WriteLine("Your choice ? ");

            var userInputOnlyIDs = Console.ReadLine();
            string ParticipantUsers = userInputOnlyIDs;

            Console.WriteLine("Who paid the bill? Select id from list");
            for (int i = 0; i < listOfName.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {listOfName[i]}");
            }

            Console.WriteLine("Your choice ? ");
            int.TryParse(Console.ReadLine(), out int WhoPaidTheBillID);

            Console.WriteLine("Expense was created and divided equally"); //FIX
            Console.WriteLine("Press any key to return to the Home");
            int CurrWorkingUserID = currentUserId;
            var dateTime = DateTime.Now; 
            SaveToHistory(CurrWorkingUserID, ParticipantUsers, WhoPaidTheBillID, Moneyamount, dateTime); 

            UpdatingCustomerInfo(CurrWorkingUserID, ParticipantUsers, WhoPaidTheBillID, Moneyamount); 
        }
        public static void SaveToHistory(int CurrWorkingUserID, string ParticipantUsers, int WhoPaidTheBillID, int Moneyamount, DateTime dateTime)
        {
            string User_list = $"../../../User_list.json";
            string creader1;
            string historyMembersLine ="";
            string finalString ="";
            using (StreamReader file = File.OpenText(User_list))
            {
                JsonSerializer serializer = new JsonSerializer();
                CustomerRegistration custRegOut = (CustomerRegistration)serializer.Deserialize(file, typeof(CustomerRegistration));
                creader1 = custRegOut.CustomerName;
            }
            List<string> listOfName = creader1.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> participantsIds = ParticipantUsers.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < participantsIds.Count; i++)
            {
                int.TryParse(participantsIds[i],out int mm);

                historyMembersLine += $" {listOfName[mm]},";
            }

            finalString += $"ToTal Cost: {Moneyamount}\nDate: {dateTime}\nMembers:{historyMembersLine}\nPaid by:{WhoPaidTheBillID}\n";

            string historycatPath = $"../../../history.txt";
                using (StreamWriter writer = new StreamWriter(historycatPath, true))
                {
                    writer.Write(finalString);
                }

        }
        public static void CustomerInformationUpdater(){

            int catqty;
            string catPath = $"../../../category_create.json";
            CatCounter readCatInfo = JsonConvert.DeserializeObject<CatCounter>(File.ReadAllText(catPath));
            using (StreamReader file = File.OpenText(catPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                CatCounter catcount = (CatCounter)serializer.Deserialize(file, typeof(CatCounter));
                catqty = catcount.CatCounterInt;
            }
            for (int i = 0; i<catqty; i++)
            {
                UpdatingCustomerInfo(i+1);
            }
        }

        public static void UpdatingCustomerInfo(int currentID)
        {
            string NewIncString = "";
            string NewDecString = "";

            string xreader = "";
            string xreader2 = "";
            string _holiday = $"../../../UserID_{currentID}.json";

            Holiday Holiday1 = JsonConvert.DeserializeObject<Holiday>(File.ReadAllText(_holiday));
            using (StreamReader file = File.OpenText(_holiday))
            {
                JsonSerializer serializer = new JsonSerializer();
                Holiday movie2 = (Holiday)serializer.Deserialize(file, typeof(Holiday));
                Console.WriteLine(movie2);
                xreader = movie2.Increment_Others_OWE_You;
                xreader2 = movie2.Decrement_You_OWE_Others;
            }

            List<string> listOfDouble = xreader.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> listOfDouble2 = xreader2.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var newListForIncrement = new List<int>();
            var newListForDecrement = new List<int>();

            for (int i = 0; i < listOfDouble.Count; i++)
            {
                int.TryParse(listOfDouble[i], out int digitOfIncrem);
                int.TryParse(listOfDouble2[i], out int digitOfDecrem);
                var subtractRes = digitOfIncrem - digitOfDecrem;
                if (subtractRes > 0)
                {
                    newListForIncrement.Add(subtractRes);
                    newListForDecrement.Add(0);
                }
                else if (subtractRes < 0)
                {
                    newListForIncrement.Add(0);
                    newListForDecrement.Add(Math.Abs(subtractRes));
                }
                else if (subtractRes == 0)
                {
                    newListForIncrement.Add(0);
                    newListForDecrement.Add(0);
                }
            }

            for (int i = 0; i < listOfDouble.Count; i++)
            {
                NewIncString += $" {newListForIncrement[i]}";
                NewDecString += $" {newListForDecrement[i]}";
            }


            using (StreamWriter file = File.CreateText(_holiday))
            {
                JsonSerializer serializer = new JsonSerializer();
                holiday.Increment_Others_OWE_You = "";
                holiday.Decrement_You_OWE_Others = "";
                holiday.Increment_Others_OWE_You = $"{NewIncString}";
                holiday.Decrement_You_OWE_Others = $"{NewDecString}";
                serializer.Serialize(file, holiday);
            }

        }

        public static void UpdateUserWhenRegistering(int currentID, int MaxUserDetected)
        {
            string NewIncString = "";
            string NewDecString = "";
            string xreader = "";
            string xreader2 = "";
            string _holiday = $"../../../UserID_{currentID}.json";

            Holiday Holiday1 = JsonConvert.DeserializeObject<Holiday>(File.ReadAllText(_holiday));
            using (StreamReader file = File.OpenText(_holiday))
            {
                JsonSerializer serializer = new JsonSerializer();
                Holiday movie2 = (Holiday)serializer.Deserialize(file, typeof(Holiday));
                Console.WriteLine(movie2);
                xreader = movie2.Increment_Others_OWE_You;
                xreader2 = movie2.Decrement_You_OWE_Others;
            }

            List<string> listOfDouble = xreader.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> listOfDouble2 = xreader2.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var item in listOfDouble)
            {
                NewIncString += $" {item}";

            }
            foreach (var item in listOfDouble2)
            {
                NewDecString += $" {item}";

            }
            
            if(currentID< MaxUserDetected)
            {
                NewIncString = $"{NewIncString} 0";
                NewDecString = $"{NewDecString} 0";

            }

            using (StreamWriter file = File.CreateText(_holiday))
            {
                JsonSerializer serializer = new JsonSerializer();
                holiday.Increment_Others_OWE_You = "";
                holiday.Decrement_You_OWE_Others = "";
                holiday.Increment_Others_OWE_You = $"{NewIncString}";
                holiday.Decrement_You_OWE_Others = $"{NewDecString}";
                serializer.Serialize(file, holiday);
            }

        }
        public static void UpdatingCustomerInfo(int CurrWorkingUser, String ParticipantUsers, int WhoPaidTheBill,int Moneyamount) // int CurrWorkingUser, 
        {
            string newString = "";
            string StringOfUnchanged = "";
            string billPayerOfUnchangedDec = "";
            string billPayerNewString = "";
            string BillPayerInfo = "";
            string BillPayerInfoAboutDec = "";

            string decremNumber = "";
            string nonDecremNumber = "";
            string _holiday = "";
            Console.WriteLine("print 1");
            List<string> listOfparticipants = ParticipantUsers.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int loanToOthers = (Moneyamount /(1+ listOfparticipants.Count));
            int MoneyYouDeserve = listOfparticipants.Count * loanToOthers; //non-used val

            for (int i = 0; i < listOfparticipants.Count; i++)
            {
                BillPayerInfo = "";
                BillPayerInfoAboutDec = "";

                string billPayerJsonCont = $"../../../UserID_{WhoPaidTheBill}.json";

                int.TryParse(listOfparticipants[i], out int userIdIndex);
                _holiday = $"../../../UserID_{userIdIndex}.json";

                Holiday Holiday1 = JsonConvert.DeserializeObject<Holiday>(File.ReadAllText(_holiday));
                using (StreamReader file = File.OpenText(_holiday))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Holiday movie2 = (Holiday)serializer.Deserialize(file, typeof(Holiday));
                    decremNumber = movie2.Decrement_You_OWE_Others;
                    nonDecremNumber = movie2.Increment_Others_OWE_You;
                }

                Holiday Holiday2 = JsonConvert.DeserializeObject<Holiday>(File.ReadAllText(billPayerJsonCont));
                using (StreamReader file = File.OpenText(billPayerJsonCont))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Holiday billPayerSerializedContent = (Holiday)serializer.Deserialize(file, typeof(Holiday));
                    // Console.WriteLine(billPayerSerializedContent);
                    BillPayerInfo = billPayerSerializedContent.Increment_Others_OWE_You;
                    BillPayerInfoAboutDec = billPayerSerializedContent.Decrement_You_OWE_Others;
                }

                List<string> decrementableNumber = decremNumber.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> notDecrementableNumber = nonDecremNumber.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                int.TryParse(decrementableNumber[WhoPaidTheBill-1], out int Current_Amount_You_OWE_to_Event_PAYER);

                decrementableNumber[WhoPaidTheBill-1] = (Current_Amount_You_OWE_to_Event_PAYER + loanToOthers).ToString();
                newString = "";
                foreach (var item in decrementableNumber)
                {
                    newString += $" {item}";
                }

                StringOfUnchanged = "";
                foreach (var item1 in notDecrementableNumber)
                {
                    StringOfUnchanged += $" {item1}";
                }


                using (StreamWriter file = File.CreateText(_holiday))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    holiday.Increment_Others_OWE_You = "";
                    holiday.Decrement_You_OWE_Others = "";
                    holiday.Increment_Others_OWE_You = $"{StringOfUnchanged}";
                    holiday.Decrement_You_OWE_Others = $"{newString}";
                    serializer.Serialize(file, holiday);
                }


                List<string> listOfBillPayerInfo = BillPayerInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> listOfUnchangedAmount_Decrement = BillPayerInfoAboutDec.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                int.TryParse(listOfBillPayerInfo[userIdIndex-1], out int Current_Amount_Others_Owe_To_you);
                listOfBillPayerInfo[userIdIndex-1] = (Current_Amount_Others_Owe_To_you + loanToOthers).ToString();

                billPayerNewString = "";
                foreach (var item in listOfBillPayerInfo)
                {
                    billPayerNewString += $"{item} ";
                }
                billPayerOfUnchangedDec = "";
                foreach (var item in listOfUnchangedAmount_Decrement)
                {
                    billPayerOfUnchangedDec += $" {item}";
                }
                using (StreamWriter fileOfBillPayerSer = File.CreateText(billPayerJsonCont))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    holiday.Increment_Others_OWE_You = "";
                    holiday.Decrement_You_OWE_Others = "";
                    holiday.Increment_Others_OWE_You = $"{billPayerNewString}";
                    holiday.Decrement_You_OWE_Others = $"{billPayerOfUnchangedDec}";

                    serializer.Serialize(fileOfBillPayerSer, holiday);
                }
            }
            CustomerInformationUpdater(); //Updating All Customer Information
            SeeUrTotalBalance(CurrWorkingUser);
        }
        public static void saveCurrentCategoryState(int x)
        {
            string catPath = $"../../../category_create.json";
            using (StreamWriter file = File.CreateText(catPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                myCatCounter.CatCounterInt = 0;
                myCatCounter.CatCounterInt = x;
                serializer.Serialize(file, myCatCounter);
            }
        }
        public static void SignInConstructor()
        {

            var passcls = new PasswordCoverClass();
            var saltString = "COJV34";
            var saltedPassword = "";
            string creader1;
            string creader2;
            string User_list;

            int numkeeper = 0;
            bool mailChecker = true;
            User_list = $"../../../User_list.json";

            using (StreamReader file = File.OpenText(User_list))
            {
                JsonSerializer serializer = new JsonSerializer();
                CustomerRegistration custRegOut = (CustomerRegistration)serializer.Deserialize(file, typeof(CustomerRegistration));
                creader1 = custRegOut.CustomerEmail;
                creader2 = custRegOut.CustomerPass;
            }
            List<string> listOfName = creader1.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> listOfPass1 = creader2.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            do
            {
                Console.WriteLine("\n------------------------Sign In------------------------");
                Console.Write("Your email: ");
                var emailAddress = Console.ReadLine();
                for (int i = 0; i < listOfName.Count; i++)
                {
                    if (emailAddress == listOfName[i])
                    {
                        numkeeper = i;
                        mailChecker = false;
                    }
                }
                if (mailChecker) { Console.WriteLine("E-mail is incorect. Please Write Correct Email Address"); }
            } while (mailChecker);

            passcls.passwordCover();
            var hashedpasswd1 = passcls.hashedPassRtnr();
            var computedHash1 = Hashsha1(hashedpasswd1);
            saltedPassword = Hashsha1(computedHash1 + saltString);

            while (saltedPassword != listOfPass1[numkeeper])
            {
                Console.WriteLine("YOUR PASSWORD IS INCORRECT. PLEASE TRY AGAIN!");
                passcls.passwordCover();
                hashedpasswd1 = passcls.hashedPassRtnr();
                computedHash1 = Hashsha1(hashedpasswd1);
                saltedPassword = Hashsha1(computedHash1 + saltString);
            }

            Console.WriteLine($"Welcome, {listOfName[numkeeper]}!");

            SeeUrTotalBalance(numkeeper+1);

        }
        public static void SignUpConstructor()
        {
            var passcls = new PasswordCoverClass();
            var saltString = "COJV34";
            var saltedPassword = "";

            int catqty = 0;
            int sup = 1;

            string creader1;
            string creader2;
            string creader3;
            string creader4;

            Console.WriteLine("------------------------Sign Up------------------------");
            Console.Write("\nInput name: ");
            var firstName = Console.ReadLine();
            while (!validateFirstName(firstName))
            {
                Console.Write("\nName is not valid! Please try again!\nInput name: ");
                firstName = Console.ReadLine();
            }

            Console.Write("\nYour E-mail Address: ");
            var emailAddress = Console.ReadLine();
            while (!validateEmailAddress(emailAddress))
            {
                Console.Write("\nE-mail Address is not valid! Please try again!\nYour E-mail Address: ");
                emailAddress = Console.ReadLine();
            }

            passcls.passwordCover();
            var hashedpasswd = passcls.hashedPassRtnr();
            var computedHash = Hashsha1(hashedpasswd);
            saltedPassword = Hashsha1(computedHash + saltString);
            Console.WriteLine("Registration was completed.");


            string textToAdd = "{\"CatCounterInt\":0}";
            string catPath = $"../../../category_create.json";
            if (!File.Exists(catPath))
            {
                using (StreamWriter writer = new StreamWriter(catPath, true))
                {
                    writer.Write(textToAdd);
                }
            }
            CatCounter catdeser = JsonConvert.DeserializeObject<CatCounter>(File.ReadAllText(catPath));
            using (StreamReader file = File.OpenText(catPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                CatCounter catcount = (CatCounter)serializer.Deserialize(file, typeof(CatCounter));
                catqty = catcount.CatCounterInt;
            }
            if (catqty == 0)
            {
                singUpMethod(1);
                saveCurrentCategoryState(1);
            }
            else
            {
                sup = catqty;
                sup++;
                singUpMethod(sup);
                for (int i = 1; i < sup + 1; i++)
                {
                    UpdateUserWhenRegistering(i, sup);
                }
                saveCurrentCategoryState(sup);
            }


            string NewLineOfId = "";
            string NewLineOfName = "";
            string NewLineOfEmail = "";
            string NewLineOfPass = "";

            creader1 = "";
            creader2 = "";
            creader3 = "";
            creader4 = "";

            string User_list = $"../../../User_list.json";

            if (!File.Exists(User_list))
            {
                using (StreamWriter file = File.CreateText(User_list))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    customerReg.CustomerId = $"{sup}";
                    customerReg.CustomerName = $"{firstName}";
                    customerReg.CustomerEmail = $"{emailAddress}";
                    customerReg.CustomerPass = $"{saltedPassword}";
                    serializer.Serialize(file, customerReg);
                }

            }
            else
            {
                CustomerRegistration CustomerRegister1 = JsonConvert.DeserializeObject<CustomerRegistration>(File.ReadAllText(User_list));
                using (StreamReader file = File.OpenText(User_list))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    CustomerRegistration custRegOut = (CustomerRegistration)serializer.Deserialize(file, typeof(CustomerRegistration));
                    creader1 = custRegOut.CustomerId;
                    creader2 = custRegOut.CustomerName;
                    creader3 = custRegOut.CustomerEmail;
                    creader4 = custRegOut.CustomerPass;
                }

                List<string> listOfId = creader1.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> listOfName = creader2.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> listOfEmail = creader3.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> listOfPass = creader4.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();



                foreach (var item in listOfId) { NewLineOfId += $" {item}"; }
                foreach (var item in listOfName) { NewLineOfName += $" {item}"; }
                foreach (var item in listOfEmail) { NewLineOfEmail += $" {item}"; }
                foreach (var item in listOfPass) { NewLineOfPass += $" {item}"; }


                NewLineOfId = $"{NewLineOfId} {sup}";
                NewLineOfName = $"{NewLineOfName} {firstName}";
                NewLineOfEmail = $"{NewLineOfEmail} {emailAddress}";
                NewLineOfPass = $"{NewLineOfPass} {saltedPassword}";

                using (StreamWriter file = File.CreateText(User_list))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    customerReg.CustomerId = $"{NewLineOfId}";
                    customerReg.CustomerName = $"{NewLineOfName}";
                    customerReg.CustomerEmail = $"{NewLineOfEmail}";
                    customerReg.CustomerPass = $"{NewLineOfPass}";

                    serializer.Serialize(file, customerReg);
                }

            }
            SignInConstructor(); //Calling SignIn ctor to check our ID
        }

        static void Main(string[] args)
        {
            String ParticipantUsers;
            int CurrWorkingUserID;

            var passcls = new PasswordCoverClass();
            var saltString = "COJV34";
            var saltedPassword = "";

            int catqty = 0;
            int sup = 1;
            int jj = 0;
            bool loopControl = true;


            string creader1;
            string creader2;
            string creader3;
            string creader4;
            string User_list;


            try
            {
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");
                while (loopControl)
                {
                    Console.Write("please Select: ");
                    int.TryParse(Console.ReadLine(), out int userSelect);
                    switch (userSelect)
                    {
                        case 1:
                            SignInConstructor();
                            break;
                        case 2:
                            SignUpConstructor();
                            break;
                        case 3:
                            loopControl = false;
                            break;

                        default:
                            break;
                    }
                }
  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something went wrong {ex.Message}");

            }
        }
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
    [Serializable]
    public class CustomerRegistration
    {
        public string CustomerId { get; set; }
        public String CustomerEmail { get; set; }
        public String CustomerName { get; set; }
        public String CustomerPass { get; set; }
        public override string ToString()
        {
            return $"";
        }

    }
    [Serializable]
    public class Holiday
    {
        public string Increment_Others_OWE_You { get; set; }
        public string Decrement_You_OWE_Others { get; set; }
        public override string ToString()
        {
            return $"";
        }

    }
    [Serializable]
    public class CatCounter
    {
        public int CatCounterInt { get; set; }
        public override string ToString()
        {
            return $"";
        }


    }

}

