using CamShop.Models;
using CamShop.PayPal;
using PayPal.Api;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamShop.Data_Access;

namespace CamShop.Controllers
{
    public class ThanhToanController :  Controller
    {
        //Gọi session cart
        private const string CartSession = "CartSession";
        private static int _hoaDon;

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
        [HttpGet]
        public ActionResult ThanhToanKhach()
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
        //[HttpPost]
        //public ActionResult ThanhToan(int id, string donViGH, DateTime ngayGiaoHang)
        //{
        //    //Nếu tài khoản đang đăng nhập
        //    if (Session[Common.CommonConstants.USER_SESSION] != null)
        //    {
        //        //Gán giá trị vào Hóa Đơn
        //        var hoaDon = new HoaDon();
        //        hoaDon.maKhach = id;
        //        hoaDon.loaiHoaDon = "Mua";
        //        hoaDon.trangThai = true;
        //        hoaDon.ngayMuaHang = DateTime.Now;



        //        //Thêm hóa đơn và lấy id của hóa đơn đã thêm
        //        var hoadonID = new ThanhToanDao().ThemHoaDon(hoaDon);

        //        //Gán giá trị vào bảng GiaoHang
        //        var giaoHang = new GiaoHang();
        //        giaoHang.hoaDonID = hoadonID;
        //        giaoHang.donViGiaoHang = donViGH.ToString();
        //        giaoHang.ngayGiaoHang =ngayGiaoHang;

        //        //Thêm thông tin vào bảng giao hàng
        //        var giaoHangID = new ThanhToanDao().ThemGiaoHang(giaoHang);

        //        //Tạo biến tongTien để lưu tổng tiền của hóa đơn
        //        double? tongTien = 0;

        //        //Duyệt các phần tử có trong giỏ hàng
        //        var cart = (List<CartItem>)Session[CartSession];

        //        foreach (var item in cart)
        //        {
        //            var chitietHD = new ChiTietHoaDon();
        //            chitietHD.hoaDonID = hoadonID;
        //            chitietHD.sanPhamID = item.SanPham.sanPhamID;
        //            chitietHD.soLuong = item.SoLuong;
        //            chitietHD.donGia = item.SanPham.donGia;
        //            chitietHD.giaKhuyenMai = item.SanPham.giaKhuyenMai;
        //            chitietHD.thanhTien = item.ThanhTien;
        //            db.ChiTietHoaDons.Add(chitietHD);

        //            tongTien += item.ThanhTien;

        //            hoaDon.tongTien = tongTien;

        //            //Cập nhật tổng tiền cho hóa đơn
        //            db.Entry(hoaDon).State = EntityState.Modified;
        //            //Cập nhật số lượng sản phẩm
        //            var sanPham = db.SanPhams.Find(item.SanPham.sanPhamID);
        //            sanPham.soLuong = sanPham.soLuong - item.SoLuong;
        //            db.Entry(sanPham).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //    }
        //    return Redirect("/hoan-thanh/");
        //}

        public ActionResult HoanThanh()
        {
            Session[CartSession] = null;
            return View();
        }
        //Paypal Payment
        private Payment payment;

        //Create a payment using an APIContext
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList()
            {
                items = new List<Item>()
            };
            List<CartItem> listCarts = (List<CartItem>)Session[CartSession];
            foreach (var cart in listCarts)
            {
                if (cart.SanPham.giaKhuyenMai > 0)
                {
                    listItems.items.Add(new Item()
                    {
                        name = cart.SanPham.tenSanPham,
                        currency = "USD",
                        price = cart.SanPham.giaKhuyenMai.ToString(),
                        quantity = cart.SoLuong.ToString(),
                        sku = "sku"
                    });
                }
                else
                {
                    listItems.items.Add(new Item()
                    {
                        name = cart.SanPham.tenSanPham,
                        currency = "USD",
                        price = cart.SanPham.donGia.ToString(),
                        quantity = cart.SoLuong.ToString(),
                        sku = "sku"
                    });
                }

            }

            var payer = new Payer() { payment_method = "paypal" };

            //Do the configuration RedirectURLs with redirectURLs object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };

            //Get amount order for shipping
            double tongTien = 0;
            foreach (var item in listCarts)
            {
                if (item.SanPham.giaKhuyenMai > 0)
                {
                    tongTien += double.Parse((item.SanPham.giaKhuyenMai * item.SoLuong).ToString());
                }
                else
                {
                    tongTien += double.Parse((item.SanPham.donGia * item.SoLuong).ToString());
                }
            }

