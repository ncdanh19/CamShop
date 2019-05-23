using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class ThanhToanDao
    {
        CamShopDbContext db = null;
        public ThanhToanDao()
        {
            db = new CamShopDbContext();
        }

        public int ThemHoaDon(HoaDon hoaDon)
        {
            db.HoaDons.Add(hoaDon);
            db.SaveChanges();
            return hoaDon.hoaDonID;
        }

        public int ThemGiaoHang(GiaoHang giaoHang)
        {
            db.GiaoHangs.Add(giaoHang);
            db.SaveChanges();
            return giaoHang.giaoHangID;
        }
    }
}
