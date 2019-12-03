using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using workshop2.Repositories;
using System.Linq;

namespace workshop2
{
    public class ValidationHelper
    {
        private const decimal _minimumNumber = 2;
        private const decimal _minSubscriberAge = 14;

        public static bool IsNameValid(string name)
        {
            return name.Length >= _minimumNumber;
        }

        public static bool IsPassportIsValid(string passportId)
        {
            return new Regex(@"^[A-z]{2}[0-9]{6}$").IsMatch(passportId);
        }

        public static bool IsDateOfBirthValid(DateTime dob)
        {
            return DateTime.Now.Year - dob.Year >= _minSubscriberAge;
        }

        public static bool IsPhoneNumberUnique(string phoneNumber)
        {
            var jsonRepo = new JsonFileRepository<List<Holiday>>(Configuration.FileName);

            var subscribersList = jsonRepo.Read();

            if (subscribersList != null)
            {
                return !subscribersList.Any(s => s.phoneNumber == phoneNumber);
            }

            return true;

        }
    }
}
