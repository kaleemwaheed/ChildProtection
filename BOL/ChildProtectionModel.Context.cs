﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChildProtectionDbEntities : DbContext
    {
        public ChildProtectionDbEntities()
            : base("name=ChildProtectionDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_User> tbl_User { get; set; }
        public virtual DbSet<tbl_ChildInfo> tbl_ChildInfo { get; set; }
        public virtual DbSet<tbl_SuspectPersonInformation> tbl_SuspectPersonInformation { get; set; }
        public virtual DbSet<tbl_ParentInformation> tbl_ParentInformation { get; set; }
        public virtual DbSet<tbl_Profile> tbl_Profile { get; set; }
    }
}
