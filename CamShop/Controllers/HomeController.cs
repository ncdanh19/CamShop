using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.slides = new SlideDao().ListAll();
            var sanphamDao = new SanPhamDao();
            ViewBag.sanPhamMoi = new SanPhamDao().ListNewProduct(4);
            ViewBag.sanPhamHot = new SanPhamDao().ListHotProduct(3);
            ViewBag.categories = new DanhMucSanPhamDao().listCategories();
            return View();
        }

        //List menu
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }

        //Footer
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
    }
}