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
    public class SanBayController : Controller
    {
        DatVeDBContent db = new DatVeDBContent();
        // GET: Admin/SanBay
        public ActionResult Index()
        {
            return View(db.tb_SanBay.ToList());
        }
        // GET: Admin/SanBay
        public ActionResult Create()
        {
            return View();
        }
        // POST: Admin/SanBay/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanBay,TenSanBay,ThanhPho")] tb_SanBay a)
        {
            if (ModelState.IsValid)
            {
                db.tb_SanBay.Add(a);
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
            tb_SanBay a = db.tb_SanBay.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanBay,TenSanBay,ThanhPho")] tb_SanBay a)
        {

            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(a);
        }

        // GET: Admin/SanBay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_SanBay ac = db.tb_SanBay.Find(id);
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
            tb_SanBay ac = db.tb_SanBay.Find(id);
            db.tb_SanBay.Remove(ac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}