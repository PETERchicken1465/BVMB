﻿using DatVe.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatVe.Areas.Admin.Controllers
{
    public class HomeADController : Controller
    {
        DatVeDBContent db = new DatVeDBContent();
        // GET: Admin/HomeAD
        public ActionResult Index()
        {
            if (Session["TenDNAdmin"] == null)
            { 
                return RedirectToAction("Login", "HomeAD");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)

        {
            var sSDT = f["SDT"];
            var sMatKhau = f["Password"];


            if (String.IsNullOrEmpty(sSDT) || sSDT.Length < 11)
            {

                ViewData["loli1"] = "Phải nhập SDT chính xác";
            }
            else if (String.IsNullOrEmpty(sMatKhau))
            {

                ViewData["loli2"] = "Phải nhập mật khẩu";
            }
            else
            {
                tb_NhanVien ad = db.tb_NhanVien.SingleOrDefault(n => n.SDT == sSDT && n.Matkhau == sMatKhau);

                if (ad != null)
                {
                    Session["TenDNAdmin"] = ad;

                    return RedirectToAction("Index", "HomeAD");
                }

                else
                {

                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return View();
        }

    }
}