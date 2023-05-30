using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Staffs_Dao
    {
        FastFoodDBContext db;
        public Staffs_Dao()
        {
            db = new FastFoodDBContext();
        }

        public List<NHANVIEN> ComboList()
        {
            var list = db.NHANVIENs.ToList();
            return list;
        }

        public List<NHANVIEN> ComboList(string staffName)
        {
            List<NHANVIEN> staffs;
            if (string.IsNullOrEmpty(staffName))
            {
                staffs = db.NHANVIENs.ToList();
            }
            else
            {
                staffs = db.NHANVIENs.Where(m => m.HoTenNV.ToLower().Contains(staffName.ToLower())).ToList();
            }

            return staffs;
        }
    }
}
