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
    public class PositionsController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Positions
        public ActionResult Index()
        {
            return View(db.CHUCVUs.ToList());
        }

        // GET: Admin/Positions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // GET: Admin/Positions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCV,TenCV")] CHUCVU cHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.CHUCVUs.Add(cHUCVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUCVU);
        }

        // GET: Admin/Positions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // POST: Admin/Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCV,TenCV")] CHUCVU cHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUCVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUCVU);
        }

        // GET: Admin/Positions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            if (cHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHUCVU);
        }

        // POST: Admin/Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUCVU cHUCVU = db.CHUCVUs.Find(id);
            db.CHUCVUs.Remove(cHUCVU);
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
