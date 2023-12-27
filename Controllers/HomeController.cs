using DatVe.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult DSChoNgoi(int id)
        {
            return View(db.tb_Ghe.Where(n => n.MaMayBay == id).ToList());
        }
        [HttpPost]
        public ActionResult ChonChoNgoi(int id)
        {

            return View(); 
        }
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

        public int TongSoLuong()     {          
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

    }
}