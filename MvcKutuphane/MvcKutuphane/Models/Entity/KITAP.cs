//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class KITAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KITAP()
        {
            this.HAREKET = new HashSet<HAREKET>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public Nullable<byte> KATEGORI { get; set; }
        public Nullable<int> YAZAR { get; set; }
        public string BASIMYIL { get; set; }
        public string YAYINEVI { get; set; }
        public string SAYFA { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HAREKET> HAREKET { get; set; }
        public virtual KATEGORI KATEGORI1 { get; set; }
        public virtual YAZAR YAZAR1 { get; set; }
    }
}
