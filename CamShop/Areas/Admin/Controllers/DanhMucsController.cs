using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;

namespace CamShop.Areas.Admin.Controllers
{
    public class DanhMucsController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/DanhMucs
        public ActionResult Index()
        {
            var danhMucs = db.DanhMucs.Include(d => d.NhomDanhMuc);
            return View(danhMucs.ToList());
        }


        // GET: Admin/DanhMucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }   
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Create
        public ActionResult Create()
        {
            ViewBag.groupID = new SelectList(db.NhomDanhMucs, "nhomID", "tenNhom");
            return View();
        }

        // POST: Admin/DanhMucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "danhMucID,tenDanhMuc,URL,groupID,Target,trangThai,image")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                if (db.DanhMucs.Where(x => x.tenDanhMuc == danhMuc.tenDanhMuc).Count() == 0)
                {
                    db.DanhMucs.Add(danhMuc);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Danh mục đã tồn tại");
                }
            }

            ViewBag.groupID = new SelectList(db.NhomDanhMucs, "nhomID", "tenNhom", danhMuc.groupID);
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.groupID = new SelectList(db.NhomDanhMucs, "nhomID", "tenNhom", danhMuc.groupID);
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "danhMucID,tenDanhMuc,URL,groupID,Target,trangThai,image")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.groupID = new SelectList(db.NhomDanhMucs, "nhomID", "tenNhom", danhMuc.groupID);
            return View(danhMuc);
        }

        // GET: Admin/DanhMucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: Admin/DanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhMuc);
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
