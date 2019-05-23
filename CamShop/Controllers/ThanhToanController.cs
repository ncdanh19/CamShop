using CamShop.Models;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamShop.Controllers
{
    public class ThanhToanController : BaseClientController
    {
        //Gọi session cart
        private const string CartSession = "CartSession";
        CamShopDbContext db = new CamShopDbContext();
        // GET: ThanhToan
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThanhToan()
        {
            // tạo biến lưu session
            var cart = Session[CartSession];
            // tạo list lưu sản phẩm giỏ hàng
            var list = new List<CartItem>();
            // nếu chưa có sản phẩm trong giỏ hàng
            if (cart != null)
            {
                // lưu sản phẩm trong giỏ hàng vào session
                list = (List<CartItem>)cart;

                double? tongTien = 0;
                foreach (var item in list)
                {
                    tongTien += item.ThanhTien;
                }
                ViewBag.tongTien = tongTien;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult ThanhToan(int id, string donViGH, DateTime ngayGiaoHang)
        {
            //Nếu tài khoản đang đăng nhập
            if (Session[Common.CommonConstants.USER_SESSION] != null)
            {
                //Gán giá trị vào Hóa Đơn
                var hoaDon = new HoaDon();
                hoaDon.maKhach = id;
                hoaDon.loaiHoaDon = "Mua";
                hoaDon.trangThai = true;
                hoaDon.ngayTao = DateTime.Now;



                //Thêm hóa đơn và lấy id của hóa đơn đã thêm
                var hoadonID = new ThanhToanDao().ThemHoaDon(hoaDon);

                //Gán giá trị vào bảng GiaoHang
                var giaoHang = new GiaoHang();
                giaoHang.hoaDonID = hoadonID;
                giaoHang.donViGiaoHang = donViGH.ToString();
                giaoHang.ngayGiaoHang = ngayGiaoHang;

                //Thêm thông tin vào bảng giao hàng
                var giaoHangID = new ThanhToanDao().ThemGiaoHang(giaoHang);

                //Tạo biến tongTien để lưu tổng tiền của hóa đơn
                double? tongTien = 0;

                //Duyệt các phần tử có trong giỏ hàng
                var cart = (List<CartItem>)Session[CartSession];

                foreach (var item in cart)
                {
                    var chitietHD = new ChiTietHoaDon();
                    chitietHD.hoaDonID = hoadonID;
                    chitietHD.sanPhamID = item.SanPham.sanPhamID;
                    chitietHD.soLuong = item.SoLuong;
                    chitietHD.thanhTien = item.ThanhTien;
                    db.ChiTietHoaDons.Add(chitietHD);

                    tongTien += item.ThanhTien;

                    hoaDon.tongTien = tongTien;

                    //Cập nhật tổng tiền cho hóa đơn
                    db.Entry(hoaDon).State = EntityState.Modified;
                    //Cập nhật số lượng sản phẩm
                    var sanPham = db.SanPhams.Find(item.SanPham.sanPhamID);
                    sanPham.soLuong = sanPham.soLuong - item.SoLuong;
                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Redirect("/hoan-thanh/");
        }

        public ActionResult HoanThanh()
        {
            Session[CartSession] = null;
            return View();
        }
    }
}