namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_NhanVien()
        {
            tb_HoaDon = new HashSet<tb_HoaDon>();
        }

        [Key]
        public int MaNhanVien { get; set; }

        [StringLength(255)]
        public string TenNhanVien { get; set; }

        public int? Tuoi { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(255)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Matkhau { get; set; }

        public int? MaNghiepVu { get; set; }

        public int? MaDoiBay { get; set; }

        public virtual tb_DoiBay tb_DoiBay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_HoaDon> tb_HoaDon { get; set; }

        public virtual tb_Nghiepvu tb_Nghiepvu { get; set; }
    }
}
