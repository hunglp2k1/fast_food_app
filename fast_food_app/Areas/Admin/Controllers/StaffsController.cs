using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace fast_food_app.Areas.Admin.Controllers
{
    public class StaffsController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Staffs
        public ActionResult Index(string staffName)
        {
            ViewBag.StaffName = staffName;
            Staffs_Dao staffs_Dao = new Staffs_Dao();
            var staffs = staffs_Dao.ComboList(staffName);          
            return View(staffs);
        }

        // GET: Admin/Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: Admin/Staffs/Create
        public ActionResult Create()
        {
            NHANVIEN nv = new NHANVIEN() { NgaySinh = DateTime.Now};
            ViewBag.MaCV = new SelectList(db.CHUCVUs, "MaCV", "TenCV");
            ViewBag.MaNV = new SelectList(db.TAIKHOANs, "MaTK", "TenTaiKhoan");
            return View(nv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoTenNV,SDT,NgaySinh,GioiTinh,MaCV,HinhAnh,ImageUpload")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                if (nHANVIEN.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(nHANVIEN.ImageUpload.FileName);
                    string extension = Path.GetExtension(nHANVIEN.ImageUpload.FileName);
                    fileName = fileName + extension;
                    nHANVIEN.HinhAnh = "~/Content/img/" + fileName;
                    nHANVIEN.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCV = new SelectList(db.CHUCVUs, "MaCV", "TenCV", nHANVIEN.MaCV);
            ViewBag.MaNV = new SelectList(db.TAIKHOANs, "MaTK", "TenTaiKhoan", nHANVIEN.MaNV);
            return View(nHANVIEN);
        }

        // GET: Admin/Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCV = new SelectList(db.CHUCVUs, "MaCV", "TenCV", nHANVIEN.MaCV);
            ViewBag.MaNV = new SelectList(db.TAIKHOANs, "MaTK", "TenTaiKhoan", nHANVIEN.MaNV);
            return View(nHANVIEN);
        }

        // POST: Admin/Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoTenNV,SDT,NgaySinh,GioiTinh,MaCV,HinhAnh,ImageUpload")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                if (nHANVIEN.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(nHANVIEN.ImageUpload.FileName);
                    string extension = Path.GetExtension(nHANVIEN.ImageUpload.FileName);
                    fileName = fileName + extension;
                    nHANVIEN.HinhAnh = "~/Content/img/" + fileName;
                    nHANVIEN.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCV = new SelectList(db.CHUCVUs, "MaCV", "TenCV", nHANVIEN.MaCV);
            ViewBag.MaNV = new SelectList(db.TAIKHOANs, "MaTK", "TenTaiKhoan", nHANVIEN.MaNV);
            return View(nHANVIEN);
        }

        // GET: Admin/Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: Admin/Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
