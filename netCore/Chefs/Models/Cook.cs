using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chefs.Models
{
    public class Cook
    {
        [Key]
        public int CookId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "invalid DOB")]
        [AtLeast18]
        [Display(Name = "Date of Birth:")]
        public DateTime DOB { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int Age
        {
            get { return DateTime.Now.Year - DOB.Year; }
        }

        public string FullName 
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public List<Dish> Dishes { get; set; }
        public int NumberOfDishes { get; set; }
    }
}