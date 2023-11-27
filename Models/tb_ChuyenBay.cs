namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_ChuyenBay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChuyenBay { get; set; }

        public DateTime? NgayCatCanh { get; set; }

        [StringLength(255)]
        public string DiaDiemDi { get; set; }

        [StringLength(255)]
        public string DiaDiemDen { get; set; }

        public DateTime? ThoiGianBay { get; set; }

        public DateTime? ThoiGianHaCanh { get; set; }

        public int? SoGheHangNhat { get; set; }

        public int? SoGheHangThuongGia { get; set; }

        public int? SoGheHangPhoThongDB { get; set; }

        public int? SoGheHangPhoThong { get; set; }

        public bool? TrangThai { get; set; }

        public decimal? GiaVePhoThong { get; set; }

        public int? MaMayBay { get; set; }

        public int? MaTuyenBay { get; set; }

        public virtual tb_MayBay tb_MayBay { get; set; }

        public virtual tb_TuyenBay tb_TuyenBay { get; set; }

        public virtual tb_DoiBay tb_DoiBay { get; set; }
    }
}
