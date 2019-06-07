using CamShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CamShop.Controllers
{
    public class BaseClientController : Controller
    {
        //base controller của tất cả controller
        //Kiểm tra session của người dùng
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Gọi dữ liệu của người dùng ra từ sessiom
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            //Nếu null thì chuyển về login
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "KhachHang", action = "DangNhap"}));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}