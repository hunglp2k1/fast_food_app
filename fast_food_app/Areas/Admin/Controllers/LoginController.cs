using fast_food_app.Areas.Admin.Models;
using fast_food_app.Commons;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace fast_food_app.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Session["username"] = "";
                var db = new FastFoodDBContext();

                var user = db.TAIKHOANs.Where(s => s.TenTaiKhoan.Equals(model.TenTaiKhoan) && s.MatKhau.Equals(model.MatKhau)).SingleOrDefault();
                if (user != null)
                {
                    Session["username"] = user.TenTaiKhoan;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View("Index");
        }


      

    }
}