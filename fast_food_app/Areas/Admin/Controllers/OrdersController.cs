using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace fast_food_app.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Orders
        public ActionResult Index()
        {
            var hOADONs = db.HOADONs.Include(h => h.KHUYENMAI).Include(h => h.NHANVIEN);
            return View(hOADONs.ToList());
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: Admin/Orders/Create
        public ActionResult Create()
        {
            ViewBag.MaKM = new SelectList(db.KHUYENMAIs, "MaKM", "TenKM");
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaNV,ThoiGian,MaKM")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKM = new SelectList(db.KHUYENMAIs, "MaKM", "TenKM", hOADON.MaKM);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", hOADON.MaNV);
            return View(hOADON);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKM = new SelectList(db.KHUYENMAIs, "MaKM", "TenKM", hOADON.MaKM);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", hOADON.MaNV);
            return View(hOADON);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaNV,ThoiGian,MaKM")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKM = new SelectList(db.KHUYENMAIs, "MaKM", "TenKM", hOADON.MaKM);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", hOADON.MaNV);
            return View(hOADON);
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
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
