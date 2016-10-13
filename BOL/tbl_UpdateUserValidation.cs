using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public partial class tbl_UpdateUserValidation
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

     

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
        public string PhoneNumber
        {
            get; set;
        }
    }
}
