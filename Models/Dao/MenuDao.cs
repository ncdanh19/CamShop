using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
