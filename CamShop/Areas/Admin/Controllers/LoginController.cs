using CamShop.Areas.Admin.Models;
using CamShop.Common;
using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CamShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {   
            //ModelState.IsValid có giá trị false khi thuộc tính bên trong có giá trị không hợp lệ (null)
            if(ModelState.IsValid)
            {
                //Tạo obj kiểu UserDao
                var dao = new UserDao();
                //Trả về giá trị có trường username và password
                var result = dao.Login(model.UserName, Encrytor.MD5Hash(model.Password));
                //Đăng nhập đúng
                if (result == 1)
                {
                    //Lấy id của user cụ thể
                    var user = dao.GetById(model.UserName);
                    //Tạo biến kiểu userLogin
                    var userSession = new UserLogin();
                    //Lấy tham số của user 
                    userSession.UserName = user.userName; 
                    //Thêm sesstion của user thỏa 2 tham số truyền vào: username, ID
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //Đổi hướng action về controller Home, Action Index
                    return RedirectToAction("Index", "Home");
                }
                //Đăng nhập sai
                else if (result == 0)
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                //else if (result == -2)
                //    ModelState.AddModelError("", "Mật khẩu không đúng");
                else
                    ModelState.AddModelError("", "Thông tin đăng nhập không chính xác");
            }
            return View("Index");
        }

        //Logout
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}