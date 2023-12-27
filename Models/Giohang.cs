using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatVe.Models
{
    public class Giohang
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();
        public int MaChuyenBay { get; set; }
        public int MaMayBay { get; set; }
        public string LoaiMayBay { get; set; }
        public string SoHieu { get; set; }
        public string DiemDen { get; set; }
        public string DiemTu { get; set; }
        public DateTime ThoiGianHaCanh { get; set; }
        public DateTime ThoiGianBay { get; set; }
        public DateTime NgayCatCanh { get; set; }
        public DateTime NgayVe { get; set; }
        public string ChoNgoi { get; set; }
        public double Giave { get; set; }
        public int Soluong { get; set; }
        public double Thanhtien
        {
            get { return (Soluong * Giave) + 600000; }
        }

        public Giohang(int ms)
        {
            MaChuyenBay = ms;
            tb_ChuyenBay s = db.tb_ChuyenBay.Single(n => n.MaChuyenBay == MaChuyenBay);
            MaMayBay= (int)s.MaMayBay;
            LoaiMayBay = s.tb_MayBay.LoaiMayBay;
            SoHieu = s.tb_MayBay.SoHieu;
            ThoiGianHaCanh = DateTime.Parse(s.ThoiGianHaCanh.ToString());
            ThoiGianBay = DateTime.Parse(s.ThoiGianBay.ToString());
            NgayCatCanh = DateTime.Parse(s.NgayCatCanh.ToString());
            NgayVe = DateTime.Parse(s.NgayCatCanh.ToString());
            ChoNgoi = "";
            DiemTu = s.DiaDiemDi;
            DiemDen = s.DiaDiemDen;
            Giave = (double)s.GiaVePhoThong;
            Soluong = 1;

        }
    }
}