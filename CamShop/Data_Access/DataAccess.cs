using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using Models.EF;

namespace CamShop.Data_Access
{
    public class DataAccess
    {
        CamShopDbContext db = null;

        public DataAccess()
        {
            db = new CamShopDbContext();
        }

        public int ThemKhachHang(KhachHang khachHang)
        {
            db.KhachHangs.Add(khachHang);
            db.SaveChanges();
            return khachHang.khachHangID;
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

        public int ThemThanhToan(ThanhToan thanhToan)
        {
            db.ThanhToans.Add(thanhToan);
            db.SaveChanges();
            return thanhToan.hoaDonID;
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public KhachHang KhachHangGetByID(string soDienThoai)
        {
            return db.KhachHangs.SingleOrDefault(x => x.soDienThoai == soDienThoai);
        }

        public int KhachHangLogin(string soDienThoai, string passWord)
        {
            var result = db.KhachHangs.SingleOrDefault(x => x.soDienThoai == soDienThoai);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.passWord == passWord)
                {
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
        }


    }
} 