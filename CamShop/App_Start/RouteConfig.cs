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
               name: "Danh muc san pham",
               url: "{URL}/{danhMucID}",
               defaults: new { controller = "SanPham", action = "Category", id = UrlParameter.Optional },
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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"CamShop.Controllers"}
            );


        }
    }
}
