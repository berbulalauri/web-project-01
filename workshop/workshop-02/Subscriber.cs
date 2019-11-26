using System;
using workshop2.Tariffs;
using Newtonsoft.Json;

namespace workshop2
{
    public class Subscriber
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Balance { get; private set; }
        public bool IsNeedInternet { get; set; }
        [JsonIgnore]
        public ITariff Tariff { get; set; }
        public string phoneNumber { get; set; }

        private const decimal _initialNumber = 50;
        public Subscriber()
        {
            Balance = 50;
        }

        public Subscriber(string firstName, string lastName, string passportId, DateTime dob, bool isInternetNeed)
        {
            FirstName = firstName;
            LastName = lastName;
            PassportId = passportId;
            DateOfBirth = dob;
            Balance = 50;
            IsNeedInternet = isInternetNeed;
            Tariff = isInternetNeed ? (ITariff)new ZipperTariff() : (ITariff)new CheetahTariff();
            phoneNumber = GeneratePhoneNumber();
        }

        public override string ToString()
        {
            return $"Subscriber {FirstName} {LastName}, passport {PassportId}, DOB: {DateOfBirth}" +
                    $"{Environment.NewLine} phone Number: {phoneNumber}" +
                    $"{Environment.NewLine} Tariff: {Tariff} ";
        }
        public void TopUpBalance(decimal amount)
        {
            Balance += _initialNumber;
        }

        private string GeneratePhoneNumber()
        {
            var minNumber = 518000000;
            var maxNumber = 599999999;
            var numPrefix = "+995";
            var rand = new Random();
            var randomNext = rand.Next(minNumber, maxNumber);
            var result = $"{numPrefix}{randomNext}";
            if (ValidationHelper.IsPhoneNumberUnique(result))
            {
                Logger.Log("Subscriber.GeneratePhoneNumber", $" Generated phone number {result}" );
                return result;
            }

                Logger.Log("Subscriber.GeneratePhoneNumber", $" Generated phone number {result} is not unique" );
                return GeneratePhoneNumber();

        }
    }
}
