using DatVe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            //var flight-type = f["UserName"]
            //var dssanbayFrom = f["UserName"];
            //var dssanbayTo = f["UserName"];
            //var departureDate = f["UserName"];
            //var returnDate = f["UserName"];
            //var adults = f["UserName"];
            //var children = f["UserName"];

            //if (string.IsNullOrEmpty(dssanbayFrom) || string.IsNullOrEmpty(dssanbayTo) || string.IsNullOrEmpty(departureDate) || adults <= 0 || children < 0 || string.IsNullOrEmpty(travelClass))
            //{               
            //    ViewBag.ErrorMessage = "Vui lòng nhập đầy đủ thông tin và đúng định dạng.";
            //    return View("Error");
            //}        



            //if (String.IsNullOrEmpty(sTenDN))
            //{

            //    ViewData["loli1"] = "Phải nhập địa chỉ email";
            //}
            //else if (String.IsNullOrEmpty(sMatKhau))
            //{

            //    ViewData["loli2"] = "Phải nhập mật khẩu";
            //}
            //else
            //{
            //    var ad = db.Customers.SingleOrDefault(n => n.Email == sTenDN && n.Password == sMatKhau);

            //    if (ad != null)
            //    {
            //        Session["TenDN"] = ad;
            //        Session["ten"] = ad.Name;
            //        Session["ID"] = ad.ID;
            //        string preURL = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            //        if (!string.IsNullOrEmpty(preURL) && Url.IsLocalUrl(preURL))
            //        {
            //            return Redirect(preURL);
            //        }
            //        return RedirectToAction("Index", "Home");

            //    }

            //    else
            //    {
            //        ViewBag.ThongBao = "Email hoặc Mật Khẩu không đúng";
            //        return View("Login");
            //    }
            //}
            //return View();
            return View();
        }


    }
}