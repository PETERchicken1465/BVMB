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
    public class KhachhangController : Controller
    {
        // GET: Admin/Khachhang
        BanVeMayBayEntities db = new BanVeMayBayEntities();
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            return View(db.tb_KhachHang.ToList());
        }      
        public ActionResult Create()
        {
            return View();
        }
        // POST: Admin/KhachHang/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachHang,HovaTen,Tuoi,GioiTinh,SDT,Email,Passport_number,QuocTich")] tb_KhachHang a)
        {
            if (ModelState.IsValid)
            {
                db.tb_KhachHang.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(a);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_KhachHang a = db.tb_KhachHang.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachHang,HovaTen,Tuoi,GioiTinh,SDT,Email,Passport_number,QuocTich")] tb_KhachHang a)
        {

            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(a);
        }

        // GET: Admin/KhachHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_KhachHang ac = db.tb_KhachHang.Find(id);
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
            tb_KhachHang ac = db.tb_KhachHang.Find(id);
            db.tb_KhachHang.Remove(ac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}