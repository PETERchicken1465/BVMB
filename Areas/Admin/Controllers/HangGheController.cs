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
    public class HangGheController : Controller
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();

        // GET: Admin/HangGhe
        public ActionResult Index()
        {
            return View(db.tb_HangGhe.ToList());
        }

        // GET: Admin/HangGhe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HangGhe tb_HangGhe = db.tb_HangGhe.Find(id);
            if (tb_HangGhe == null)
            {
                return HttpNotFound();
            }
            return View(tb_HangGhe);
        }

        // GET: Admin/HangGhe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HangGhe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHangGhe,TenHangGhe")] tb_HangGhe tb_HangGhe)
        {
            if (ModelState.IsValid)
            {
                db.tb_HangGhe.Add(tb_HangGhe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_HangGhe);
        }

        // GET: Admin/HangGhe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HangGhe tb_HangGhe = db.tb_HangGhe.Find(id);
            if (tb_HangGhe == null)
            {
                return HttpNotFound();
            }
            return View(tb_HangGhe);
        }

        // POST: Admin/HangGhe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHangGhe,TenHangGhe")] tb_HangGhe tb_HangGhe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_HangGhe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_HangGhe);
        }

        // GET: Admin/HangGhe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_HangGhe tb_HangGhe = db.tb_HangGhe.Find(id);
            if (tb_HangGhe == null)
            {
                return HttpNotFound();
            }
            return View(tb_HangGhe);
        }

        // POST: Admin/HangGhe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_HangGhe tb_HangGhe = db.tb_HangGhe.Find(id);
            db.tb_HangGhe.Remove(tb_HangGhe);
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
