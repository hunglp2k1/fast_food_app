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

            ViewBag.Username = model.TenTaiKhoan;
            ViewBag.Password = model.MatKhau;

            if (ModelState.IsValid)
            {
                Session["username"] = "";
                var db = new FastFoodDBContext();


                var user = db.TAIKHOANs.Where(m => m.TenTaiKhoan.Equals(model.TenTaiKhoan) && m.MatKhau.Equals(model.MatKhau)).SingleOrDefault();
                if (user != null && user.MaQuyen.Equals(1))
                {
                    Session["UserAccount"] = user.TenTaiKhoan.ToString();
                    Session["UserName"] = user.NHANVIEN.HoTenNV.ToString();
                    Session["UserGender"] = user.NHANVIEN.GioiTinh.ToString();
                    Session["UserImage"] = user.NHANVIEN.HinhAnh.ToString();
                    Session["UserPosition"] = user.NHANVIEN.CHUCVU.TenCV.ToString();
                    Session["UserID"] = user.NHANVIEN.MaNV.ToString();

                    return RedirectToAction("Index", "Home");
                }
                else if (user != null && !user.MaQuyen.Equals(1))
                {
                    ModelState.AddModelError("", "Không có quyền truy cập");
                }
                else if (user != null && user.TrangThai.Equals(false))
                {
                    ModelState.AddModelError("", "Tài khoản bị vô hiệu hoá");
                }

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