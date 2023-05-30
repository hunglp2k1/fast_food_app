using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Order_Details_Dao
    {
        FastFoodDBContext db;
        public Order_Details_Dao()
        {
            db = new FastFoodDBContext();
        }

        
    }
}
