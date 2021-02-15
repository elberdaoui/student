using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentOneMethod.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name ="CIN")]
        public string CIN { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
