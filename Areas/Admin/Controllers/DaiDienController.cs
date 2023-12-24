using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatVe.Models;

namespace DatVe.Areas.Admin.Controllers
{
    public class DaiDienController : Controller
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();

        // GET: Admin/DaiDien
        public ActionResult Index()
        {
            var tb_NguoiDaiDien = db.tb_NguoiDaiDien.Include(t => t.tb_KhachHang);
            return View(tb_NguoiDaiDien.ToList());
        }

    
       

        // GET: Admin/DaiDien/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen");
            return View();
        }

        // POST: Admin/DaiDien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiDaiDien,TenNguoiDaiDien,MaKH")] tb_NguoiDaiDien tb_NguoiDaiDien)
        {
            if (ModelState.IsValid)
            {
                db.tb_NguoiDaiDien.Add(tb_NguoiDaiDien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen", tb_NguoiDaiDien.MaKH);
            return View(tb_NguoiDaiDien);
        }

        // GET: Admin/DaiDien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDaiDien tb_NguoiDaiDien = db.tb_NguoiDaiDien.Find(id);
            if (tb_NguoiDaiDien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen", tb_NguoiDaiDien.MaKH);
            return View(tb_NguoiDaiDien);
        }

        // POST: Admin/DaiDien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNguoiDaiDien,TenNguoiDaiDien,MaKH")] tb_NguoiDaiDien tb_NguoiDaiDien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_NguoiDaiDien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen", tb_NguoiDaiDien.MaKH);
            return View(tb_NguoiDaiDien);
        }

        // GET: Admin/DaiDien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_NguoiDaiDien tb_NguoiDaiDien = db.tb_NguoiDaiDien.Find(id);
            if (tb_NguoiDaiDien == null)
            {
                return HttpNotFound();
            }
            return View(tb_NguoiDaiDien);
        }

        // POST: Admin/DaiDien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_NguoiDaiDien tb_NguoiDaiDien = db.tb_NguoiDaiDien.Find(id);
            db.tb_NguoiDaiDien.Remove(tb_NguoiDaiDien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
