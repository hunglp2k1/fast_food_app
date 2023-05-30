using fast_food_app.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fast_food_app.Controllers
{
    public class ShoppingCartController : Controller
    {
        FastFoodDBContext db = new FastFoodDBContext();

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        //method add item into cart
        // GET: ShoppingCart
        public ActionResult AddToCart(int? id)
        {
            var pro = db.MONANs.SingleOrDefault(s => s.MaMonAn == id);
            if(pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }


        //method display cart
        public ActionResult ShowToCart(int discount = -1)
        {
            TempData["Discount"] = discount;
            Session["MaKM"] = discount;
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
            {
                total_item += cart.Total_Quantity();
            }
            ViewBag.infoCart = total_item;
            return PartialView("BagCart");
        }
        public ActionResult Shopping_Success()
        {
            Session["MaKM"] = null;
            return View();
        }

        //Method checkout
        public ActionResult CheckOut(FormCollection form)
        {
                
                Cart cart = Session["Cart"] as Cart;
                ViewBag.Discount = (int)(Session["MaKM"]);
                HOADON hOADON = new HOADON();
                hOADON.ThoiGian = DateTime.Now;
                hOADON.MaNV = int.Parse(Session["UserID"].ToString());
                hOADON.MaKM = (int)ViewBag.Discount;
                db.HOADONs.Add(hOADON);
                foreach(var item in cart.Items)
                {
                CHITIET_HOADON cHITIET_HOADON = new CHITIET_HOADON
                {
                    MaHD = hOADON.MaHD,
                    MaMonAn = item._shopping_product.MaMonAn,
                    SoLuong = item._shopping_quantity
                };
                
                db.CHITIET_HOADON.Add(cHITIET_HOADON);
                }
                db.SaveChanges();            
                cart.ClearCart();
                return RedirectToAction("Shopping_Success", "ShoppingCart");          
        }
    }
}