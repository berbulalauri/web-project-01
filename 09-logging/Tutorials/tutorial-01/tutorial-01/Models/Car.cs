using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial_01.Models
{
    public class Car
    {
        [Required]
        [MinLength(2, ErrorMessage ="less Than 2 character")]
        [MaxLength(20, ErrorMessage ="more Than 20 character")]
        public string Name { get; set; }
        [Required]
        [Range(10,500, ErrorMessage ="out of range of 10 - 500")]
        public int MaxSpeed { get; set; }
    }
}
