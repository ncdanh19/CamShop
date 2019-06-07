using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace CamShop.Areas.Admin.Controllers
{
    public class NhomDanhMucsController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/NhomDanhMucs
        public ActionResult Index(string searchString)
        {
            ViewBag.SearchString = searchString;
            return View(db.NhomDanhMucs.ToList());
        }

        // GET: Admin/NhomDanhMucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMucs.Find(id);
            if (nhomDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(nhomDanhMuc);
        }

        // GET: Admin/NhomDanhMucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhomDanhMucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nhomID,tenNhom")] NhomDanhMuc nhomDanhMuc)
        {
            if (ModelState.IsValid)
            {
                db.NhomDanhMucs.Add(nhomDanhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomDanhMuc);
        }

        // GET: Admin/NhomDanhMucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMucs.Find(id);
            if (nhomDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(nhomDanhMuc);
        }

        // POST: Admin/NhomDanhMucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nhomID,tenNhom")] NhomDanhMuc nhomDanhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomDanhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomDanhMuc);
        }

        // GET: Admin/NhomDanhMucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMucs.Find(id);
            if (nhomDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(nhomDanhMuc);
        }

        // POST: Admin/NhomDanhMucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhomDanhMuc nhomDanhMuc = db.NhomDanhMucs.Find(id);
            db.NhomDanhMucs.Remove(nhomDanhMuc);
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
