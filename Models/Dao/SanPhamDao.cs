using Models.EF;
using PagedList;
using System.Collections.Generic;
using System.Linq;

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

        //public List<SanPham> ListByCateID(int danhmucID, ref int totalRecord, int page = 1, int pageSize = 5)
        //{
        //    totalRecord = db.SanPhams.Where(x => x.loaiHang == danhmucID).Count();
        //    var model = db.SanPhams.Where(x => x.loaiHang == danhmucID).OrderByDescending(x => x.NgayTao).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //    return model;
        //}

        public IPagedList<SanPham> ListByCateID(int danhmucID, int? page, int pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);

            return db.SanPhams.Where(x => x.loaiHang == danhmucID).OrderBy(x => x.sanPhamID).ToPagedList(pageNumber,pageSize);
        }
        //List sản phẩm mới
        public List<SanPham> ListNewProduct(int top)
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

        //Sản phẩm nổi bật
        public List<SanPham> ListHotProduct(int hot)
        {
            return db.SanPhams.OrderByDescending(x => x.Hot).Take(hot).ToList();
        }
    }
}
