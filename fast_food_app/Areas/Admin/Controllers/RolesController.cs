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
    public class RolesController : Controller
    {
        private FastFoodDBContext db = new FastFoodDBContext();

        // GET: Admin/Roles
        public ActionResult Index(string roleName)
        {
            ViewBag.RoleName = roleName;
            Roles_Dao roles_Dao = new Roles_Dao();
            var roles = roles_Dao.RoleList(roleName);
            if (roles.Count == null)
            {
                ViewBag.Error = "Khong tim thay san pham";
            }
            return View(roles);
        }

        // GET: Admin/Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUYEN qUYEN = db.QUYENs.Find(id);
            if (qUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUYEN);
        }

        // GET: Admin/Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQuyen,TenQuyen,GhiChu")] QUYEN qUYEN)
        {
            if (ModelState.IsValid)
            {
                db.QUYENs.Add(qUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUYEN);
        }

        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUYEN qUYEN = db.QUYENs.Find(id);
            if (qUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUYEN);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQuyen,TenQuyen,GhiChu")] QUYEN qUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUYEN);
        }

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUYEN qUYEN = db.QUYENs.Find(id);
            if (qUYEN == null)
            {
                return HttpNotFound();
            }
            return View(qUYEN);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUYEN qUYEN = db.QUYENs.Find(id);
            db.QUYENs.Remove(qUYEN);
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
