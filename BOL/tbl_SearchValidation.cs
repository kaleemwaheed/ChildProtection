using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_SearchValidation
    {   
        public int? id { get; set; }
        public string ChildName { get; set; }
        public string ChildAlternativeName { get; set; }
         public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Glasses { get; set; }
        public string IdentityMark { get; set; }
        public string Shirt { get; set; }
        public string Trouser_Skert { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string IdentificationMarkOnBody { get; set; }
    }
    //[MetadataType(typeof(tbl_SearchValidation))]
    //public partial class tbl_ChildInfo
    //{

    //}
}

