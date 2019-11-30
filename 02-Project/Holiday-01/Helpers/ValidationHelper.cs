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
        private const decimal _minimumNumber = 3;

        private const string countryCodePattern = @"^[\p{L} \.\-]{2,4}$";

        private const string namePattern = @"^[\p{L} \.\-]{3,1000}$";
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
        public static bool CountryCodeValid(string name)
        {
            if (name.Length <= _minimumNumber)
            {
                if (Regex.IsMatch(name, countryCodePattern))
                {
                    return name.Length <= _minimumNumber;
                }
            }
            return false;
        }

    }
}
