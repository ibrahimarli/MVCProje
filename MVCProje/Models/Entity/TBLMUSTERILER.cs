//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCProje.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERILER()
        {
            this.TBLSATISLAR = new HashSet<TBLSATISLAR>();
        }
    
        public int MUSTERIID { get; set; }
        [Required(ErrorMessage ="Bu alan bos birakilamaz...")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter i�erebilir...")]
        public string MUSTERIAD { get; set; }
        [Required(ErrorMessage = "Bu alan bos birakilamaz...")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter i�erebilir...")]
        public string MUSTERISOYAD { get; set; }
       
        public Nullable<bool> Durum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSATISLAR> TBLSATISLAR { get; set; }
    }
}