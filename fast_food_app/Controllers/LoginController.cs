using fast_food_app.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fast_food_app.Controllers
{
    public class LoginController : Controller
    {
        FastFoodDBContext db = new FastFoodDBContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            ViewBag.Username = model.TenTaiKhoan;
            ViewBag.Password = model.MatKhau;
            if (ModelState.IsValid)
            {
                var user = db.TAIKHOANs.Where(m => m.TenTaiKhoan.Equals(model.TenTaiKhoan) && m.MatKhau.Equals(model.MatKhau)).SingleOrDefault();
                if (user != null && user.MaQuyen.Equals(3))
                {
                    Session["UserAccount"] = user.TenTaiKhoan.ToString();
                    Session["UserName"] = user.NHANVIEN.HoTenNV.ToString();
                    Session["UserGender"] = user.NHANVIEN.GioiTinh.ToString();
                    Session["UserImage"] = user.NHANVIEN.HinhAnh.ToString();
                    Session["UserPosition"] = user.NHANVIEN.CHUCVU.TenCV.ToString();
                    Session["UserID"] = user.NHANVIEN.MaNV.ToString();

                    return RedirectToAction("Index", "Home");
                }
                else if(user != null && !user.MaQuyen.Equals(3))
                {
                    ModelState.AddModelError("", "Không có quyền truy cập");
                }
                else if (user != null && user.TrangThai.Equals(false))
                {
                    ModelState.AddModelError("", "Tài khoản bị vô hiệu hoá");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
                
            return View();
        }
    }
}