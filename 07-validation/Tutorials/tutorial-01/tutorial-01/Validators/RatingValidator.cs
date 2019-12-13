using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tutorial_01.Validators
{
    public class RatingValidator : ValidationAttribute
    {
        private const int MaxSize = 5;
        private bool firstUpper;
        public RatingValidator(bool firstUpper)
        {
            this.firstUpper = firstUpper;
        }



        public override bool IsValid(object value)
        {
            var ValidationResult = true;
            if (value != null && value is string)
            {
                var strVal = value as string;
                var regex = new Regex( firstUpper ?  @"[A-Z].*" : @"[a-Z].*" );

                ValidationResult = strVal.Length <= MaxSize && !string.IsNullOrWhiteSpace(strVal) && regex.IsMatch(strVal);

                return ValidationResult;
            }
            return false;
        }
    }
}