            //When Amount > 200.000 shipFee = 0
            double shipFee = 0;
            if (tongTien > 200)
            {
                shipFee = 0;
            }
            else
            {
                shipFee = 30;
            }

            //Create details object
            var details = new Details()
            {
                tax = "1",
                shipping = shipFee.ToString(),
                subtotal = tongTien.ToString()
            };

            //Create amount object
            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + (Convert.ToDouble(details.shipping)) + Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };

            //Create transaction
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "Bang Testing transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        //Create Execute Payment method
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);
        }


        private static string _hoTen;
        private static string _diaChi;
        private static string _eMail;
        private static string _soDienThoai;
        private static string _donViGH;
        private static string _duong;
        private static string _phuong;
        private static string _quan;
        private static string _thanhPho;

        //Create PaymentWithPaypal method
        public ActionResult PaymentWithPaypal(string hoTen, string diaChi, string eMail, string soDienThoai, string donViGH, string duong, string phuong, string quan, string thanhPho)
        {
            //try
            //{
                if ((KhachHangLogin)Session[Common.CommonConstants.KHACHHANG_SESSION] == null)
                {
                    if (db.KhachHangs.Count(x => x.soDienThoai == soDienThoai && x.trangThai == true) > 0)
                    {
                        //AlertMess("Vui lòng đăng nhập số điện thoại này để tiếp tục", "error");
                        return Redirect(Request.UrlReferrer.ToString());
                    }
                    else
                    {
                        // Gettings context from the paypal bases on clientId and secretID for payment
                        APIContext apiContext = PaypalConfiguration.getAPIContext();
                        string payerId = Request.Params["PayerID"];
                        if (string.IsNullOrEmpty(payerId))
                        {
                            //Creating a payment
                            string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThanhToan/PaymentWithPaypal?";
                            var guid = Convert.ToString((new Random()).Next(100000));
                            var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);

                            //Get links returned from paypal response to create call function
                            var links = createdPayment.links.GetEnumerator();
                            string paypalRedirectUrl = string.Empty;

                            while (links.MoveNext())
                            {
                                Links link = links.Current;
                                if (link.rel.ToLower().Trim().Equals("approval_url"))
                                {
                                    paypalRedirectUrl = link.href;
                                }
                            }
                            Session.Add(guid, createdPayment.id);

                            //Get user information
                            _hoTen = hoTen;
                            _diaChi = diaChi;
                            _eMail = eMail;
                            _soDienThoai = soDienThoai;
                            _donViGH = donViGH.ToString();
                            _duong = duong;
                            _phuong = phuong.ToString();
                            _quan = quan.ToString();
                            _thanhPho = thanhPho.ToString();

                            return Redirect(paypalRedirectUrl);
                        }
                        else
                        {
                            //This one be will be executed when we have received all the payment params from previous call
                            var guid = Request.Params["guid"];
                            var executePayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                            if (executePayment.state.ToLower() != "approved")
                            {
                                return View("Failure");
                            }

                            var session = (KhachHangLogin)Session[Common.CommonConstants.KHACHHANG_SESSION];

                            if (session != null)
                            {
                                //Create Order for User
                                var hoaDon = new HoaDon();
                                hoaDon.maKhach = ((KhachHangLogin)Session[Common.CommonConstants.KHACHHANG_SESSION]).KhachHangID;
                                hoaDon.loaiHoaDon = "Mua";
                                hoaDon.trangThai = true;
                                hoaDon.ngayMuaHang = DateTime.Now;

                                var hoadonId = new DataAccess().ThemHoaDon(hoaDon);
                                _hoaDon = hoadonId;


                                //Create Delivery for Order
                                var giaoHang = new GiaoHang();
                                giaoHang.donViGiaoHang = _donViGH;
                                giaoHang.ngayGiaoHang = DateTime.Now.AddDays(3);
                                giaoHang.hoaDonID = hoadonId;

                                var giaoHangId = new DataAccess().ThemGiaoHang(giaoHang);


                                //Get Amount of Order
                                double tongTien = 0;

                                //Get all item in cart
                                var gioHang = (List<CartItem>)Session[CartSession];

                                foreach (var item in gioHang)
                                {
                                    var chiTiet = new ChiTietHoaDon();
                                    chiTiet.hoaDonID = hoadonId;
                                    chiTiet.sanPhamID = item.SanPham.sanPhamID;
                                    chiTiet.soLuong = item.SoLuong;
                                    chiTiet.donGia = item.SanPham.donGia;
                                    chiTiet.giaKhuyenMai = item.SanPham.giaKhuyenMai;

                                    //Insert chiTiet into database
                                    db.ChiTietHoaDons.Add(chiTiet);

                                    if (item.SanPham.giaKhuyenMai > 0)
                                    {
                                        tongTien += double.Parse((item.SoLuong * item.SanPham.giaKhuyenMai).ToString());
                                    }
                                    else
                                    {
                                        tongTien += double.Parse((item.SoLuong * item.SanPham.donGia).ToString());
                                    }

                                    //If tongTien > 200: Ship = 0
                                    if (tongTien < 200)
                                    {
                                        tongTien += 30;
                                    }

                                    //Update hoaDon 
                                    hoaDon.tongTien = tongTien;
                                    db.Entry(hoaDon).State = EntityState.Modified;

                                    //Update quantity of SanPham 
                                    var sanPham = db.SanPhams.Find(item.SanPham.sanPhamID);
                                    sanPham.soLuong -= item.SoLuong;
                                    db.Entry(sanPham).State = EntityState.Modified;

                                    //Thêm vào bảng ThanhToan
                                    var thanhToan = new ThanhToan();
                                    thanhToan.hoaDonID = _hoaDon;
                                    thanhToan.ngayThanhToan = DateTime.Now;
                                    db.ThanhToans.Add(thanhToan);

                                    db.SaveChanges();
                                }
                            }
                            else
                            {
                                var khachHang = new KhachHang();
                                int khID = 0;
                                var findKH = db.KhachHangs.SingleOrDefault(x => x.soDienThoai == _soDienThoai);
                                if (db.KhachHangs.Where(x => x.soDienThoai == _soDienThoai && x.trangThai == null).Count() > 0)
                                {
                                    khID = findKH.khachHangID;
                                }
                                else
                                {
                                    khachHang.hoTen = _hoTen;
                                    khachHang.eMail = _eMail;
                                    khachHang.diaChi = _diaChi + "," + _duong + "," + _phuong + "," + _quan + "," + _thanhPho;
                                    khachHang.soDienThoai = _soDienThoai;
                                    khachHang.passWord = Common.Encrytor.MD5Hash("123456");
                                    khachHang.confirmPassword = Common.Encrytor.MD5Hash("123456");
                                    var khachHangID = new DataAccess().ThemKhachHang(khachHang);
                                    khID = khachHangID;
                                }

                                //Gán giá trị vào Hóa Đơn
                                var hoaDon = new HoaDon();
                                hoaDon.maKhach = khID;
                                hoaDon.loaiHoaDon = "Mua";
                                hoaDon.trangThai = true;
                                hoaDon.ngayMuaHang = DateTime.Now;

                                //Thêm hóa đơn và lấy id của hóa đơn đã thêm
                                var hoadonID = new DataAccess().ThemHoaDon(hoaDon);
                                _hoaDon = hoadonID;

                                //Gán giá trị vào bảng GiaoHang
                                var giaoHang = new GiaoHang();
                                giaoHang.hoaDonID = hoadonID;
                                giaoHang.donViGiaoHang = _donViGH;
                                giaoHang.ngayGiaoHang = System.DateTime.Now.AddDays(3);


                                //Thêm thông tin vào bảng giao hàng
                                var giaoHangID = new DataAccess().ThemGiaoHang(giaoHang);

                                //Tạo biến tongTien để lưu tổng tiền của hóa đơn
                                double tongTien = 0;

                                //Duyệt các phần tử có trong giỏ hàng
                                var gioHang = (List<CartItem>)Session[CartSession];
                                foreach (var item in gioHang)
                                {
                                    //Thêm các sản phẩm trong giỏ hàng vào chi tiết
                                    var chitietHD = new ChiTietHoaDon();
                                    chitietHD.sanPhamID = item.SanPham.sanPhamID;
                                    chitietHD.hoaDonID = hoadonID;
                                    chitietHD.soLuong = item.SoLuong;
                                    chitietHD.donGia = item.SanPham.donGia;
                                    chitietHD.giaKhuyenMai = item.SanPham.giaKhuyenMai;
                                    db.ChiTietHoaDons.Add(chitietHD);
                                    if (item.SanPham.giaKhuyenMai > 0)
                                    {
                                        tongTien += double.Parse((item.SanPham.giaKhuyenMai * item.SoLuong).ToString());
                                    }
                                    else
                                    {
                                        tongTien += double.Parse((item.SanPham.donGia * item.SoLuong).ToString());
                                    }

                                    //Kiểm tra tổng tiền: Nếu trên 200.000 sẽ không tính phí vận chuyển
                                    if (tongTien < 200000)
                                    {
                                        tongTien += 30000;
                                    }
                                    hoaDon.tongTien = tongTien;
                                    //Cập nhật tổng tiền cho hóa đơn
                                    db.Entry(hoaDon).State = EntityState.Modified;

                                    //Cập nhật số lượng sản phẩm
                                    var sanPham = db.SanPhams.Find(item.SanPham.sanPhamID);
                                    sanPham.soLuong = sanPham.soLuong - item.SoLuong;
                                    db.Entry(sanPham).State = EntityState.Modified;

                                    //Thêm vào bảng ThanhToan
                                    var thanhToan = new ThanhToan();
                                    thanhToan.hoaDonID = hoadonID;
                                    thanhToan.ngayThanhToan = DateTime.Now;
                                    db.ThanhToans.Add(thanhToan);

                                    db.SaveChanges();
                                }
                            }
                        }
                        Session[CartSession] = null;
                        return Redirect("/hoan-thanh");
                    }
                }
                else
                {
                    // Gettings context from the paypal bases on clientId and secretID for payment
                    APIContext apiContext = PaypalConfiguration.getAPIContext();
                    string payerId = Request.Params["PayerID"];
                    if (string.IsNullOrEmpty(payerId))
                    {
                        //Creating a payment
                        string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ThanhToan/PaymentWithPaypal?";
                        var guid = Convert.ToString((new Random()).Next(100000));
                        var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);

                        //Get links returned from paypal response to create call function
                        var links = createdPayment.links.GetEnumerator();
                        string paypalRedirectUrl = string.Empty;

                        while (links.MoveNext())
                        {
                            Links link = links.Current;
                            if (link.rel.ToLower().Trim().Equals("approval_url"))
                            {
                                paypalRedirectUrl = link.href;
                            }
                        }
                        Session.Add(guid, createdPayment.id);

                        //Get user information
                        _hoTen = hoTen;
                        _diaChi = diaChi;
                        _eMail = eMail;
                        _soDienThoai = soDienThoai;
                        _donViGH = donViGH.ToString();


                        return Redirect(paypalRedirectUrl);
                    }
                    else
                    {
                        //This one be will be executed when we have received all the payment params from previous call
                        var guid = Request.Params["guid"];
                        var executePayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                        if (executePayment.state.ToLower() != "approved")
                        {
                            return View("Failure");
                        }

                        var session = (KhachHangLogin)Session[Common.CommonConstants.KHACHHANG_SESSION];

                        if (session != null)
                        {
                            //Create Order for User
                            var hoaDon = new HoaDon();
                            hoaDon.maKhach = ((KhachHangLogin)Session[Common.CommonConstants.KHACHHANG_SESSION]).KhachHangID;
                            hoaDon.loaiHoaDon = "Mua";
                            hoaDon.trangThai = true;
                            hoaDon.ngayMuaHang = DateTime.Now;

                            var hoadonId = new DataAccess().ThemHoaDon(hoaDon);
                            _hoaDon = hoadonId;


                            //Create Delivery for Order
                            var giaoHang = new GiaoHang();
                            giaoHang.donViGiaoHang = _donViGH;
                            giaoHang.ngayGiaoHang = DateTime.Now.AddDays(3);
                            giaoHang.hoaDonID = hoadonId;

                            var giaoHangId = new DataAccess().ThemGiaoHang(giaoHang);


                            //Get Amount of Order
                            double tongTien = 0;

                            //Get all item in cart
                            var gioHang = (List<CartItem>)Session[CartSession];

                            foreach (var item in gioHang)
                            {
                                var chiTiet = new ChiTietHoaDon();
                                chiTiet.hoaDonID = hoadonId;
                                chiTiet.sanPhamID = item.SanPham.sanPhamID;
                                chiTiet.soLuong = item.SoLuong;
                                chiTiet.donGia = item.SanPham.donGia;
                                chiTiet.giaKhuyenMai = item.SanPham.giaKhuyenMai;

                                //Insert chiTiet into database
                                db.ChiTietHoaDons.Add(chiTiet);

                                if (item.SanPham.giaKhuyenMai > 0)
                                {
                                    tongTien += double.Parse((item.SoLuong * item.SanPham.giaKhuyenMai).ToString());
                                }
                                else
                                {
                                    tongTien += double.Parse((item.SoLuong * item.SanPham.donGia).ToString());
                                }

                                //If tongTien > 200: Ship = 0
                                if (tongTien < 200)
                                {
                                    tongTien += 30;
                                }

                                //Update hoaDon 
                                hoaDon.tongTien = tongTien;
                                db.Entry(hoaDon).State = EntityState.Modified;

                                //Update quantity of SanPham 
                                var sanPham = db.SanPhams.Find(item.SanPham.sanPhamID);
                                sanPham.soLuong -= item.SoLuong;
                                db.Entry(sanPham).State = EntityState.Modified;

                                //Thêm vào bảng ThanhToan
                                var thanhToan = new ThanhToan();
                                thanhToan.hoaDonID = _hoaDon;
                                thanhToan.ngayThanhToan = DateTime.Now;
                                db.ThanhToans.Add(thanhToan);

                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            var khachHang = new KhachHang();
                            khachHang.hoTen = _hoTen;
                            khachHang.eMail = _eMail;
                            khachHang.diaChi = _diaChi + "," + _duong + "," + _phuong + "," + _quan + "," + _thanhPho;
                            khachHang.soDienThoai = _soDienThoai;
                            khachHang.passWord = Common.Encrytor.MD5Hash("123456");
                            khachHang.confirmPassword = Common.Encrytor.MD5Hash("123456");

                            var khachHangID = new DataAccess().ThemKhachHang(khachHang);

                            //Gán giá trị vào Hóa Đơn
                            var hoaDon = new HoaDon();
                            hoaDon.maKhach = khachHangID;
                            hoaDon.loaiHoaDon = "Mua";
                            hoaDon.trangThai = true;
                            hoaDon.ngayMuaHang = DateTime.Now;

                            //Thêm hóa đơn và lấy id của hóa đơn đã thêm
                            var hoadonID = new DataAccess().ThemHoaDon(hoaDon);
                            _hoaDon = hoadonID;

                            //Gán giá trị vào bảng GiaoHang
                            var giaoHang = new GiaoHang();
                            giaoHang.hoaDonID = hoadonID;
                            giaoHang.donViGiaoHang = _donViGH;
                            giaoHang.ngayGiaoHang = System.DateTime.Now.AddDays(3);


                            //Thêm thông tin vào bảng giao hàng
                            var giaoHangID = new DataAccess().ThemGiaoHang(giaoHang);

                            //Tạo biến tongTien để lưu tổng tiền của hóa đơn
                            double tongTien = 0;

                            //Duyệt các phần tử có trong giỏ hàng
                            var gioHang = (List<CartItem>)Session[CartSession];
                            foreach (var item in gioHang)
                            {
                                //Thêm các sản phẩm trong giỏ hàng vào chi tiết
                                var chitietHD = new ChiTietHoaDon();
                                chitietHD.sanPhamID = item.SanPham.sanPhamID;
                                chitietHD.hoaDonID = hoadonID;
                                chitietHD.soLuong = item.SoLuong;
                                chitietHD.donGia = item.SanPham.donGia;
                                chitietHD.giaKhuyenMai = item.SanPham.giaKhuyenMai;
                                db.ChiTietHoaDons.Add(chitietHD);
                                if (item.SanPham.giaKhuyenMai > 0)
                                {
                                    tongTien += double.Parse((item.SanPham.giaKhuyenMai * item.SoLuong).ToString());
                                }
                                else
                                {
                                    tongTien += double.Parse((item.SanPham.donGia * item.SoLuong).ToString());
                                }

                                //Kiểm tra tổng tiền: Nếu trên 200.000 sẽ không tính phí vận chuyển
                                if (tongTien < 200000)
                                {
                                    tongTien += 30000;
                                }
                                hoaDon.tongTien = tongTien;
                                //Cập nhật tổng tiền cho hóa đơn
                                db.Entry(hoaDon).State = EntityState.Modified;

                                //Cập nhật số lượng sản phẩm
                                var sanPham = db.SanPhams.Find(item.SanPham.sanPhamID);
                                sanPham.soLuong = sanPham.soLuong - item.SoLuong;
                                db.Entry(sanPham).State = EntityState.Modified;

                                //Thêm vào bảng ThanhToan
                                var thanhToan = new ThanhToan();
                                thanhToan.hoaDonID = hoadonID;
                                thanhToan.ngayThanhToan = DateTime.Now;
                                db.ThanhToans.Add(thanhToan);

                                db.SaveChanges();
                            }
                        }
                    }
                }
                Session[CartSession] = null;
                return Redirect("/hoan-thanh");
            //}
            //catch (Exception ex)
            //{
            //    PaypalLogger.Log("Error: " + ex.Message);
            //    return View("Failure");
            }

        }
}

