using tutorial_01.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_01.Models
{
    public class Game
    {
        [MaxLength(60,ErrorMessage ="No more than 60 brooo:)))")]
        [MinLength(3,ErrorMessage ="no less than 3 :))))")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "its requierd bro:)))")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "its requierd bro:)))")]
        public DateTime ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "its requierd bro:)))")]
        public decimal Price { get; set; }


        [MaxLength(30, ErrorMessage ="no more than 30 characters")]
        [RegularExpression (@"^[A-Z][A-z]*",ErrorMessage ="first letter big! no whtiespeces and special characters") ]
        [Required(AllowEmptyStrings = false, ErrorMessage = "its requierd bro:)))")]
        public string Genre { get; set; }

        [RatingValidator(true)]
        public string Rating { get; set; }
    }
}
