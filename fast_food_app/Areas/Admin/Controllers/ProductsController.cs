using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Model.DAO;
using Model.EF;
using PagedList;

namespace fast_food_app.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Products
        public ActionResult Index(int? page, string currentFilter, string productName, int categoryId = -1)
        {
            ViewBag.ProductName = productName;
            ViewBag.CategoryId = categoryId;
            Products_Dao products_Dao = new Products_Dao();
            if (productName != null)
            {
                page = 1;
            }
            else
            {
                productName = currentFilter;
            }

            var monAns = products_Dao.ProductList(productName, categoryId,"");

            ViewBag.CurrentFilter = productName;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            monAns = monAns.OrderByDescending(m => m.MaMonAn).ToList();
            return View(monAns.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONANs.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            return View(mONAN);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            MONAN ma = new MONAN();
            ViewBag.MaLoaiMonAn = new SelectList(db.LOAIMONANs, "MaLoaiMonAn", "TenLoaiMonAn");
            return View(ma);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMonAn,TenMonAn,MoTa,Anh,MaLoaiMonAn,Gia,SoLuong,ImageUpload")] MONAN mONAN)
        {
            if (ModelState.IsValid)
            {
                if (mONAN.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mONAN.ImageUpload.FileName);
                    string extension = Path.GetExtension(mONAN.ImageUpload.FileName);
                    fileName = fileName + extension;
                    mONAN.Anh = "~/Content/img/" + fileName;
                    mONAN.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }
                db.MONANs.Add(mONAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiMonAn = new SelectList(db.LOAIMONANs, "MaLoaiMonAn", "TenLoaiMonAn", mONAN.MaLoaiMonAn);
            return View(mONAN);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONANs.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiMonAn = new SelectList(db.LOAIMONANs, "MaLoaiMonAn", "TenLoaiMonAn", mONAN.MaLoaiMonAn);
            return View(mONAN);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMonAn,TenMonAn,MoTa,Anh,MaLoaiMonAn,Gia,SoLuong,ImageUpload")] MONAN mONAN)
        {
            
            if (ModelState.IsValid)
            {
                if (mONAN.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(mONAN.ImageUpload.FileName);
                    string extension = Path.GetExtension(mONAN.ImageUpload.FileName);
                    fileName = fileName + extension;
                    mONAN.Anh = "~/Content/img/" + fileName;
                    mONAN.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/"), fileName));
                }
                db.Entry(mONAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiMonAn = new SelectList(db.LOAIMONANs, "MaLoaiMonAn", "TenLoaiMonAn", mONAN.MaLoaiMonAn);
            return View(mONAN);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONANs.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            return View(mONAN);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MONAN mONAN = db.MONANs.Find(id);
            db.MONANs.Remove(mONAN);
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
