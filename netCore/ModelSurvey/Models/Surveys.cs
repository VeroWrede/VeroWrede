using System.ComponentModel.DataAnnotations;
namespace ModelSurvey.Models
{
    public class MySurvey{
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [MinLength(8)]
        [MaxLength(30)]
        public string Message { get; set; }
    }
}