﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CamShop.Common;
using CamShop.Models;
using Models.EF;

namespace CamShop.Areas.Admin.Controllers
{
    public class KhachHangsController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/KhachHangs
        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        // GET: Admin/KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "khachHangID,hoTen,eMail,diaChi,soDienThoai,passWord,confirmPassword,trangThai,userName")] KhachHang khachHang)
        {
            int checkUser = db.KhachHangs.Count(x => x.userName == khachHang.userName);
            int checkPhone = db.KhachHangs.Count(x => x.soDienThoai == khachHang.soDienThoai);
            int checkEmail = db.KhachHangs.Count(x => x.eMail == khachHang.eMail);
            khachHang.passWord = Encrytor.MD5Hash(khachHang.passWord);
            khachHang.confirmPassword = khachHang.passWord;
            if (ModelState.IsValid)
            {
                if (checkUser > 0)
                {
                    TempData[MyAlerts.DANGER] = "Username đã được sử dụng";
                }
                else if (checkPhone > 0)
                {
                    TempData[MyAlerts.DANGER] = "Số điện thoại đã được sử dụng";
                }
                else if (checkEmail > 0)
                {
                    TempData[MyAlerts.DANGER] = "Email đã được sử dụng";
                }
                else
                {
                    db.KhachHangs.Add(khachHang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "khachHangID,hoTen,eMail,diaChi,soDienThoai,passWord,confirmPassword,trangThai,userName")] KhachHang khachHang)
        {
            int checkUser = db.KhachHangs.Count(x => x.userName == khachHang.userName);
            int checkPhone = db.KhachHangs.Count(x => x.soDienThoai == khachHang.soDienThoai);
            int checkEmail = db.KhachHangs.Count(x => x.eMail == khachHang.eMail);
            khachHang.passWord = Encrytor.MD5Hash(khachHang.passWord);
            khachHang.confirmPassword = khachHang.passWord;
            if (ModelState.IsValid)
            {
                if (checkUser > 0)
                {
                    TempData[MyAlerts.DANGER] = "Username đã được sử dụng";
                }
                else if (checkPhone > 0)
                {
                    TempData[MyAlerts.DANGER] = "Số điện thoại đã được sử dụng";
                }
                else if (checkEmail > 0)
                {
                    TempData[MyAlerts.DANGER] = "Email đã được sử dụng";
                }
                else
                {
                    db.Entry(khachHang).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(khachHang);
        }

        // GET: Admin/KhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
