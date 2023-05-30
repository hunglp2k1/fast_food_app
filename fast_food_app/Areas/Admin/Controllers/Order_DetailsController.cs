using System;
using System.Collections;
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
    public class Order_DetailsController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Order_Details
        public ActionResult Index(int? id)
        {
            ViewBag.HoaDonId = id;
            var cHITIET_HOADON = db.CHITIET_HOADON.Include(c => c.HOADON).Include(c => c.MONAN).Where(m => m.MaHD == id).ToList();               
            return View(cHITIET_HOADON);
        }

        // GET: Admin/Order_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_HOADON cHITIET_HOADON = db.CHITIET_HOADON.Find(id);
            if (cHITIET_HOADON == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_HOADON);
        }

        // GET: Admin/Order_Details/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaHD");
            ViewBag.MaMonAn = new SelectList(db.MONANs, "MaMonAn", "TenMonAn");
            return View();
        }

        // POST: Admin/Order_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTHD,MaHD,SoLuong,MaMonAn")] CHITIET_HOADON cHITIET_HOADON)
        {
            if (ModelState.IsValid)
            {
                db.CHITIET_HOADON.Add(cHITIET_HOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaHD", cHITIET_HOADON.MaHD);
            ViewBag.MaMonAn = new SelectList(db.MONANs, "MaMonAn", "TenMonAn", cHITIET_HOADON.MaMonAn);
            return View(cHITIET_HOADON);
        }

        // GET: Admin/Order_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_HOADON cHITIET_HOADON = db.CHITIET_HOADON.Find(id);
            if (cHITIET_HOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaHD", cHITIET_HOADON.MaHD);
            ViewBag.MaMonAn = new SelectList(db.MONANs, "MaMonAn", "TenMonAn", cHITIET_HOADON.MaMonAn);
            return View(cHITIET_HOADON);
        }

        // POST: Admin/Order_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTHD,MaHD,SoLuong,MaMonAn")] CHITIET_HOADON cHITIET_HOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIET_HOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HOADONs, "MaHD", "MaHD", cHITIET_HOADON.MaHD);
            ViewBag.MaMonAn = new SelectList(db.MONANs, "MaMonAn", "TenMonAn", cHITIET_HOADON.MaMonAn);
            return View(cHITIET_HOADON);
        }

        // GET: Admin/Order_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_HOADON cHITIET_HOADON = db.CHITIET_HOADON.Find(id);
            if (cHITIET_HOADON == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_HOADON);
        }

        // POST: Admin/Order_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIET_HOADON cHITIET_HOADON = db.CHITIET_HOADON.Find(id);
            db.CHITIET_HOADON.Remove(cHITIET_HOADON);
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
