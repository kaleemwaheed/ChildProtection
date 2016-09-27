using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_ChildInfoValidation
    {   [Required]
        public string ChildName { get; set; }
        [Required]
        public Nullable<int> Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Build { get; set; }
        [Required]
        public string HairColor { get; set; }
        [Required]
        public string EyeColor { get; set; }
        [Required]
        public string Glasses { get; set; }
        [Required]

        public Nullable<System.DateTime> Child_Missing_Date_Time { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Report_by_Person_Name { get; set; }
        [Required]
        [Range(typeof(Int64), "1000000000000", "9999999999999" , ErrorMessage = "Must be 13 characters long.")]
        public Nullable<long> CNIC { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Range(typeof(Int64) , "03000000000", "09999999999" , ErrorMessage = "Must be 03XX1234567 characters long.")]
      
        public string Phone_ { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Relation_to_Missing_Child { get; set; }
        [Required]
        public string Father_Name { get; set; }
        [Required]
        public string Address_Of_Child { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Range(typeof(Int64), "03000000000", "09999999999", ErrorMessage = "Must be 03XX1234567 characters long.")]
        public string Phone__ { get; set; }


    }
    [MetadataType(typeof(tbl_ChildInfoValidation))]
    public partial class tbl_ChildInfo
    {

    }
}
