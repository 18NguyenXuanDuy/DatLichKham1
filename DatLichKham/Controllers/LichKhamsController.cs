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
    public class LichKhamsController : Controller
    {
        private DLKB db = new DLKB();

        // GET: LichKhams
        public ActionResult Index()
        {
            var lichKhams = db.LichKham.Include(l => l.BacSi).Include(l => l.PhongKham);
            var sla = db.LichKham.GroupBy(item => item.PhongKham_ID).Select(group => new
            {

                Count = group.Count()
            }); ;


            ViewBag.SLuong = sla;
            return View(lichKhams.ToList());
        }

        // GET: LichKhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichKham lichKham = db.LichKham.Find(id);
            if (lichKham == null)
            {
                return HttpNotFound();
            }
            return View(lichKham);
        }

        // GET: LichKhams/Create
        public ActionResult Create()
        {
            ViewBag.BacSi_ID = new SelectList(db.BacSi, "BacSi_ID", "BacSi_Name");
            ViewBag.PhongKham_ID = new SelectList(db.PhongKham, "PhongKham_ID", "PhongKham_Name");
            return View();
        }

        // POST: LichKhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BacSi_ID,BenhNhan_Name,BenhNhan_Email,PhongKham_ID")] LichKham lichKham)
        {
              int maxLichKhamId = db.LichKham.Max(lk => lk.LichKham_ID);
            int newLichKhamId;
            if (ModelState.IsValid)
            {
                // Truy vấn cơ sở dữ liệu để lấy giá trị LichKham_ID lớn nhất
                if (maxLichKhamId == null)
                {
                    newLichKhamId = 0;
                }
                else
                {
                    // Tăng giá trị lên một đơn vị
                    newLichKhamId = maxLichKhamId + 1;
                }
                string time = Request.Form["time"];
                string date = Request.Form["date"];
                lichKham.ThoiGianKham = time;
                lichKham.NgayKham = date;
                lichKham.LichKham_ID = newLichKhamId;
                lichKham.TrangThai = true;
                // Thêm bản ghi mới vào cơ sở dữ liệu

                db.LichKham.Add(lichKham);
                TempData["SuccessMessage"] = "Đặt lịch khám thành công";
                db.SaveChanges();

                PhongKham phongKham = db.PhongKham.Find(lichKham.PhongKham_ID);

                if (phongKham != null)
                {
                    int soNguoiHienTai = db.LichKham.Count(x => x.PhongKham_ID == phongKham.PhongKham_ID);
                    if (phongKham.SoLuongHienTai == null) { phongKham.SoLuongHienTai = 0; }
                    phongKham.SoLuongHienTai = soNguoiHienTai; // cập nhật lượng người
                    db.Entry(phongKham).State = EntityState.Modified; // Đặt trạng thái để cập nhật
                    db.SaveChanges(); // Lưu thay đổi trong phòng khám
                }
               
                return RedirectToAction("Index","Home");
            }

            ViewBag.BacSi_ID = new SelectList(db.BacSi, "BacSi_ID", "BacSi_Name", lichKham.BacSi_ID);
            ViewBag.PhongKham_ID = new SelectList(db.PhongKham, "PhongKham_ID", "PhongKham_Name", lichKham.PhongKham_ID);
            return View(lichKham);
        }

        // GET: LichKhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichKham lichKham = db.LichKham.Find(id);
            if (lichKham == null)
            {
                return HttpNotFound();
            }
            ViewBag.BacSi_ID = new SelectList(db.BacSi, "BacSi_ID", "BacSi_Name", lichKham.BacSi_ID);
            ViewBag.PhongKham_ID = new SelectList(db.PhongKham, "PhongKham_ID", "PhongKham_Name", lichKham.PhongKham_ID);
            return View(lichKham);
        }

        // POST: LichKhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LichKham_ID,BenhNhan_Name,BenhNhan_Email,BacSi_ID,PhongKham_ID,NgayKham,ThoiGianKham,TrangThai")] LichKham lichKham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichKham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BacSi_ID = new SelectList(db.BacSi, "BacSi_ID", "BacSi_Name", lichKham.BacSi_ID);
            ViewBag.PhongKham_ID = new SelectList(db.PhongKham, "PhongKham_ID", "PhongKham_Name", lichKham.PhongKham_ID);
            return View(lichKham);
        }

        // GET: LichKhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichKham lichKham = db.LichKham.Find(id);
            if (lichKham == null)
            {
                return HttpNotFound();
            }
            return View(lichKham);
        }

        // POST: LichKhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichKham lichKham = db.LichKham.Find(id);
            db.LichKham.Remove(lichKham);
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
