using System.ComponentModel.DataAnnotations;

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
        [Range(5, 2000)]
        [NoTeens]
        public int Age { get; set; }
        [EmailAddress]
        [Required]
        [IncludeA]
        public string Email { get; set; }
            //other code
        [DataType(DataType.Password)]
        [Required]
        [IncludeA]
        public string Password { get; set; }
         
        public class NoTeensAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if((int)value > 9 && (int)value < 20)
                    return new ValidationResult("No teenagers!");
                return ValidationResult.Success;
            }
        }
        public class IncludeAAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (!(value is string))
                    return new ValidationResult("this is not a string");
                string temp = (string)value; 
                string strValue = temp.ToLower();
                if(!strValue.Contains("a"))
                    return new ValidationResult("your missing an a!");
                return ValidationResult.Success;
            }
        }

    }
}