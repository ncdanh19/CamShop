using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CamShop.Common;
using Models.Dao;
using Models.EF;
using PagedList;

namespace CamShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page,pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        public ActionResult Create(User user)
        {
            var dao = new UserDao();
            if (ModelState.IsValid)
            {                
                if (db.Users.Count(x=> x.userName == user.userName)>0)
                {
                    ModelState.AddModelError("", "Username đã có người dùng"); 
                }
                else if (db.Users.Count(x => x.eMail == user.eMail)>0)
                {
                    ModelState.AddModelError("", "Email đã có người dùng");                     
                }
                else if (db.Users.Count(x => x.soDienThoai == user.soDienThoai)>0)
                {
                    ModelState.AddModelError("", "Số điện thoại đã có người dùng");
                }
                else //thêm nếu không bị trùng
                {                    
                    var encryptedMD5Pas = Encrytor.MD5Hash(user.passWord);
                    user.passWord = encryptedMD5Pas;
                    long id = dao.Insert(user);
                    ModelState.AddModelError("", "Thêm user thành công");

                    return RedirectToAction("Index", "User");
                }
            }
            return View(user);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMD5Pas = Encrytor.MD5Hash(user.passWord);
                user.passWord = encryptedMD5Pas;
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View(user);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new UserDao().Delete(id);
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
