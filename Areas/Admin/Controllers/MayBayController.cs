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
    public class MayBayController : Controller
    {
        DatVeDBContent db = new DatVeDBContent();
        // GET: Admin/MayBay
        public ActionResult Index()
        {
            return View(db.tb_MayBay.ToList());
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_MayBay p = db.tb_MayBay.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: Admin/MayBay/Create    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMayBay,LoaiMayBay,SoHieu,SoGheHangNhat,SoGheHangThuongGia,SoGheHangPTDB,SoGheHangPT,HangSX,MoTa,NgaySuDung,NgayHetHan")] tb_MayBay a)
        {
            if (ModelState.IsValid)
            {
                db.tb_MayBay.Add(a);
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
            tb_MayBay a = db.tb_MayBay.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMayBay,LoaiMayBay,SoHieu,SoGheHangNhat,SoGheHangThuongGia,SoGheHangPTDB,SoGheHangPT,HangSX,MoTa,NgaySuDung,NgayHetHan")] tb_MayBay a)
        {

            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(a);
        }

        // GET: Admin/MayBay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_MayBay ac = db.tb_MayBay.Find(id);
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
            tb_MayBay ac = db.tb_MayBay.Find(id);
            db.tb_MayBay.Remove(ac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}