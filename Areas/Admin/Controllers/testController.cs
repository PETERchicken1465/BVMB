using DatVe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatVe.Areas.Admin.Controllers
{
    public class testController : Controller
    {
        BanVeMayBayEntities db = new BanVeMayBayEntities();
        // GET: Admin/test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSeats(int numberOfSeats)
        {
            int numberOfRows = numberOfSeats / 10;
            if (numberOfSeats % 10 != 0)
            {
                numberOfRows++;
            }

            List<List<string>> seatRows = new List<List<string>>();
            for (int i = 0; i < numberOfRows; i++)
            {
                List<string> seatsInRow = Enumerable.Range(1, 10)
                                                    .Select(seatNumber => $"Row {i + 1}, Seat {seatNumber}")
                                                    .Take(numberOfSeats - i * 10)
                                                    .ToList();

                seatRows.Add(seatsInRow);
            }

            ViewBag.SeatRows = seatRows;

            return View("SeatLayout");
        }

    }
}