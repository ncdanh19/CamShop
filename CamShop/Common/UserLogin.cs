using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamShop.Common
{
    [Serializable]
    //Sử dụng cho global
    public class UserLogin
    {
        public int UserID { set; get; }

        public string UserName { set; get; }

        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
    }
}