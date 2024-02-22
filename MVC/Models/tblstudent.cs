using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MVC.Models
{
    public class tblstudent
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must be between 1 and 50 characters", MinimumLength = 1)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DOBValidation(ErrorMessage = "Invalid date of birth. Must be at least 18 years old.")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Please select a radio button option.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = " address is required.")]
        [StringLength(10, ErrorMessage = "Street address must be at most 10 characters long.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "langauges is required")]
        public string Languages { get; set; }
        [Required(ErrorMessage = "Course name is required")]
        public int Course { get; set; }
        [Required(ErrorMessage = "image name is required")]
        public string PhotoPath { get; set; }
        [Required(ErrorMessage = "document name is required")]
        public string DocumentPath { get; set; }

        [RegularExpression(@"^\+?\d{0,4}[-. ]?\(?\d{1,}\)?[-. ]?\d{1,}[-. ]?\d{1,}$", ErrorMessage = "Please enter a valid phone number.")]
        public BigInteger PhoneNumber { get; set; }

        public string Email {get;set;}
    }

public class DOBValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime Dob = (DateTime)value;
            int age = DateTime.Now.Year - Dob.Year;

            // Check if the age is at least 18
            if (age < 18)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }


    }
