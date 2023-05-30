using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class Accounts_Dao
    {
        FastFoodDBContext db;
        public Accounts_Dao()
        {
            db = new FastFoodDBContext();
        }

        public List<TAIKHOAN> ComboList()
        {
            var list = db.TAIKHOANs.ToList();
            return list;
        }

        public List<TAIKHOAN> ComboList(string accountName)
        {
            List<TAIKHOAN> taikhoans;
            if (string.IsNullOrEmpty(accountName))
            {
                taikhoans = db.TAIKHOANs.ToList();
            }
            else
            {
                taikhoans = (from tk in db.TAIKHOANs
                                 join nv in db.NHANVIENs on tk.MaTK equals nv.MaNV
                                 select tk).Where(m => m.NHANVIEN.HoTenNV.ToLower().Contains(accountName.ToLower())).ToList();
            }

            return taikhoans;
        }

        public TAIKHOAN getItem(string tenTaiKhoan)
        {
            return db.TAIKHOANs.FirstOrDefault(x => x.TenTaiKhoan == tenTaiKhoan);
        }

        public List<TAIKHOAN> getTAIKHOANs()
        {
            return db.TAIKHOANs.ToList();
        }

        public TAIKHOAN Add(TAIKHOAN account)
        {
            db.TAIKHOANs.Add(account);
            db.SaveChanges();
            return account;
        }

        public TAIKHOAN Update(TAIKHOAN account)
        {
            var ac = db.TAIKHOANs.FirstOrDefault(x => x.MaTK == account.MaTK);
            ac.TenTaiKhoan = ac.TenTaiKhoan;
            ac.MatKhau = account.MatKhau;
            ac.TrangThai = account.TrangThai;
            ac.QUYEN = account.QUYEN;
            db.SaveChanges();
            return ac;
        }

        public int Login(string Username, string Password)
        {
            var user = db.TAIKHOANs.FirstOrDefault(x => x.TenTaiKhoan == Username);
            if (user == null)
            {
                return -2; // Account không tồn tại
            }
            else
            {
                if (user.TrangThai == false)
                {
                    return 0; //Vô hiệu hoá
                }
                else
                {
                    if (user.MatKhau == Password)
                    {
                        return 1; // Login thành công
                    }
                    else
                    {
                        return -1; // Sai mật khẩu
                    }
                }
            }
        }
    }
}
       

     

