//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_SanBay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_SanBay()
        {
            this.tb_TuyenBay = new HashSet<tb_TuyenBay>();
            this.tb_TuyenBay1 = new HashSet<tb_TuyenBay>();
        }
    
        public int MaSanBay { get; set; }
        public string TenSanBay { get; set; }
        public string ThanhPho { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_TuyenBay> tb_TuyenBay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_TuyenBay> tb_TuyenBay1 { get; set; }
    }
}
