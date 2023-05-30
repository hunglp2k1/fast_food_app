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
     
    }
}
