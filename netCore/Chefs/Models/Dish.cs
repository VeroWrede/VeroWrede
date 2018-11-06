using System;
using System.ComponentModel.DataAnnotations;

namespace Chefs.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public int CookId  { get; set;}

        [Required(ErrorMessage = "Name required")]
        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        [Display(Name = "Made By ")]

        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Include Calories")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Description missing")]
        [MinLength(10)]
        [Display(Name = "About this Dish:")]

        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public Cook Cook { get; set; }
    }
}