using System;
using workshop2.Tariffs;
using Newtonsoft.Json;
using System.Threading.Tasks;
using workshop2.Helpers;

namespace workshop2
{
    public class Holiday
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public DateTime LaunchYear { get; set; }
        public DateTime Date { get; set; }
        public bool IsFixed { get; set; }
        public bool IsGlobal { get; set; }

        public string CommonNameFromApi { get; set; }
        public string CountryCodeFromApi { get; set; }
        public string OfficalNameFromApi { get; set; }

        [JsonIgnore]
        public ITariff Tariff { get; set; }
        public string phoneNumber { get; set; }

        private const decimal _initialNumber = 50;
        public Holiday()
        {
        }

        public Holiday(string name,string countryCode, DateTime date, bool isFixed, bool isGlobal, DateTime launchYear)
        {
            Name = name;
            CountryCode = countryCode;
            LaunchYear = launchYear;
            Date = date;
            IsFixed = isFixed;
            IsGlobal = isGlobal;
        }

        //public Holiday(string firstName, string lastName, string passportId, DateTime dob, bool isInternetNeed)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    PassportId = passportId;
        //    DateOfBirth = dob;
        //    Balance = 50;
        //    IsNeedInternet = isInternetNeed;
        //    Tariff = isInternetNeed ? (ITariff)new ZipperTariff() : (ITariff)new CheetahTariff();
        //    phoneNumber = GeneratePhoneNumber();
        //}

        public override string ToString()
        {
            return $"Name: {Name} \n " +
                $"CountryCode: {CountryCode} \n " +
                $"LaunchYear: {LaunchYear} \n " +
                $"Date: {Date} \n " +
                $"IsFixed: {IsFixed} \n " +
                $"IsGlobal: {IsGlobal} \n " +
            $"{Environment.NewLine} Tariff: {Tariff} ";
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

        public async Task GenerateSubscriber()
        {
            var names = await ApiHelper.GetNameAsync();

            //Random random = new Random();
            //Tariff = new BasicTariff();
            //IsNeedInternet = true;
            //DateOfBirth = new DateTime(random.Next(1935, 2004), random.Next(1, 20), random.Next(1, 28));
            //PassportId = "XX0000";
            OfficalNameFromApi = names.Item1;
            CommonNameFromApi = names.Item2;
            CountryCodeFromApi = names.Item3;
        }

    }
}
