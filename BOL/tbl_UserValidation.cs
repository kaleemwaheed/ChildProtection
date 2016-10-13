using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ChildProtectionDbEntities db = new ChildProtectionDbEntities();
            if (value != null)
            {
                string userEmailValue = value.ToString();
                int count = db.tbl_User.Where(x => x.UserEmail == userEmailValue).ToList().Count();

                if (count != 0)
                    return new ValidationResult("User Exist");
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Form Not Filled");
            }
           
        }
    }
    public class tbl_UserValidation
    {
        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
        [Required]
        public string StationName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Range(typeof(Int64), "03000000000", "09999999999", ErrorMessage = "Must be 03XX1234567 characters long.")]
        public string PhoneNumber { get; set; }
    }
    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User
    {
        public string  ConfirmPassword { get; set; }
    }
}
