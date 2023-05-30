using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Promotions_Dao
    {
        FastFoodDBContext db;
        public Promotions_Dao()
        {
            db = new FastFoodDBContext();
        }

        public List<KHUYENMAI> PromotionList()
        {
            var promotions = db.KHUYENMAIs.ToList();
            return promotions;
        }


    }
}
