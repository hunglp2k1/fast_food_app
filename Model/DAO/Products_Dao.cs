using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Products_Dao
    {
        FastFoodDBContext db;
        public Products_Dao()
        {
            db = new FastFoodDBContext();
        }

        public List<MONAN> ProductList()
        {
            var monAns = db.MONANs.ToList();

            return monAns;
        }

        public List<MONAN> ProductList(string productName, int? categoryId, string sortByPrice)
        {
            List<MONAN> monAns;

            if (!string.IsNullOrEmpty(productName))
            {
                if(categoryId == -1)
                {
                    monAns = db.MONANs.Where(m => m.TenMonAn.ToLower().Contains(productName.ToLower())).ToList();
                }
                else
                {
                    monAns = db.MONANs.Where(m => m.TenMonAn.ToLower().Contains(productName.ToLower())).Where(m => m.MaLoaiMonAn == categoryId).ToList();
                  
                }
            }                        
            else {
                if(categoryId == -1)
                {
                    switch (sortByPrice)
                    {
                        case "DESC": monAns = db.MONANs.OrderByDescending(m => m.Gia).ToList(); break;
                        case "ASC": monAns = db.MONANs.OrderBy(m => m.Gia).ToList(); break;
                        default: monAns = db.MONANs.ToList(); break;
                    }
                    return monAns;



                }
                else
                {
                    monAns = (from item in db.MONANs
                              join loai in db.LOAIMONANs on item.MaLoaiMonAn equals loai.MaLoaiMonAn
                              where loai.MaLoaiMonAn == categoryId
                              select item
                          ).ToList();                  
                }
                
            }
            return monAns;
        }
    }
}
