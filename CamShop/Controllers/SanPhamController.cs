using Models.Dao;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CamShop.Controllers
{
    public class SanPhamController : Controller
    {
        CamShopDbContext db = new CamShopDbContext();
        public string MetaTag()
        {
            var strMetatag = new StringBuilder();
            strMetatag.AppendFormat(@"<meta content='{0}' name = 'keyword'/>", "Cung,cap,thiet-bi,may-and,chinh,hang,so,1,vietnam");
            strMetatag.AppendFormat(Environment.NewLine);
            strMetatag.AppendFormat(@"<meta content='{0}' name = 'description'/>", "Cung cấp thiết bị máy ảnh chính hãng số 1 Việt Nam");
            return strMetatag.ToString();
        }
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
        
        public ActionResult Category(int loaihangID, int? page, int pageSize = 8)
        {
            ViewBag.MetaTag = MetaTag();
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

        [ChildActionOnly]
        public ActionResult LeftMenuThuongHieu()
        {
            //var leftmenu = new DanhMucSanPhamDao().listByThuongHieu();

            ViewBag.thuongHieu = db.ThuongHieux.ToList();

            return PartialView();
        }
        public ActionResult LocSanPhamTheoThuongHieu(int thuongHieuID, int? page, int pageSize = 8)
        {
            if (page == null)
            {
                page = 1;
            }
            var listTH = db.SanPhams.Where(x => x.thuongHieu == thuongHieuID).OrderBy(x=>x.tenSanPham).ToPagedList(page.Value, pageSize);

            ViewBag.ThuongHieu = db.ThuongHieux.Find(thuongHieuID);
            return View(listTH);
        }

        public JsonResult ListName(string q)
        {
            var sanpham = db.SanPhams.ToList();

            var data = (from a in db.SanPhams
                        where a.tenSanPham.Contains(q)
                        select new
                        {
                            tenSanPham = a.tenSanPham,
                            donGia = a.donGia,
                            hinhAnh = a.hinhAnh,
                            MetaTitle = a.MetaTitle,
                            sanPhamID = a.sanPhamID,
                        }).AsEnumerable().Select(x => new SanPham()
                        {
                            tenSanPham = x.tenSanPham,
                            donGia = x.donGia,
                            hinhAnh = x.hinhAnh,
                            MetaTitle = x.MetaTitle,
                            sanPhamID = x.sanPhamID,
                        });
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}