﻿using Models.EF;
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
    }
}
