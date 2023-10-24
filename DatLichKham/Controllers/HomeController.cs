using DatLichKham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLichKham.Controllers
{
    public class HomeController : Controller
    {
        private DLKB db = new DLKB();
        public ActionResult Index()
        {
            ViewBag.BacSi_ID = new SelectList(db.BacSi, "BacSi_ID", "BacSi_Name");
            ViewBag.PhongKham_ID = new SelectList(db.PhongKham, "PhongKham_ID", "PhongKham_Name");

          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected void SetAlert(string message, int type)
        {
            TempData["AlertMessage"] = message;
            if (type == 1)
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == 2)
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == 3)
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-info";
            }
        }
    }
}