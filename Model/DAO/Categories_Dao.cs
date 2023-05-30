using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Categories_Dao
    {
        FastFoodDBContext db;
        public Categories_Dao()
        {
            db = new FastFoodDBContext();
        }

        public List<LOAIMONAN> CategoryList()
        {
            var list = db.LOAIMONANs.ToList();
            return list;
        }

        public List<LOAIMONAN> CategoryList(string categoryName)
        {
            List<LOAIMONAN> loaiMonAns;
            if (string.IsNullOrEmpty(categoryName))
            {
                loaiMonAns = db.LOAIMONANs.ToList();               
            }
            else {
                loaiMonAns = db.LOAIMONANs.Where(m => m.TenLoaiMonAn.ToLower().Contains(categoryName.ToLower())).ToList();
            }
            
            return loaiMonAns;
        }
    }
}
