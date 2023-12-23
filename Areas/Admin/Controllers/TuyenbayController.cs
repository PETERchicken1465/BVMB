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
    public class TuyenbayController : Controller
    {
        DatVeDBContent db = new DatVeDBContent();
        // GET: Admin/Tuyenbay
        public ActionResult Index()
        {
            return View(db.tb_TuyenBay.ToList());
        }
        // GET: Admin/SanBay
        public ActionResult Create()
        {
            ViewBag.MaSanBayDi = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay");
            ViewBag.MaSanBayDen = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay");
            return View();
        }
        // POST: Admin/SanBay/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuyenBay,MaSanBayDi,MaSanBayDen")] tb_TuyenBay a)
        {
            if (ModelState.IsValid)
            {
                db.tb_TuyenBay.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanBayDi = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay",a.MaSanBayDi);
            ViewBag.MaSanBayDen = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay",a.MaSanBayDen);
            return View(a);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TuyenBay a = db.tb_TuyenBay.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanBayDi = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay", a.MaSanBayDi);
            ViewBag.MaSanBayDen = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay", a.MaSanBayDen);
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanBay,MaSanBayDi,MaSanBayDen")] tb_TuyenBay a)
        {

            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanBayDi = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay", a.MaSanBayDi);
            ViewBag.MaSanBayDen = new SelectList(db.tb_SanBay, "MaSanBay", "TenSanBay", a.MaSanBayDen);
            return View(a);
        }

        // GET: Admin/SanBay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TuyenBay ac = db.tb_TuyenBay.Find(id);
            if (ac == null)
            {
                return HttpNotFound();
            }
            return View(ac);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_TuyenBay ac = db.tb_TuyenBay.Find(id);
            db.tb_TuyenBay.Remove(ac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}