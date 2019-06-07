using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamShop 
{
    [Serializable]
    public class KhachHangLogin
    {
        public int KhachHangID { get; set; }
        public string soDienThoai { get; set; }
        public string HoTen { get; set; }
        public string diaChi { get; set; }
        public string eMail { get; set; }
    }
}