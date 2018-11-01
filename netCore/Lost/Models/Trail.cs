using System;
using System.ComponentModel.DataAnnotations;

namespace Lost.Models
{
    public class Trail
    {
        [Key]
        public int TrailId { get; set;}
        [Required]
        [Display(Name = "Name:")]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
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