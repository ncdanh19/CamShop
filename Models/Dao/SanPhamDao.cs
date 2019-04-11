using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class SanPhamDao
    {
        CamShopDbContext db = null;
        public SanPhamDao()
        {
            db = new CamShopDbContext();
        }

        public List<SanPham> ListAll()
        {
            return db.SanPhams.ToList();
        }

        //List sản phẩm theo danh mục
        public List<SanPham> ListByCateID(int danhmucID)
        {
            return db.SanPhams.Where(x => x.loaiHang == danhmucID).ToList();
        }
        //List sản phẩm mới
        public  List<SanPham> ListNewProduct(int top)
        {
            return db.SanPhams.OrderByDescending(x => x.NgayTao).Take(top).ToList();
        }

        //Sản phẩm liên quan
        public List<SanPham> ListRelated(int idSanPham)
        {
            var sanpham = db.SanPhams.Find(idSanPham);
            return db.SanPhams.Where(x => x.loaiHang == sanpham.loaiHang && x.sanPhamID != idSanPham).ToList();
        }

        //Chi tiết sản phẩm
        public SanPham ViewDetail(int id)
        {
            return db.SanPhams.Find(id);
        }
    }
}
