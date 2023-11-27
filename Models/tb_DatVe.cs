namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_DatVe
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDatVe { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime NgayDat { get; set; }

        public int? SoGhe { get; set; }

        public int MaGhe { get; set; }

        public int MaKH { get; set; }

        public int? MaNĐD { get; set; }

        public virtual tb_Ghe tb_Ghe { get; set; }

        public virtual tb_KhachHang tb_KhachHang { get; set; }

        public virtual tb_NguoiDaiDien tb_NguoiDaiDien { get; set; }
    }
}
