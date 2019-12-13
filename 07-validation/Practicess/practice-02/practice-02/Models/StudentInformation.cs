using practice_02.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace practice_02.Models
{
    public class StudentInformation
    {
        public Guid AccountGuidId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseCount { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is Required!!")]
        [RegularExpression(@"^\(?([0-9]{9})\)?$", ErrorMessage = "Not a Valid Phone Number, Use Only 9 Symbols!")]
        [Phone(ErrorMessage = "Phone Number Must Be a Valid Phone Number!")]
        public int PhoneNumber { get; set; }
        public List<string> Disciplines { get; set; }
        [MaxLength(255, ErrorMessage ="Write less than 255 symbols!")]
        public string Autobiography { get; set; }

    }
}
