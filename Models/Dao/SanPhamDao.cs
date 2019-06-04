﻿using Models.EF;
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
        public IPagedList<SanPham> ListByCateID(int danhmucID, int? page, int pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);

            return db.SanPhams.Where(x => x.loaiHang == danhmucID).OrderBy(x => x.sanPhamID).ToPagedList(pageNumber, pageSize);
        }
        //List sản phẩm mới
        public List<SanPham> ListNewProduct(int top)
        {
            return db.SanPhams.OrderByDescending(x => x.NgayTao).Take(top).ToList();
        }

        //Sản phẩm liên quan
        public List<SanPham> ListRelated(int idSanPham, int top)
        {
            var sanpham = db.SanPhams.Find(idSanPham);
            return db.SanPhams.Where(x => x.loaiHang == sanpham.loaiHang && x.sanPhamID != idSanPham).Take(top).ToList();
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

        //Phân trang và tìm kiếm sản phẩm theo tên
        public IEnumerable<SanPham> ListAllPaging(string seachString, int page, int pageSize)
        {
            IQueryable<SanPham> model = db.SanPhams;
            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.tenSanPham.Contains(seachString));
            }

            //Liệt kê giảm dần
            return model.OrderByDescending(x => x.sanPhamID).ToPagedList(page, pageSize);
        }

    }
}
