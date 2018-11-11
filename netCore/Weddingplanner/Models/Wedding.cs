using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Weddingplanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get; set;}

        [Required(ErrorMessage = "Missing a wedder!")]
        [Display(Name = "Wedder")]
        public Person Wedder {get; set;}

        [Required(ErrorMessage = "Missing a wedder!")]
        [Display(Name = "Weddee")]
        public Person Weddee { get; set; }

        [Required(ErrorMessage = "When's the Wedding?")]
        [Display(Name = "Specail Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Address")]
        public string Address {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        public List<Attendance> Attendees {get; set;}

    }
}