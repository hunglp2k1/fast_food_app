using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace fast_food_app.Areas.Admin.Controllers
{
    public class AccountsController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Accounts
        public ActionResult Index(string accountName)
        {
            ViewBag.AccountName = accountName;
            Accounts_Dao account_Dao = new Accounts_Dao();
            var accounts = account_Dao.ComboList(accountName);
            if (accounts.Count == null)
            {
                ViewBag.Error = "Khong tim thay san pham";
            }
            return View(accounts);
        }

        // GET: Admin/Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {
            ViewBag.MaTK = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV");
            ViewBag.MaQuyen = new SelectList(db.QUYENs, "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTK,MaQuyen,TenTaiKhoan,MatKhau,TrangThai")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.TAIKHOANs.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTK = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", tAIKHOAN.MaTK);
            ViewBag.MaQuyen = new SelectList(db.QUYENs, "MaQuyen", "TenQuyen", tAIKHOAN.MaQuyen);
            return View(tAIKHOAN);
        }

        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTK = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", tAIKHOAN.MaTK);
            ViewBag.MaQuyen = new SelectList(db.QUYENs, "MaQuyen", "TenQuyen", tAIKHOAN.MaQuyen);
            return View(tAIKHOAN);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTK,MaQuyen,TenTaiKhoan,MatKhau,TrangThai")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTK = new SelectList(db.NHANVIENs, "MaNV", "HoTenNV", tAIKHOAN.MaTK);
            ViewBag.MaQuyen = new SelectList(db.QUYENs, "MaQuyen", "TenQuyen", tAIKHOAN.MaQuyen);
            return View(tAIKHOAN);
        }

        // GET: Admin/Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            db.TAIKHOANs.Remove(tAIKHOAN);
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
