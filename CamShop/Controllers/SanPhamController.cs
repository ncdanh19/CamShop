using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamShop.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        
        //Menu sản phẩm
        [ChildActionOnly]
        public PartialViewResult MainMenu()
        {
            var model = new SanPhamDao().ListAll();
            return PartialView(model);
        }


        public ActionResult Category(int loaihangID, int? page, int pageSize =5 )
        {
            var category = new DanhMucSanPhamDao().ViewDetail(loaihangID);
            ViewBag.LoaiHang = category;
            if (page == null)
            {
                page = 1;
            }

            var model = new SanPhamDao().ListByCateID(loaihangID,page,pageSize);

            return View(model);
        }
        //Chi tiết sản phẩm
        public ActionResult Detail(int id)
        {
            var sanPham = new SanPhamDao().ViewDetail(id);
            ViewBag.LoaiHang = new MenuDao().ViewDetail(sanPham.loaiHang.Value);
            ViewBag.sanPhamLienQuan = new SanPhamDao().ListRelated(id,4); //hiển thị 4 sản phẩm liên quan
            return View(sanPham);
        }

        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            var leftmenu = new DanhMucSanPhamDao().listCategories();
            return PartialView(leftmenu);
        }
    }
}