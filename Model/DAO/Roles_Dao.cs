using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Roles_Dao
    {
        FastFoodDBContext db;
        public Roles_Dao()
        {
            db = new FastFoodDBContext();
        }

        public List<QUYEN> RoleList()
        {
            var list = db.QUYENs.ToList();
            return list;
        }

        public List<QUYEN> RoleList(string roleName)
        {
            List<QUYEN> quyens;
            if (string.IsNullOrEmpty(roleName))
            {
                quyens = db.QUYENs.ToList();
            }
            else
            {
                quyens = db.QUYENs.Where(m => m.TenQuyen.ToLower().Contains(roleName.ToLower())).ToList();
            }

            return quyens;
        }
    }
}
