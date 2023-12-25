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
    public class DatVeController : Controller
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();

        // GET: Admin/DatVe
        public ActionResult Index()
        {
            var tb_DatVe = db.tb_DatVe.Include(t => t.tb_Ghe).Include(t => t.tb_KhachHang).Include(t => t.tb_NguoiDaiDien);
            return View(tb_DatVe.ToList());
        }

        // GET: Admin/DatVe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DatVe tb_DatVe = db.tb_DatVe.Find(id);
            if (tb_DatVe == null)
            {
                return HttpNotFound();
            }
            return View(tb_DatVe);
        }

        // GET: Admin/DatVe/Create
        public ActionResult Create()
        {
            ViewBag.MaGhe = new SelectList(db.tb_Ghe, "MaGhe", "DayGhe","SoGhe");
            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen");
            ViewBag.MaNĐD = new SelectList(db.tb_NguoiDaiDien, "MaNguoiDaiDien", "TenNguoiDaiDien");
            return View();
        }

        // POST: Admin/DatVe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDatVe,NgayDat,SoGhe,MaGhe,MaKH,MaNĐD")] tb_DatVe tb_DatVe)
        {
            if (ModelState.IsValid)
            {
                db.tb_DatVe.Add(tb_DatVe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGhe = new SelectList(db.tb_Ghe, "MaGhe", "DayGhe", "SoGhe", tb_DatVe.MaGhe);
            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen", tb_DatVe.MaKH);
            ViewBag.MaNĐD = new SelectList(db.tb_NguoiDaiDien, "MaNguoiDaiDien", "TenNguoiDaiDien", tb_DatVe.MaNĐD);
            return View(tb_DatVe);
        }

        // GET: Admin/DatVe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DatVe tb_DatVe = db.tb_DatVe.Find(id);
            if (tb_DatVe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGhe = new SelectList(db.tb_Ghe, "MaGhe", "DayGhe", tb_DatVe.MaGhe);
            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen", tb_DatVe.MaKH);
            ViewBag.MaNĐD = new SelectList(db.tb_NguoiDaiDien, "MaNguoiDaiDien", "TenNguoiDaiDien", tb_DatVe.MaNĐD);
            return View(tb_DatVe);
        }

        // POST: Admin/DatVe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDatVe,NgayDat,SoGhe,MaGhe,MaKH,MaNĐD")] tb_DatVe tb_DatVe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_DatVe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGhe = new SelectList(db.tb_Ghe, "MaGhe", "DayGhe", tb_DatVe.MaGhe);
            ViewBag.MaKH = new SelectList(db.tb_KhachHang, "MaKhachHang", "HovaTen", tb_DatVe.MaKH);
            ViewBag.MaNĐD = new SelectList(db.tb_NguoiDaiDien, "MaNguoiDaiDien", "TenNguoiDaiDien", tb_DatVe.MaNĐD);
            return View(tb_DatVe);
        }

        // GET: Admin/DatVe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DatVe tb_DatVe = db.tb_DatVe.Find(id);
            if (tb_DatVe == null)
            {
                return HttpNotFound();
            }
            return View(tb_DatVe);
        }

        // POST: Admin/DatVe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_DatVe tb_DatVe = db.tb_DatVe.Find(id);
            db.tb_DatVe.Remove(tb_DatVe);
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
