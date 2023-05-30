using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fast_food_app.Areas.Admin.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage ="Vui lòng nhập tên tài khoản")]
        public string TenTaiKhoan { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string MatKhau { set; get; }
    }
}