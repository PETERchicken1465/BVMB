using DatVe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatVe.Areas.Admin.Controllers
{
    public class ToBayController : Controller
    {
        BanVeMayBayEntities db = new BanVeMayBayEntities();
        // GET: Admin/ToBay
        public ActionResult Index()
        {
            return View();
        }
    }
}