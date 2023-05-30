using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fast_food_app.Models
{
    public class CartItem
    {
        public MONAN _shopping_product { get; set; }
        public KHUYENMAI _shopping_discount { get; set; } 
        public int _shopping_quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        FastFoodDBContext db = new FastFoodDBContext();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public void Add(MONAN _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.MaMonAn == _pro.MaMonAn);
            //Neu gio hang trong
            if(item == null)
            {
                items.Add(new CartItem { _shopping_product = _pro, _shopping_quantity = _quantity});
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }

        public void Update_Quantity_Shopping(int id, int _quantity) { 
            var item = items.Find(s => s._shopping_product.MaMonAn == id);
            if(item != null)
            {
                item._shopping_quantity = _quantity;
            }
        }
        public int Total_Money(int discount)
        {
            var total = 0;
            var discount_price = 0;
            if(discount == -1)
            {
                total = Total_Money();
            }
            else
            {
                var promotion = db.KHUYENMAIs.Find(discount);
                total = (int)(items.Sum(s => s._shopping_product.Gia * s._shopping_quantity));       
                discount_price = (int)((total * promotion.TiLeGiamGia) / 100);
                total = total - discount_price;
            }         
            return (int)total;
        }

        public int Get_Discount_Price(int discount)
        {
            return (int)(this.Total_Money(discount) - this.Total_Money());
        }
        public int Total_Money()
        {
            var total = items.Sum(s => s._shopping_product.Gia * s._shopping_quantity);
            return (int)total;
        }

        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_product.MaMonAn == id);
        }

        public int Total_Quantity()
        {
            return items.Sum(s => s._shopping_quantity);
        }
        
        public void ClearCart()
        {
            items.Clear(); // Xoá cart để thực hiện order
        }
    }
}