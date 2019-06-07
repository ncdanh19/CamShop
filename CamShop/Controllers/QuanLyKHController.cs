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
        public ActionResult Edit()
        {
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
                return RedirectToAction("Details");
            }
            return View(user);
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
            if (ModelState.IsValid)
            {
                if(passWord == "")
                {
                    ModelState.AddModelError("", "Hãy nhập mật khẩu hiện tại");
                }
                else if(newPass == "")
                {
                    ModelState.AddModelError("", "Hãy nhập mật khẩu mới");
                }
                else if(confPass == "")
                {
                    ModelState.AddModelError("", "Hãy nhập xác nhận mật khẩu");
                }
                else if(passWord != "" && newPass != "" && confPass != "")
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
            return View();
        }

        public ActionResult LichSuMuaHang()
        {
            ViewBag.lichSuMuaHang = db.HoaDons.Where(x => x.maKhach == maKhach).ToList();
            return View();
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
            return View(hoaDon);
        }

        //POST: Trả hàng
        [HttpPost]
        public ActionResult TraHang(string lyDo)
        {
            var traHang = new TraHang();
            traHang.hoaDonID = hoadonID;
            traHang.lyDo = lyDo;
            traHang.ngayTra = System.DateTime.Now;

            var hoaDon = new HoaDon();
            hoaDon.hoaDonID = hoadonID;
            hoaDon.maKhach = maKhach;
            hoaDon.loaiHoaDon = "Mua";
            hoaDon.trangThai = false;

            var hdTra = db.ChiTietHoaDons.Where(x => x.hoaDonID == hoadonID).ToList();

            if (ModelState.IsValid)
            {
                if (traHang.lyDo != null)
                {
                    db.TraHangs.Add(traHang);
                    db.Entry(hoaDon).State = EntityState.Modified;
                    db.SaveChanges();
                    foreach (var item in hdTra)
                    {
                        var soLuongChiTiet = db.SanPhams.Find(item.SanPham.sanPhamID);
                        soLuongChiTiet.soLuong = soLuongChiTiet.soLuong + item.soLuong;
                        db.Entry(soLuongChiTiet).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("LichSuTraHang");
                }
                else
                {
                    ModelState.AddModelError("", "Vui lòng cho biết lý do");
                }

            }
            return View();
        }

    }
}
