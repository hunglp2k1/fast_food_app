using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fast_food_app.Models;
using System.Collections;

namespace fast_food_app.Controllers
{
    public class MenuLoaiController : Controller
    {
        // GET: MenuLoai
        public ActionResult Index()
        {
            using (FastFoodEntities db = new FastFoodEntities())
            {
                var loaimonan = db.LOAIMONANs.ToList();
                Hashtable tenloai = new Hashtable();
                foreach (var item in loaimonan)
                {
                    tenloai.Add(item.MaLoaiMonAn, item.TenLoaiMonAN);
                }
                ViewBag.TenLoai = tenloai;
                return PartialView("Index");
            }
        }
    }
}