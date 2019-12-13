using practice_02.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Models
{
    public class Student
    {
        public Guid AccountGuidId { get; set; }
        [MinLength(2,ErrorMessage ="no less than 2")]
        [RegularExpression (@"^[A-Z][a-z]*",ErrorMessage ="first letter big! no whtiespeces and special characters") ]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is Required!!")]
        public string FirstName { get; set; }

        
        [MinLength(2,ErrorMessage ="no less than 2")]
        [RegularExpression (@"^[A-Z][a-z]*",ErrorMessage ="first letter big! no whtiespeces and special characters") ]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname is Required!!")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Course number is Required. Course must be integer!")]
        public int CourseCount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "BirthDate Is Required!")]
        public DateTime BirthDate { get; set; }

        [MinLength(3,ErrorMessage ="No Less Than 3")]
        [EmailAddress]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required!!")]
        public string Email { get; set; }

        [MinLength(6,ErrorMessage ="No Less Than 6")]
        [MaxLength(12,ErrorMessage ="No More Than 12")]
        [RegularExpression (@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-])(?=.*[^\da-zA-Z]).{6,12}$", ErrorMessage = "Password should consist of 6 to 12 characters string with at least one digitand one upper case letter, one special symbol.") ]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required!!")]
        public string Password { get; set; }

    }
}
