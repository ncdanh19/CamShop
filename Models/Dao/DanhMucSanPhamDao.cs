using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
