using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email Address:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Invalid Password")]
        [MinLength(8, ErrorMessage = "At least 8 chars long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatetAt { get; set; } = DateTime.Now;
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
        
    }
}