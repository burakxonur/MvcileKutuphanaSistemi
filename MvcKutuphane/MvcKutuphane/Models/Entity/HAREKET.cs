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
    
    public partial class HAREKET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HAREKET()
        {
            this.CEZALAR = new HashSet<CEZALAR>();
        }
    
        public int ID { get; set; }
        public Nullable<int> KITAP { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<int> PERSONEL { get; set; }
        public Nullable<System.DateTime> ALISTARIH { get; set; }
        public Nullable<System.DateTime> IADETARIH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CEZALAR> CEZALAR { get; set; }
        public virtual KITAP KITAP1 { get; set; }
        public virtual UYELER UYELER { get; set; }
    }
}