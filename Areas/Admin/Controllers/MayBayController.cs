using DatVe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}