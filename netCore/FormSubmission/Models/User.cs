using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(1)]
        public string LastName { get; set; }
        [Range(10, 2000)]
        public int Age { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}