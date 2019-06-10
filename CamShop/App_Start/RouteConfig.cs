using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CamShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Tat ca san pham",
               url: "san-pham/",
               defaults: new { controller = "SanPham", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
               name: "List Thuong Hieu",
               url: "san-pham/thuong-hieu/{MetaTitle}-{thuongHieuID}",
               defaults: new { controller = "SanPham", action = "LocSanPhamTheoThuongHieu", id = UrlParameter.Optional },
               namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
               name: "Danh muc san pham",
               url: "san-pham/{MetaTitle}-{loaiHangID}",
               defaults: new { controller = "SanPham", action = "Category", id = UrlParameter.Optional },
               namespaces: new[] { "CamShop.Controllers" }
           );

            routes.MapRoute(
                name: "LocSanPham",
                url: "san-pham/loc",
                defaults: new { controller = "SanPham", action = "LocSanPham", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
               name: "Chi tiet san pham",
               url: "chi-tiet/{MetaTitle}/{id}",
               defaults: new { controller = "SanPham", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
               name: "gio hang",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "CamShop.Controllers" }
           );

            routes.MapRoute(
               name: "cap nhat gio hang",
               url: "cart-update",
               defaults: new { controller = "Cart", action = "Update", id = UrlParameter.Optional },
               namespaces: new[] { "CamShop.Controllers" }
           );

            routes.MapRoute(
                name: "them gio hang",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
             );

            routes.MapRoute(
                name: "Thanh toan",
                url: "thanh-toan",
                defaults: new { controller = "ThanhToan", action = "ThanhToanKhach", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
             );
             
            routes.MapRoute(
                name: "Hoan thanh",
                url: "hoan-thanh",
                defaults: new { controller = "ThanhToan", action = "HoanThanh", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
             );

            routes.MapRoute(
              name: "dang ky",
              url: "dang-ky",
              defaults: new { controller = "KhachHang", action = "Register", id = UrlParameter.Optional },
              namespaces: new[] { "CamShop.Controllers" }
           );

            routes.MapRoute(
              name: "dang nhap",
              url: "dang-nhap",
              defaults: new { controller = "KhachHang", action = "Login", id = UrlParameter.Optional },
              namespaces: new[] { "CamShop.Controllers" }
           );
             

            routes.MapRoute(
              name: "quanlytaikhoan",
              url: "tai-khoan-{id}",
              defaults: new { controller = "QuanLyKH", action = "Edit", id = UrlParameter.Optional },
              namespaces: new[] { "CamShop.Controllers" }
           ); 

            routes.MapRoute(
                name: "LichSuMuaHang",
                url: "lich-su-mua-hang",
                defaults: new { controller = "QuanLyKH", action = "LichSuMuaHang", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
                name: "LichSuTraHang",
                url: "lich-su-tra-hang",
                defaults: new { controller = "QuanLyKH", action = "LichSuTraHang", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
                name: "TraHangGet",
                url: "tra-hang-get-{id}",
                defaults: new { controller = "QuanLyKH", action = "TraHangGet", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
                name: "TraHang",
                url: "tra-hang",
                defaults: new { controller = "QuanLyKH", action = "TraHang", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
               name: "xemCTHoaDon",
               url: "chi-tiet-{id}",
               defaults: new { controller = "QuanLyKH", action = "XemChiTietHoaDon", id = UrlParameter.Optional },
               namespaces: new[] { "CamShop.Controllers" }
           );

            routes.MapRoute(
                name: "DoiMatKhau",
                url: "doi-mat-khau",
                defaults: new { controller = "QuanLyKH", action = "DoiMatKhau", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CamShop.Controllers" }
            );

        }
    }
}
