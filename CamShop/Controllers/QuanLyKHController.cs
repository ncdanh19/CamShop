using CamShop.Common;
using CamShop.Models;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CamShop.Controllers
{
    public class QuanLyKHController : BaseClientController
    {
        CamShopDbContext db = new CamShopDbContext();

        //Bien cuc bo luu id cua khach
        private static int maKhach;

        //Bien cuc bo luu id cua hoa don
        private static int hoadonID;
        // GET: QuanLyKH
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LichSuMuaHang()
        {
            ViewBag.lichSuMuaHang = db.HoaDons.Where(x => x.maKhach == maKhach).ToList();
            return View();
        }

        public ActionResult DetailsGet(int id)
        {
            maKhach = id;
            return RedirectToAction("Details");
        }

        // GET: QuanLyKH/Details/5
        public ActionResult Details()
        {
            KhachHang user = db.KhachHangs.Find(maKhach);
            return View(user);
        }

        // GET: QuanLyKH/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            maKhach = id;

            KhachHang user = db.KhachHangs.Find(maKhach);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: QuanLyKH/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KhachHang user)
        {
            // gán các item của user vào item thông tin
            var thongTin = new KhachHang();
            thongTin.khachHangID = user.khachHangID;
            thongTin.userName = user.userName;
            thongTin.passWord = user.passWord;
            thongTin.hoTen = user.hoTen;
            thongTin.diaChi = user.diaChi;
            thongTin.eMail = user.eMail;
            thongTin.soDienThoai = user.soDienThoai;
            thongTin.trangThai = true;

            // gán các item của user vào item userSession
            var userSession = new UserLogin();
            userSession.UserID = user.khachHangID;
            userSession.UserName = user.userName;
            userSession.Name = user.hoTen;
            userSession.Address = user.diaChi;
            userSession.Email = user.eMail;
            userSession.Phone = user.soDienThoai;
            Session.Add(CommonConstants.USER_SESSION, userSession);

            // nếu đúng thì lưu item thông tin và chuyển hướng về details
            if (ModelState.IsValid)
            {
                db.Entry(thongTin).State = EntityState.Modified;
                db.SaveChanges();
                TempData[MyAlerts.SUCCESS] = "Cập nhật thông tin thành công";
                return RedirectToAction("Edit");
            }
            return View(thongTin);
        }

        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            KhachHang user = db.KhachHangs.Find(maKhach);
            return View(user);
        }

        [HttpPost]
        public ActionResult DoiMatKhau(int khachHangID, string userName, string passWord, string hoTen, string soDienThoai, string diaChi, string eMail, string newPass, string confPass)
        {
            var md5 = Encrytor.MD5Hash(passWord);
            var md5newpass = Encrytor.MD5Hash(newPass);
            var md5confpass = Encrytor.MD5Hash(confPass);

            var thongTin = new KhachHang();
            thongTin.khachHangID = khachHangID;
            thongTin.userName = userName;
            thongTin.passWord = md5newpass;
            thongTin.hoTen = hoTen;
            thongTin.soDienThoai = soDienThoai;
            thongTin.diaChi = diaChi;
            thongTin.eMail = eMail;
            thongTin.trangThai = true;
            if (ModelState.IsValid)
            {
                if (passWord == "")
                {
                    ModelState.AddModelError("", "Hãy nhập mật khẩu hiện tại");
                }
                else if (newPass == "")
                {
                    ModelState.AddModelError("", "Hãy nhập mật khẩu mới");
                }
                else if (confPass == "")
                {
                    ModelState.AddModelError("", "Hãy nhập xác nhận mật khẩu");
                }
                else if (passWord != "" && newPass != "" && confPass != "")
                {
                    if (db.KhachHangs.Where(x => x.passWord == md5 && x.khachHangID == maKhach).Count() > 0)
                    {
                        if (md5newpass == md5confpass)
                        {
                            db.Entry(thongTin).State = EntityState.Modified;
                            db.SaveChanges();
                            Session[CommonConstants.USER_SESSION] = null;
                            return Redirect("/dang-nhap/");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật khẩu hiện tại không chính xác");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Vui nhập đầy đủ thông tin");
                }
            }
            return View(thongTin);
        }

        public ActionResult XemChiTietHoaDon(int id)
        {
            ViewBag.hoaDon = db.HoaDons.Find(id);
            ViewBag.giaoHang = db.GiaoHangs.SingleOrDefault(x => x.hoaDonID == id);
            ViewBag.traHang = db.TraHangs.Where(x => x.hoaDonID == id).ToList();
            var chiTiet = db.ChiTietHoaDons.Where(x => x.hoaDonID == id).ToList();

            return View(chiTiet);
        }


        public ActionResult LichSuTraHang()
        {
            ViewBag.lichSuTraHang = db.TraHangs.Where(x => x.HoaDon.maKhach == maKhach).ToList();
            return View();
        }

        public ActionResult TraHangGet(int id)
        {
            hoadonID = id;
            return RedirectToAction("TraHang");
        }

        [HttpGet]
        public ActionResult TraHang()
        {
            HoaDon hoaDon = db.HoaDons.Find(hoadonID);
            hoadonID = hoaDon.hoaDonID;
            //Kiểm tra sản phẩm chưa được trả trong hóa đơn
            var check = db.ChiTietHoaDons.Where(x => x.hoaDonID == hoadonID &&
                !db.TraHangs.Any(th => th.chitietHDID == x.chitietID &&
                x.hoaDonID == th.hoaDonID));
            ViewBag.ctHoaDon = new SelectList(check.Include(x => x.SanPham), "chitietID", "SanPham.tenSanPham");
            return View(hoaDon);
        }

        [HttpPost]
        public ActionResult TraHang(FormCollection data)
        {
            var traHang = new TraHang();
            traHang.hoaDonID = hoadonID;
            traHang.chitietHDID = int.Parse(data[0].ToString());
            traHang.lyDo = data[1].ToString();
            traHang.ngayTra = System.DateTime.Now;


            var cthd = db.ChiTietHoaDons.Where(x => x.hoaDonID == traHang.hoaDonID && !db.TraHangs.Any(y => y.chitietHDID == x.chitietID && y.hoaDonID == x.hoaDonID)).Count();

            ChiTietHoaDon chiTiet = db.ChiTietHoaDons.Find(traHang.chitietHDID);

            if (ModelState.IsValid)
            {
                if (traHang.lyDo != "")
                {
                    if (cthd == 1)
                    {
                        var hd = db.HoaDons.Find(traHang.hoaDonID);
                        hd.trangThai = false;
                    }

                    SanPham soLuongChiTiet = db.SanPhams.Find(chiTiet.sanPhamID);
                    soLuongChiTiet.soLuong = soLuongChiTiet.soLuong + chiTiet.soLuong;
                    db.Entry(soLuongChiTiet).State = EntityState.Modified;
                    db.TraHangs.Add(traHang);
                    db.SaveChanges();
                    return Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    ModelState.AddModelError("", "Vui lòng cho chúng tôi biết lý do");
                }

            }
            return View();
        }

        //Post: Trả đơn hàng
        [HttpPost]
        public ActionResult TraTatCa(string lyDo)
        {
            var traHang = new TraHang();
            traHang.hoaDonID = hoadonID;
            traHang.lyDo = lyDo;
            traHang.ngayTra = System.DateTime.Now;

            HoaDon hoaDon = db.HoaDons.Find(hoadonID);
            hoaDon.trangThai = false;

            var chiTiet = db.ChiTietHoaDons.Where(x => x.hoaDonID == hoadonID).ToList();

            if (ModelState.IsValid)
            {
                if (traHang.lyDo != "")
                {
                    foreach (var item in chiTiet)
                    {
                        traHang.chitietHDID = item.chitietID;
                        db.TraHangs.Add(traHang);
                        SanPham soLuongChiTiet = db.SanPhams.Find(item.sanPhamID);
                        soLuongChiTiet.soLuong = soLuongChiTiet.soLuong + item.soLuong;
                        db.Entry(soLuongChiTiet).State = EntityState.Modified;
                        db.SaveChanges();

                        return Redirect(Request.UrlReferrer.ToString());
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Vui lòng cho chúng tôi biết lý do");  
                }
            }
            return View();
        }

        //Get: Hủy đơn hàng
        [HttpGet]
        public ActionResult HuyDon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        //Post: Hủy đơn hàng
        [HttpPost]
        public ActionResult HuyDon(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            hoaDon.trangThai = null;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}