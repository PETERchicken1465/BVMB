using DatVe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace DatVe.Controllers
{
    public class HomeController : Controller
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();
        public ActionResult Index()
        {
            List<tb_SanBay> sanBayList = GetSanBayList();
            ViewBag.dssanbay = new SelectList(sanBayList, "MaSanBay", "ThanhPho");
            return View();
        }

        private List<tb_SanBay> GetSanBayList()
        {
            return db.tb_SanBay.ToList();

        }
        public ActionResult TimChuyenBay()
        { return View(); }
        [HttpPost]
        public ActionResult TimChuyenBay(FormCollection f)
        {
            var typeR = f["typeR"];
            var typeO = f["typeO"];
            int dssanbayFrom = int.Parse(f["dssanbayFrom"]);
            int dssanbayTo = int.Parse(f["dssanbayTo"]);
            DateTime departureDate = DateTime.Parse(f["ngaydi"]);
            int adults = int.Parse(f["nguoilon"]);
            int children = int.Parse(f["treem"]);
            if (typeR == "on")
            {
                DateTime returnDate = DateTime.Parse(f["ngayve"]);
                if (!int.TryParse(f["dssanbayFrom"], out dssanbayFrom) ||
                                 !int.TryParse(f["dssanbayTo"], out dssanbayTo) ||
                                 !DateTime.TryParse(f["ngaydi"], out departureDate) ||
                                 !DateTime.TryParse(f["ngayve"], out returnDate) ||
                                 !int.TryParse(f["nguoilon"], out adults) ||
                                 !int.TryParse(f["treem"], out children))
                {
                    ViewBag.ErrorMessage = "Vui lòng nhập đầy đủ thông tin";
                    return View("Error");
                }

                int sluong = adults + children;
                var tb = db.tb_TuyenBay.SingleOrDefault(n => n.MaSanBayDi == dssanbayFrom && n.MaSanBayDen == dssanbayTo);
                var cb = db.tb_ChuyenBay.Where(n => n.MaTuyenBay == tb.MaTuyenBay && n.NgayCatCanh == departureDate);
                ViewBag.ChuyenBayData = cb;
                ViewBag.sl = sluong;
                return View();
            }
            else if (typeO == "on")
            {
                if (!int.TryParse(f["dssanbayFrom"], out dssanbayFrom) ||
                            !int.TryParse(f["dssanbayTo"], out dssanbayTo) ||
                            !DateTime.TryParse(f["ngaydi"], out departureDate) ||
                                            !int.TryParse(f["nguoilon"], out adults) ||
                                                     !int.TryParse(f["treem"], out children))
                {
                    ViewBag.ErrorMessage = "Vui lòng nhập đầy đủ thông tin";
                    return View("Error");
                }

                int sluong = children + adults;
                var tb = db.tb_TuyenBay.SingleOrDefault(n => n.MaSanBayDi == dssanbayFrom && n.MaSanBayDen == dssanbayTo);
                var cb = db.tb_ChuyenBay.Where(n => n.MaTuyenBay == tb.MaTuyenBay && n.NgayCatCanh == departureDate);
                ViewBag.ChuyenBayData = cb.ToList();
                Session["sl"] = sluong;
                return View();
            }
            return View();
        }
        #region ChoNgoi
        public ActionResult DSChoNgoi(int id)
        {
            return View(db.tb_Ghe.Where(n => n.MaMayBay == id).ToList());
        }
        [HttpPost]
        public JsonResult ChonChoNgoi(int id, int ghe, string DG, int SG)
        {
            List<Giohang> lstGioHang = LayGioHang();
            Giohang sp = lstGioHang.SingleOrDefault(n => n.MaMayBay == id);
            if (sp != null)
            {
                sp.MaGhe = ghe;
                string ngoi = string.Concat(DG.Trim(), SG);
                sp.ChoNgoi = ngoi;
            }
            var result = new
            {
                Success = true,
                Message = "Lưu chỗ thành công"
            };
            return Json(result);
        }
        #endregion
        #region DangKy
        public ActionResult DangKy()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection f, tb_KhachHang kh)
        {
            var HoTen = f["HoTen"];
            var GT = f["GioiTinh"];
            var tuoi = f["Tuoi"];
            var sEmail = f["Email"];
            var sDienThoai = f["SoDienThoai"];

            if (string.IsNullOrEmpty(HoTen))
            {
                ViewData["err1"] = "Họ tên không được để trống";
            }
            else if (string.IsNullOrEmpty(sEmail))
            {
                ViewData["err2"] = "Email không được để trống";
            }
            else if (string.IsNullOrEmpty(sDienThoai))
            {
                ViewData["err3"] = "Số điện thoại không được để trống";
            }
            else if (sDienThoai.Length < 10 || sDienThoai.Length > 10)
            {
                ViewData["err4"] = "Vui lòng nhập số điện thoại ";
            }
            else
            {

                kh.HovaTen = HoTen;
                Session["TaiKhoan"] = HoTen;
                kh.GioiTinh = GT;
                kh.Tuoi = int.Parse(tuoi);
                kh.Email = sEmail;
                kh.SDT = sDienThoai;
                kh.QuocTich = "VietNam";
                kh.Passport_number = "0123456789963";
                db.tb_KhachHang.Add(kh);
                db.SaveChanges();
                return Redirect("/Home/DatHang");

            }
            return this.DangKy();
        }
        #endregion
        #region GioHang
        public List<Giohang> LayGioHang()
        {
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<Giohang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public JsonResult ThemGioHang(int ms)
        {
            List<Giohang> gioHang = LayGioHang();
            Giohang sp = gioHang.Find(n => n.MaChuyenBay == ms);

            if (sp == null)
            {
                sp = new Giohang(ms);
                sp.Soluong = (int)Session["sl"];
                gioHang.Add(sp);
            }
            else
            {
                sp.Soluong++;
            }

            var result = new
            {
                Success = true,
                Message = "Mua vé thành công ",
                TotalItems = gioHang.Count
            };

            return Json(result);
        }

        public int TongSoLuong() {
            int dTongsl = 0;
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            {
                if (lstGioHang != null)
                    dTongsl = lstGioHang.Sum(n => n.Soluong);

            }
            return dTongsl;
        }

        public double TongTien()
        {
            double dTongTien = 0;
            List<Giohang> lstGioHang = Session["GioHang"] as List<Giohang>;
            {
                if (lstGioHang != null)
                    dTongTien = lstGioHang.Sum(n => n.Thanhtien);

            }
            return dTongTien;
        }

        public ActionResult GioHangPartial()
        {
            List<Giohang> lstgiohang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView(lstgiohang);
        }
        #endregion
        public ActionResult DatHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();

            string x = Session["TaiKhoan"].ToString();
            var NDD = db.tb_KhachHang.FirstOrDefault(nv => nv.HovaTen == x);
            int CustomerID = NDD.MaKhachHang;
            // Create New Order
            tb_NguoiDaiDien ddh = new tb_NguoiDaiDien();
            ddh.MaKH = CustomerID;
            ddh.TenNguoiDaiDien = Session["TaiKhoan"].ToString();
            ddh.TongTien = (int)TongTien();
            ddh.SoLuong = (int)TongSoLuong();
            db.tb_NguoiDaiDien.Add(ddh);
            db.SaveChanges();
            System.Diagnostics.Debug.WriteLine($"ddh.MaNguoiDaiDien after reload: {ddh.MaNguoiDaiDien}");
            db.Entry(ddh).Reload();
            //string newndd = db.tb_NguoiDaiDien.OrderByDescending(n => n.MaNguoiDaiDien).FirstOrDefault().MaNguoiDaiDien.ToString();              
            //List<Giohang> lstCart = LayGioHang();
            //foreach (var item in lstCart)
            //{
            //    tb_DatVe order = new tb_DatVe();
            //    order.MaGhe = item.MaGhe;
            //    order.MaKH = Convert.ToInt32(CustomerID);
            //    order.NgayDat = DateTime.Now;                 
            //    order.MaNĐD = Convert.ToInt32(newndd);
            //    order.SoGhe = 0;

            //    db.tb_DatVe.Add(order);
            //}
            //db.SaveChanges();

            return RedirectToAction("XacNhanDonHang", "Home");        
    } 




        public ActionResult XacNhanDonHang()
        {
          
            return View();
        }
    }
}