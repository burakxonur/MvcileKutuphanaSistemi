﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcKutuphaneEntities1 : DbContext
    {
        public MvcKutuphaneEntities1()
            : base("name=MvcKutuphaneEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CEZALAR> CEZALAR { get; set; }
        public virtual DbSet<HAREKET> HAREKET { get; set; }
        public virtual DbSet<KASA> KASA { get; set; }
        public virtual DbSet<KATEGORI> KATEGORI { get; set; }
        public virtual DbSet<KITAP> KITAP { get; set; }
        public virtual DbSet<PERSONEL> PERSONEL { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UYELER> UYELER { get; set; }
        public virtual DbSet<YAZAR> YAZAR { get; set; }
    }
}
