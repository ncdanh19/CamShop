using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.Dao
{
    public class DanhMucSanPhamDao
    {
        CamShopDbContext db = null;
        public DanhMucSanPhamDao()
        {
            db = new CamShopDbContext();
        }

        public LoaiHang ViewDetail(int loaihangID)
        {
            return db.LoaiHangs.Find(loaihangID);
        }

        public List<LoaiHang> listCategories()
        {
            return db.LoaiHangs.ToList();
        }

        public List<ThuongHieu> listByThuongHieu()
        {
            return db.ThuongHieux.ToList();
        }

        //Phân trang user
        public IEnumerable<LoaiHang> ListAllPaging(string seachString, int page, int pageSize)
        {
            IQueryable<LoaiHang> model = db.LoaiHangs;
            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.tenLoai.Contains(seachString));
            }
            //Liệt kê giảm dần
            return model.OrderByDescending(x => x.loaiHangID).ToPagedList(page, pageSize);
        }
    }
}
