using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;


namespace Models.Dao
{
    public class MenuDao
    {
        CamShopDbContext db = null;
        public MenuDao()
        {
            db = new CamShopDbContext();
        }

        public List<DanhMuc> ListByGroupId(int groupID)
        {
            return db.DanhMucs.Where(x => x.groupID == groupID &&x.trangThai==true).ToList();
        }

        public DanhMuc ViewDetail(int danhMucID)
        {
            return db.DanhMucs.Find(danhMucID);
        }

        //Phân trang và tìm kiếm danh mục theo tên
        public IEnumerable<DanhMuc> ListAllPaging(string seachString, int page, int pageSize)
        {
            IQueryable<DanhMuc> model = db.DanhMucs;
            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.tenDanhMuc.Contains(seachString));
            }

            //Liệt kê giảm dần
            return model.OrderByDescending(x => x.danhMucID).ToPagedList(page, pageSize);
        }

    }
}
