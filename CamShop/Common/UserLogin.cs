﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamShop.Common
{
    [Serializable] //Có khả năng kết nối
    //Sử dụng cho global
    public class UserLogin
    {
        public int UserID { set; get; }
        public string UserName { set; get; }
    }
}