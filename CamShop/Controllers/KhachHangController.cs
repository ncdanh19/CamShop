using CamShop.Common;
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
    public class KhachHangController : Controller
    {
        CamShopDbContext db = new CamShopDbContext();

        public ActionResult Login()
        {
            return View();
        }

        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
             KhachHang kh = db.KhachHangs.SingleOrDefault(x => x.soDienThoai == model.Phone && x.trangThai == null);
            if (ModelState.IsValid)
            {
                if (kh != null)
                {
                    kh.userName = model.UserName;
                    kh.hoTen = model.Name;
                    kh.eMail = model.Email;
                    kh.diaChi = model.Address;
                    kh.passWord = Encrytor.MD5Hash(model.Password);
                    kh.confirmPassword = Encrytor.MD5Hash(model.ConfirmPassword);
                    kh.trangThai = true;
                    db.Entry(kh).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Login", "KhachHang");
                }
                else
                {
                    //Kiem tra so dien thoai 
                    if (db.KhachHangs.Count(x => x.userName == model.UserName) > 0)
                    {
                        ModelState.AddModelError("", "Tên đăng nhập đã có người sử dụng");
                    }
                    //Kiem tra so dien thoai 
                    else if (db.KhachHangs.Count(x => x.soDienThoai == model.Phone) > 0)
                    {
                        ModelState.AddModelError("", "Số điện thoại đã có người sử dụng");
                    }
                    else if (db.KhachHangs.Count(x => x.eMail == model.Email) > 0)
                    {
                        ModelState.AddModelError("", "Email đã có người sử dụng");
                    }
                    else
                    {
                        var user = new KhachHang();
                        user.userName = model.UserName;
                        user.hoTen = model.Name;
                        user.eMail = model.Email;
                        user.diaChi = model.Address;
                        user.soDienThoai = model.Phone;
                        user.passWord = Encrytor.MD5Hash(model.Password);
                        user.confirmPassword = Encrytor.MD5Hash(model.ConfirmPassword);
                        user.trangThai = true;
                        db.KhachHangs.Add(user);
                        db.SaveChanges();                                                
                        return RedirectToAction("Login", "KhachHang");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(DangNhap model)
        {
            //ModelState.IsValid có giá trị false khi thuộc tính bên trong có giá trị không hợp lệ (null)
            if (ModelState.IsValid)
            {
                //Tạo obj kiểu UserDao
                var dao = new KhachHangDao();
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
                    userSession.UserID = user.khachHangID;
                    userSession.UserName = user.userName;
                    userSession.Name = user.hoTen;
                    userSession.Address = user.diaChi;
                    userSession.Email = user.eMail;
                    userSession.Phone = user.soDienThoai;
                    //Thêm sesstion của user thỏa 2 tham số truyền vào: username, ID
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //Đổi hướng action về controller Home, Action Index
                    return RedirectToAction("Index", "Home");
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

        public ActionResult DangXuat()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}