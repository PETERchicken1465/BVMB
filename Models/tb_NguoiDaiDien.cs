namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_NguoiDaiDien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_NguoiDaiDien()
        {
            tb_DatVe = new HashSet<tb_DatVe>();
        }

        [Key]
        public int MaNguoiDaiDien { get; set; }

        [Required]
        [StringLength(255)]
        public string TenNguoiDaiDien { get; set; }

        public int MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_DatVe> tb_DatVe { get; set; }

        public virtual tb_KhachHang tb_KhachHang { get; set; }
    }
}
