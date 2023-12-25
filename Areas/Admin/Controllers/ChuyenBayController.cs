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
    public class ChuyenBayController : Controller
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();

        // GET: Admin/ChuyenBay
        public ActionResult Index()
        {
            var tb_ChuyenBay = db.tb_ChuyenBay.Include(t => t.tb_MayBay).Include(t => t.tb_TuyenBay).Include(t => t.tb_DoiBay);
            return View(tb_ChuyenBay.ToList());
        }

        // GET: Admin/ChuyenBay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChuyenBay tb_ChuyenBay = db.tb_ChuyenBay.Find(id);
            if (tb_ChuyenBay == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChuyenBay);
        }

        // GET: Admin/ChuyenBay/Create
        public ActionResult Create()
        {
            ViewBag.MaMayBay = new SelectList(db.tb_MayBay, "MaMayBay", "LoaiMayBay");
            ViewBag.MaTuyenBay = new SelectList(db.tb_TuyenBay, "MaTuyenBay", "MaTuyenBay");
            ViewBag.MaChuyenBay = new SelectList(db.tb_DoiBay, "MaDoiBay", "CoTruong");
            return View();
        }

        // POST: Admin/ChuyenBay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuyenBay,NgayCatCanh,DiaDiemDi,DiaDiemDen,ThoiGianBay,ThoiGianHaCanh,SoGheHangNhat,SoGheHangThuongGia,SoGheHangPhoThongDB,SoGheHangPhoThong,TrangThai,GiaVePhoThong,MaMayBay,MaTuyenBay")] tb_ChuyenBay tb_ChuyenBay)
        {
            if (ModelState.IsValid)
            {
                db.tb_ChuyenBay.Add(tb_ChuyenBay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMayBay = new SelectList(db.tb_MayBay, "MaMayBay", "LoaiMayBay", tb_ChuyenBay.MaMayBay);
            ViewBag.MaTuyenBay = new SelectList(db.tb_TuyenBay, "MaTuyenBay", "MaTuyenBay", tb_ChuyenBay.MaTuyenBay);
            ViewBag.MaChuyenBay = new SelectList(db.tb_DoiBay, "MaDoiBay", "CoTruong", tb_ChuyenBay.MaChuyenBay);
            return View(tb_ChuyenBay);
        }

        // GET: Admin/ChuyenBay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChuyenBay tb_ChuyenBay = db.tb_ChuyenBay.Find(id);
            if (tb_ChuyenBay == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMayBay = new SelectList(db.tb_MayBay, "MaMayBay", "LoaiMayBay", tb_ChuyenBay.MaMayBay);
            ViewBag.MaTuyenBay = new SelectList(db.tb_TuyenBay, "MaTuyenBay", "MaTuyenBay", tb_ChuyenBay.MaTuyenBay);
           // ViewBag.MaChuyenBay = new SelectList(db.tb_DoiBay, "MaDoiBay", "CoTruong", tb_ChuyenBay.MaChuyenBay);
            return View(tb_ChuyenBay);
        }

        // POST: Admin/ChuyenBay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuyenBay,NgayCatCanh,DiaDiemDi,DiaDiemDen,ThoiGianBay,ThoiGianHaCanh,SoGheHangNhat,SoGheHangThuongGia,SoGheHangPhoThongDB,SoGheHangPhoThong,TrangThai,GiaVePhoThong,MaMayBay,MaTuyenBay")] tb_ChuyenBay tb_ChuyenBay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ChuyenBay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMayBay = new SelectList(db.tb_MayBay, "MaMayBay", "LoaiMayBay", tb_ChuyenBay.MaMayBay);
            ViewBag.MaTuyenBay = new SelectList(db.tb_TuyenBay, "MaTuyenBay", "MaTuyenBay", tb_ChuyenBay.MaTuyenBay);
           // ViewBag.MaChuyenBay = new SelectList(db.tb_DoiBay, "MaDoiBay", "CoTruong", tb_ChuyenBay.MaChuyenBay);
            return View(tb_ChuyenBay);
        }

        // GET: Admin/ChuyenBay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ChuyenBay tb_ChuyenBay = db.tb_ChuyenBay.Find(id);
            if (tb_ChuyenBay == null)
            {
                return HttpNotFound();
            }
            return View(tb_ChuyenBay);
        }

        // POST: Admin/ChuyenBay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ChuyenBay tb_ChuyenBay = db.tb_ChuyenBay.Find(id);
            db.tb_ChuyenBay.Remove(tb_ChuyenBay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult GetSanBayByTuyenBay(int maTuyenBay)
        {
            var sanBay = db.tb_TuyenBay
                            .Where(tb => tb.MaTuyenBay == maTuyenBay)
                            .Select(tb => new { tb.MaSanBayDi, tb.MaSanBayDen })
                            .FirstOrDefault();

            var sanBayDi = db.tb_SanBay.Find(sanBay.MaSanBayDi);
            var sanBayDen = db.tb_SanBay.Find(sanBay.MaSanBayDen);

            var result = new
            {
                DiaDiemDi = new { MaSanBay = sanBayDi.MaSanBay, TenSanBay = sanBayDi.ThanhPho },
                DiaDiemDen = new { MaSanBay = sanBayDen.MaSanBay, TenSanBay = sanBayDen.ThanhPho }
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGheByChuyenBay(int MaMayBay)
        {
            var ghe = db.tb_MayBay
                            .Where(mb => mb.MaMayBay == MaMayBay)
                            .Select(mb => new {
                                mb.SoGheHangNhat,
                                mb.SoGheHangThuongGia,
                                mb.SoGheHangPTDB,
                                mb.SoGheHangPT
                            })
                            .FirstOrDefault();
           

            return Json(ghe, JsonRequestBehavior.AllowGet);
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
