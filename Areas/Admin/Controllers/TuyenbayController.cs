using DatVe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }
    }
}