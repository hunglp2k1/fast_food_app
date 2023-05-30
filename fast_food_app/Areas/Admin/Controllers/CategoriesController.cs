using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using PagedList;

namespace fast_food_app.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Categories
        public ActionResult Index(string categoryName)
        {
            // 1. Lưu tư khóa tìm kiếm
            ViewBag.CategoryName = categoryName;
            Categories_Dao categories_Dao = new Categories_Dao();           
            var loaiMonAns = categories_Dao.CategoryList(categoryName);
            if(loaiMonAns.Count == null)
            {
                ViewBag.Error = "Khong tim thay san pham";
            }
            /*int pageSize = 10;
            int pageNumber = (page ?? 1);
            lOAIMONANs = lOAIMONANs.OrderByDescending(n => n.MaLoaiMonAn);*/
            return View(loaiMonAns);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMONAN lOAIMONAN = db.LOAIMONANs.Find(id);
            if (lOAIMONAN == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMONAN);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiMonAn,TenLoaiMonAn")] LOAIMONAN lOAIMONAN)
        {
            if (ModelState.IsValid)
            {
                db.LOAIMONANs.Add(lOAIMONAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAIMONAN);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMONAN lOAIMONAN = db.LOAIMONANs.Find(id);
            if (lOAIMONAN == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMONAN);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiMonAn,TenLoaiMonAn")] LOAIMONAN lOAIMONAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAIMONAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAIMONAN);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAIMONAN lOAIMONAN = db.LOAIMONANs.Find(id);
            if (lOAIMONAN == null)
            {
                return HttpNotFound();
            }
            return View(lOAIMONAN);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAIMONAN lOAIMONAN = db.LOAIMONANs.Find(id);
            db.LOAIMONANs.Remove(lOAIMONAN);
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
