namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_MayBay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MayBay()
        {
            tb_ChuyenBay = new HashSet<tb_ChuyenBay>();
            tb_Ghe = new HashSet<tb_Ghe>();
        }

        [Key]
        public int MaMayBay { get; set; }

        [StringLength(255)]
        public string LoaiMayBay { get; set; }

        [StringLength(255)]
        public string SoHieu { get; set; }

        public int? SoGheHangNhat { get; set; }

        public int? SoGheHangThuongGia { get; set; }

        public int? SoGheHangPTDB { get; set; }

        public int? SoGheHangPT { get; set; }

        [StringLength(255)]
        public string HangSX { get; set; }

        public string MoTa { get; set; }

        public DateTime? NgaySuDung { get; set; }

        public DateTime? NgayHetHan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ChuyenBay> tb_ChuyenBay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Ghe> tb_Ghe { get; set; }
    }
}
