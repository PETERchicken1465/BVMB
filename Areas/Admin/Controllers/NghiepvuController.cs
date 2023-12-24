using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatVe.Models;

namespace DatVe.Areas.Admin.Controllers
{
    public class NghiepvuController : Controller
    {
        private BanVeMayBayEntities db = new BanVeMayBayEntities();

        // GET: Admin/Nghiepvu
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_Nghiepvu.ToListAsync());
        }

        // GET: Admin/Nghiepvu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Nghiepvu tb_Nghiepvu = await db.tb_Nghiepvu.FindAsync(id);
            if (tb_Nghiepvu == null)
            {
                return HttpNotFound();
            }
            return View(tb_Nghiepvu);
        }

        // GET: Admin/Nghiepvu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nghiepvu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaNghiepvu,Ten_nghiep_vu")] tb_Nghiepvu tb_Nghiepvu)
        {
            if (ModelState.IsValid)
            {
                db.tb_Nghiepvu.Add(tb_Nghiepvu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_Nghiepvu);
        }

        // GET: Admin/Nghiepvu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Nghiepvu tb_Nghiepvu = await db.tb_Nghiepvu.FindAsync(id);
            if (tb_Nghiepvu == null)
            {
                return HttpNotFound();
            }
            return View(tb_Nghiepvu);
        }

        // POST: Admin/Nghiepvu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaNghiepvu,Ten_nghiep_vu")] tb_Nghiepvu tb_Nghiepvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Nghiepvu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_Nghiepvu);
        }

        // GET: Admin/Nghiepvu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Nghiepvu tb_Nghiepvu = await db.tb_Nghiepvu.FindAsync(id);
            if (tb_Nghiepvu == null)
            {
                return HttpNotFound();
            }
            return View(tb_Nghiepvu);
        }

        // POST: Admin/Nghiepvu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_Nghiepvu tb_Nghiepvu = await db.tb_Nghiepvu.FindAsync(id);
            db.tb_Nghiepvu.Remove(tb_Nghiepvu);
            await db.SaveChangesAsync();
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
