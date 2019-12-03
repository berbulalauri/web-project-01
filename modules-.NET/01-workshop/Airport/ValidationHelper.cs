using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using workshop_02.Repositories;
using System.Linq;

namespace workshop_02
{
    public class ValidationHelper
    {
        private const decimal _minimumNumber = 3;
        private const decimal _minSubscriberAge = 14;
        private const string namePattern = @"^[\p{L} \.\-]{2,1115}$";
        private const string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public static bool IsNameValid(string name)
        {
            if (name.Length >= _minimumNumber)
            {
                if (Regex.IsMatch(name, namePattern))
                {
                    return name.Length >= _minimumNumber;
                }
            }
            return false;
        }
        public static bool validateFirstName(string frsname)
        {
            return Regex.IsMatch(frsname, namePattern);
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
            //var jsonRepo = new JsonFileRepository<List<Airport>>(Configuration.FileName);

            //var subscribersList = jsonRepo.Read();

            //if (subscribersList != null)
            //{
            //    return !subscribersList.Any(s => s.phoneNumber == phoneNumber);
            //}

            return true;

        }
    }
}

