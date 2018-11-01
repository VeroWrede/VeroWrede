using System;
using System.ComponentModel.DataAnnotations;

namespace Lost.Models
{
    public class Trail
    {
        [Key]
        public int TrailId { get; set;}
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name:")]
        [MinLength(10)]
        public string Name {get; set;}
        [Required(ErrorMessage = "Description is required")]
        [MinLength(10)]
        public string Description {get; set;}
        [Required(ErrorMessage = "Length is required")]
        public float Length {get; set;}
        [Required]
        public float ElevationGain {get; set;}
        [Required]
        public float Longitude {get; set;}
        [Required]
        public float Latitude {get; set;}
        [Required]
        public DateTime CreatedAt {get; set;}
        [Required]
        public DateTime UpdatedAt {get; set;}
    }
}