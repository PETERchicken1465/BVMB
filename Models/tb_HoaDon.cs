namespace DatVe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoaDon { get; set; }

        public int? ThanhTien { get; set; }

        public DateTime? NgayLap { get; set; }

        public int? MaKhachHang { get; set; }

        public int? MaNhanVien { get; set; }

        public virtual tb_KhachHang tb_KhachHang { get; set; }

        public virtual tb_NhanVien tb_NhanVien { get; set; }
    }
}
