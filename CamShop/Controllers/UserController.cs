using CamShop.Common;
using CamShop.Models;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamShop.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangXuat()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult DangNhap(DangNhap model)
        {
            //ModelState.IsValid có giá trị false khi thuộc tính bên trong có giá trị không hợp lệ (null)
            if (ModelState.IsValid)
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
                    //Lấy 2 tham số của user
                    userSession.UserName = user.userName;
                    userSession.UserID = user.ID;
                    //Thêm sesstion của user thỏa 2 tham số truyền vào: username, ID
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //Đổi hướng action về controller Home, Action Index
                    return Redirect("/");
                }
                //Đăng nhập sai
                else if (result == 0)
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                else if (result == -2)
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                else
                    ModelState.AddModelError("", "Thông tin đăng nhập không chính xác");
            }
            return View(model);
        }

        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                ModelState.Clear();
                var dao = new UserDao();
                if(dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    var md5 = Encrytor.MD5Hash(model.Password);
                    user.userName = model.UserName;
                    user.passWord = md5;
                    user.hoTen = model.Name;
                    user.diaChi = model.Address;
                    user.eMail = model.Email;
                    user.soDienThoai = model.Phone;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }
            }
            return View(model);
        }
    }
}