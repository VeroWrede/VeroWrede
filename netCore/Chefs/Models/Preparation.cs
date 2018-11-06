using System.ComponentModel.DataAnnotations;
using System;

namespace Chef.Models
{
    public class Preparation
    {
        [Key]
        public int PreparationId { get; set; }
        public int DishId { get; set; }
        public int CookId { get; set; }
        // public Dish DishBy { get; set; }
        // public Cook Cook { get; set; }

    }
}