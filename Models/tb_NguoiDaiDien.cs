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
    
    public partial class tb_NguoiDaiDien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_NguoiDaiDien()
        {
            this.tb_DatVe = new HashSet<tb_DatVe>();
        }
    
        public int MaNguoiDaiDien { get; set; }
        public string TenNguoiDaiDien { get; set; }
        public int MaKH { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<int> TongTien { get; set; }
    
        public virtual tb_KhachHang tb_KhachHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_DatVe> tb_DatVe { get; set; }
    }
}
