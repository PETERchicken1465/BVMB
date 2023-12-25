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
    public class DoiBayController : Controller
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();

        // GET: Admin/DoiBay
        public ActionResult Index()
        {
            var tb_DoiBay = db.tb_DoiBay.Include(t => t.tb_ChuyenBay);
            return View(tb_DoiBay.ToList());
        }

        // GET: Admin/DoiBay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiBay tb_DoiBay = db.tb_DoiBay.Find(id);
            if (tb_DoiBay == null)
            {
                return HttpNotFound();
            }
            return View(tb_DoiBay);
        }

        // GET: Admin/DoiBay/Create
        public ActionResult Create()
        {
            ViewBag.MaDoiBay = new SelectList(db.tb_ChuyenBay, "MaChuyenBay", "NgayCatCanh");
            return View();
        }

        // POST: Admin/DoiBay/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDoiBay,CoTruong,CoPho")] tb_DoiBay tb_DoiBay)
        {
            if (ModelState.IsValid)
            {
                db.tb_DoiBay.Add(tb_DoiBay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDoiBay = new SelectList(db.tb_ChuyenBay, "MaChuyenBay", "NgayCatCanh", tb_DoiBay.MaDoiBay);
            return View(tb_DoiBay);
        }

        // GET: Admin/DoiBay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiBay tb_DoiBay = db.tb_DoiBay.Find(id);
            if (tb_DoiBay == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDoiBay = new SelectList(db.tb_ChuyenBay, "MaChuyenBay", "NgayCatCanh", tb_DoiBay.MaDoiBay);
            return View(tb_DoiBay);
        }

        // POST: Admin/DoiBay/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDoiBay,CoTruong,CoPho")] tb_DoiBay tb_DoiBay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_DoiBay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDoiBay = new SelectList(db.tb_ChuyenBay, "MaChuyenBay", "NgayCatCanh", tb_DoiBay.MaDoiBay);
            return View(tb_DoiBay);
        }

        // GET: Admin/DoiBay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_DoiBay tb_DoiBay = db.tb_DoiBay.Find(id);
            if (tb_DoiBay == null)
            {
                return HttpNotFound();
            }
            return View(tb_DoiBay);
        }

        // POST: Admin/DoiBay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_DoiBay tb_DoiBay = db.tb_DoiBay.Find(id);
            db.tb_DoiBay.Remove(tb_DoiBay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }       
    }
}
