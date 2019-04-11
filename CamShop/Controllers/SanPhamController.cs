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

        //Danh mục sản phẩm
        public ActionResult Category(int danhMucID)
        {
            var category = new MenuDao().ViewDetail(danhMucID);
            ViewBag.LoaiHang = category;
            var model = new SanPhamDao().ListByCateID(danhMucID);
            return View(model);
        }

        //Chi tiết sản phẩm
        public ActionResult Detail(int id)
        {
            var sanPham = new SanPhamDao().ViewDetail(id);
            ViewBag.LoaiHang = new MenuDao().ViewDetail(sanPham.loaiHang.Value);
            ViewBag.RelatedSanPham = new SanPhamDao().ListRelated(id);
            return View(sanPham);
        }
    }
}