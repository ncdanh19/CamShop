using Models.Dao;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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

            ViewBag.countRating = db.DanhGias.Where(x => x.sanPhamID == id).Count();
            ViewBag.countRating_5 = db.DanhGias.Where(x => x.sanPhamID == id && x.Diem == 5).Count();
            ViewBag.countRating_4 = db.DanhGias.Where(x => x.sanPhamID == id && x.Diem == 4).Count();
            ViewBag.countRating_3 = db.DanhGias.Where(x => x.sanPhamID == id && x.Diem == 3).Count();
            ViewBag.countRating_2 = db.DanhGias.Where(x => x.sanPhamID == id && x.Diem == 2).Count();
            ViewBag.countRating_1 = db.DanhGias.Where(x => x.sanPhamID == id && x.Diem == 1).Count();

            ViewBag.danhGia = db.DanhGias.Where(x => x.sanPhamID == id).ToList();

            return View(sanPham);
        }

        public ActionResult DanhGia(int sanPhamID, int? diem, string binhLuan, HttpPostedFileBase[] filesUpload)
        {
            string mess = "";
            var session = (Common.UserLogin)Session[Common.CommonConstants.USER_SESSION];
            var danhGia = new DanhGia();
            danhGia.sanPhamID = sanPhamID;
            danhGia.khachHangID = session.UserID;
            danhGia.Diem = diem;
            danhGia.binhLuan = binhLuan;
            danhGia.NgayDanhGia = System.DateTime.Now;
            if (diem == null)
            {
                ModelState.AddModelError("", "Vui lòng cho biết điểm");
            }
            if (filesUpload[0] != null)
            {
                //Tạo 1 file XML có tên là Images
                XElement xElement = new XElement("Images");

                foreach (var item in filesUpload)
                {
                    //Lấy tên file
                    var fileName = Path.GetFileName(item.FileName);
                    //Lấy đường dẫn
                    var path = Path.Combine(Server.MapPath("~/RatingImages"), fileName);
                    //Lưu file vào thư mục /Content/images
                    item.SaveAs(path);

                    xElement.Add(new XElement("Image", "/RatingImages/" + fileName));
                }

                danhGia.nhieuHinhAnh = xElement.ToString();
            }
            if (ModelState.IsValid)
            {
                if (db.DanhGias.Where(x => x.khachHangID == session.UserID && x.sanPhamID == sanPhamID).Count() > 0)
                {
                    ModelState.AddModelError("", "Đã đánh giá sản phẩm này trước đó");
                }
                else
                {
                    if (filesUpload.Count() > 3)
                    {
                        ModelState.AddModelError("", "Chỉ được đăng tối đa 3 hình");
                        ViewBag.thongBao = "Chỉ được để tối đa 3 hình";
                    }
                    else
                    {
                        db.DanhGias.Add(danhGia);
                        db.SaveChanges();
                        var listDG = db.DanhGias.Where(x => x.sanPhamID == sanPhamID).Select(z => z.Diem).ToList();
                        //var diemTB = Math.Round(listDG.Average(), 1);
                        double diemtb = 0;
                        foreach (var dg in listDG)
                        {
                            diemtb += dg.Value;
                        }
                        diemtb = Math.Round((diemtb / listDG.Count()), 1);
                        SanPham sanPham = db.SanPhams.Find(sanPhamID);
                        sanPham.Rating = diemtb;
                        db.Entry(sanPham).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(mess, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Redirect(Request.UrlReferrer.ToString());
            }            
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

        public ActionResult LocSanPham(double? minprice, double? maxprice, int? page)
        {
            if (page == null)
            {
                page = 1;
            }

            int pageSize = 8;

            int pageNumber = (page ?? 1);
            if (minprice < maxprice)
            {
                var model = db.SanPhams.Where(x => x.donGia > minprice && x.donGia <= maxprice && x.soLuong > 0).ToList();
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                var model = db.SanPhams.Where(x => x.donGia <= minprice && x.donGia >= maxprice && x.soLuong > 0).ToList();
                return View(model.ToPagedList(pageNumber, pageSize));
            }
        }
    }
}