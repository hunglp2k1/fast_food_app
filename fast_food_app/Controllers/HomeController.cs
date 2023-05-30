using fast_food_app.Models;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace fast_food_app.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index(string productName, int categoryId = -1, string sortByPrice = "DEFAULT")
        {
            Products_Dao products_Dao = new Products_Dao();
            var monAns = products_Dao.ProductList(productName, categoryId, sortByPrice);          
            ViewBag.ProductName = productName;
            ViewBag.CategoryId = categoryId;
            ViewBag.SortType = sortByPrice;
            return View(monAns);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }


    }
}