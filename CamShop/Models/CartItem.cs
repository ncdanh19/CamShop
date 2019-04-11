using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamShop.Models
{
    [Serializable]
    public class CartItem
    {
        public SanPham SanPham { get; set; }
        public short SoLuong { get; set; }
    }
}