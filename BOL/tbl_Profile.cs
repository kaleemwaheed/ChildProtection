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
    
    public partial class tbl_Profile
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string StationName { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual tbl_User tbl_User { get; set; }
    }
}
