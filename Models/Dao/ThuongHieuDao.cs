using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;


namespace Models.Dao
{
    public class ThuongHieuDao
    {
        CamShopDbContext db = null;
        public ThuongHieuDao()
        {
            db = new CamShopDbContext();
        }

        //Phân trang và tìm kiếm thương hiệu theo tên
        public IEnumerable<ThuongHieu> ListAllPaging(string seachString, int page, int pageSize)
        {
            IQueryable<ThuongHieu> model = db.ThuongHieux;
            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.tenThuongHieu.Contains(seachString));
            }

            //Liệt kê giảm dần
            return model.OrderByDescending(x => x.thuongHieuID).ToPagedList(page, pageSize);
        }

    }
}
