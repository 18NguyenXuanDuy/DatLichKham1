using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatLichKham.Models;

namespace DatLichKham.Controllers
{
    public class PhongKhamsController : Controller
    {
        private DLKB db = new DLKB();

        // GET: PhongKhams
        public ActionResult Index()
        {
            return View(db.PhongKham.ToList());
        }

        // GET: PhongKhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongKham phongKham = db.PhongKham.Find(id);
            if (phongKham == null)
            {
                return HttpNotFound();
            }
            return View(phongKham);
        }

        // GET: PhongKhams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhongKhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhongKham_ID,PhongKham_Name,SoLuongToiDa,SoLuongHienTai")] PhongKham phongKham)
        {
            if (ModelState.IsValid)
            {
                db.PhongKham.Add(phongKham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongKham);
        }

        // GET: PhongKhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongKham phongKham = db.PhongKham.Find(id);
            if (phongKham == null)
            {
                return HttpNotFound();
            }
            return View(phongKham);
        }

        // POST: PhongKhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhongKham_ID,PhongKham_Name,SoLuongToiDa,SoLuongHienTai")] PhongKham phongKham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongKham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongKham);
        }

        // GET: PhongKhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongKham phongKham = db.PhongKham.Find(id);
            if (phongKham == null)
            {
                return HttpNotFound();
            }
            return View(phongKham);
        }

        // POST: PhongKhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongKham phongKham = db.PhongKham.Find(id);
            db.PhongKham.Remove(phongKham);
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
