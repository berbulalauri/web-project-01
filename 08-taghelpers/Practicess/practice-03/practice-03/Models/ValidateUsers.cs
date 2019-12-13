using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace practice_03.Models
{
    public class ValidateUsers
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is Required!!")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required!!")]
        public string Password { get; set; }

    }
}
