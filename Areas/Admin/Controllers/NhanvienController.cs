using DatVe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DatVe.Areas.Admin.Controllers
{
    public class NhanvienController : Controller
    {
        BanVeMayBayEntities db = new BanVeMayBayEntities();
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            return View(db.tb_NhanVien.ToList());
        }
        public ActionResult Create()
        {
           
            ViewBag.MaNghiepVu = new SelectList(db.tb_Nghiepvu, "MaNghiepVu", "Ten nghiep vu");
            ViewBag.MaDoiBay = new SelectList(db.tb_DoiBay, "MaDoiBay","CoTruong");
             return View();
        }
        // POST: Admin/KhachHang/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,TenNhanVien,Tuoi,GioiTinh,SDT,DiaChi,Matkhau,MaNghiepVu,MaDoiBay")] tb_NhanVien a)
        {
            if (ModelState.IsValid)
            {
                db.tb_NhanVien.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNghiepVu = new SelectList(db.tb_Nghiepvu, "MaNghiepVu", "Ten nghiep vu");
            ViewBag.MaDoiBay = new SelectList(db.tb_DoiBay, "MaDoiBay", "CoTruong");
            return View(a);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhanVien a = db.tb_NhanVien.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNghiepVu = new SelectList(db.tb_Nghiepvu, "MaNghiepVu", "Ten nghiep vu", a.MaNghiepVu);
            ViewBag.MaDoiBay = new SelectList(db.tb_DoiBay, "MaDoiBay", "CoTruong",a.MaDoiBay);
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,TenNhanVien,Tuoi,GioiTinh,SDT,DiaChi,Matkhau,MaNghiepVu,MaDoiBay")] tb_NhanVien a)
        {

            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNghiepVu = new SelectList(db.tb_Nghiepvu, "MaNghiepVu", "Ten nghiep vu", a.MaNghiepVu);
            ViewBag.MaDoiBay = new SelectList(db.tb_DoiBay, "MaDoiBay", "CoTruong", a.MaDoiBay);

            return View(a);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NhanVien ac = db.tb_NhanVien.Find(id);
            if (ac == null)
            {
                return HttpNotFound();
            }
            return View(ac);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_NhanVien ac = db.tb_NhanVien.Find(id);
            db.tb_NhanVien.Remove(ac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}