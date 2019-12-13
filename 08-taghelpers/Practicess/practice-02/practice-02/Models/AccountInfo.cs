using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace practice_02.Models
{
    [Serializable]
    public class AccountInfo
    {
        public Guid ClientId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is Required!!")]
        [MinLength(2, ErrorMessage ="less Than 2 character")]
        [MaxLength(20, ErrorMessage ="more Than 20 character")]
        [RegularExpression(@"^[a-zA-Z]*", ErrorMessage = "no whtiespeces and special characters")]
        public string UserName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required!!")]
        [MinLength(6, ErrorMessage = "less Than 2 character")]
        [MaxLength(12, ErrorMessage = "more Than 20 character")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])(?=.*[^\da-zA-Z]).{6,12}$", ErrorMessage = "Password should consist of 6 to 12 characters string with at least one digitand one upper case letter, one special symbol.")]
        public string Password { get; set; }
        public string CodeQuestion { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Write only 30 symbols")]
        public string CodeAnswer { get; set; }

    }
}
