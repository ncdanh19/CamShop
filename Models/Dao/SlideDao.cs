using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class SlideDao
    {
        CamShopDbContext db = null;
        public SlideDao()
        {
            db = new CamShopDbContext();
        }
        public List<Slide> ListAll()
        {            
            return db.Slides.Where(x => x.trangThai == true).ToList();
        }
        //Phân trang 
        public IEnumerable<Slide> ListAllPaging(string seachString, int page, int pageSize)
        {
            IQueryable<Slide> model = db.Slides;
            if (!string.IsNullOrEmpty(seachString))
            {
                model = model.Where(x => x.tenSlide.Contains(seachString));
            }

            //Liệt kê giảm dần
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
