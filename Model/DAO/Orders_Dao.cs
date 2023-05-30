using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Orders_Dao
    {
        FastFoodDBContext db;
        public Orders_Dao()
        {
            db = new FastFoodDBContext();
        }

        public double? Get_Promotion(int hoadonId)
        {
            var hd = db.HOADONs.Find(hoadonId);
            var promotionId = (int)hd.MaKM;
            var percent = db.KHUYENMAIs.Find(promotionId).TiLeGiamGia;
            return percent;
        }

       
        
     
    }
}
