using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fast_food_app.Commons
{
    [Serializable]
    public class AccountLogin
    {
        public int AccountID { set; get; }
        public string Username { set; get; }
        public string FullName { set; get; }
        public string Role { set; get; }
    }
}