using Models.Dao;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamShop.Controllers
{
    public class SanPhamController : Controller
    {
        CamShopDbContext db = new CamShopDbContext();

        // GET: SanPham
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new SanPhamDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
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
            ViewBag.RelatedSanPham = new SanPhamDao().ListRelated(id);
            return View(sanPham);
        }

        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            var leftmenu = new DanhMucSanPhamDao().listCategories();
            return PartialView(leftmenu);
        }

        [ChildActionOnly]
        public ActionResult LeftMenuThuongHieu()
        {
            //var leftmenu = new DanhMucSanPhamDao().listByThuongHieu();

            ViewBag.thuongHieu = db.ThuongHieux.ToList();

            return PartialView();
        }
        public ActionResult LocSanPhamTheoThuongHieu(int thuongHieuID, int? page, int pageSize = 5)
        {
            if (page == null)
            {
                page = 1;
            }
            var listTH = db.SanPhams.Where(x => x.thuongHieu == thuongHieuID).OrderBy(x=>x.tenSanPham).ToPagedList(page.Value, pageSize);

            ViewBag.ThuongHieu = db.ThuongHieux.Find(thuongHieuID);
            return View(listTH);
        }
    }
}