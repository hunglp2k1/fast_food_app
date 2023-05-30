using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fast_food_app.Models
{
    public class LoaiMonAn
    {

        FastFoodDBContext db;
        public LoaiMonAn()
        {
            db = new FastFoodDBContext();
        }
       
        public List<LOAIMONAN> getLoaiMA()
        {
            var loaiMA = db.LOAIMONANs.ToList();
            return loaiMA;
        }
    }
}