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

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_MayBay ac = db.tb_MayBay.Find(id);
            db.tb_MayBay.Remove(ac);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        int NumberRows;
        int NumberSeats;
        [HttpPost]
        public JsonResult GetData(int parameterValue, int id)
        {
            try
            {
                if (parameterValue >= 250)
                {
                    NumberSeats = 9;
                }
                else
                {
                    NumberSeats = 6;
                }
                NumberRows = parameterValue / NumberSeats;

                // Tạo danh sách chỗ ngồi
                List<tb_Ghe> danhSachGhe = new List<tb_Ghe>();

                // Gán giá trị cho danh sách chỗ ngồi
                for (int r = 0; r < NumberRows; r++)
                {
                    for (int s = 0; s < NumberSeats; s++)
                    {
                        tb_Ghe ghe = new tb_Ghe
                        {
                            SoGhe = r * NumberSeats + s + 1,  // Số ghế tăng dần từ 1
                            TrangThai = false,
                            DayGhe = $"{(char)('A' + s)}",  // Tên của dãy ghế
                            MaHangGhe = 4, // Mã hàng ghế tăng dần từ 1
                            MaMayBay = id,
                        };
                        r++;
                        danhSachGhe.Add(ghe);
                    }
                }
                db.tb_Ghe.AddRange(danhSachGhe);
                db.SaveChanges();               
                return Json(new { success = true, message = "Xử lý thành công" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                return Json(new { success = false, message = "Xử lý không thành công", error = ex.Message });
            }
        }

    }
}