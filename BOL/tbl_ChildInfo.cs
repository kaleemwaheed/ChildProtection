//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ChildInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ChildInfo()
        {
            this.tbl_ParentInformation = new HashSet<tbl_ParentInformation>();
        }
    
        public int ChildId { get; set; }
        public string ChildName { get; set; }
        public string ChildAlternativeName { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Glasses { get; set; }
        public string IdentityMark { get; set; }
        public string IdentificationMarkOnBody { get; set; }
        public string Shirt { get; set; }
        public string Trouser_Skert { get; set; }
        public string imageUrl { get; set; }
        public Nullable<System.DateTime> Child_Missing_Date_Time { get; set; }
        public string IsApproved { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Report_by_Person_Name { get; set; }
        public Nullable<long> CNIC { get; set; }
        public string Address { get; set; }
        public string Phone_ { get; set; }
        public string Email { get; set; }
        public string Relation_to_Missing_Child { get; set; }
        public string Father_Name { get; set; }
        public string Address_Of_Child { get; set; }
        public string Phone__ { get; set; }
        public Nullable<System.DateTime> Report_Created_Date_Time { get; set; }
        public string PoliceStationEmail { get; set; }
        public string PoliceStation { get; set; }
        public string ChildMissingLocation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ParentInformation> tbl_ParentInformation { get; set; }
    }
}
