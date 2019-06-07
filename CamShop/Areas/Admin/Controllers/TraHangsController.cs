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
    public class TraHangsController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/TraHangs
        public ActionResult Index()
        {
            var traHangs = db.TraHangs.Include(t => t.HoaDon);
            return View(traHangs.ToList());
        }

        // GET: Admin/TraHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraHang traHang = db.TraHangs.Find(id);
            if (traHang == null)
            {
                return HttpNotFound();
            }
            return View(traHang);
        }

        // GET: Admin/TraHangs/Create
        public ActionResult Create()
        {
            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon");
            return View();
        }

        // POST: Admin/TraHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "phieuTraHangID,hoaDonID,ngayTra,lyDo")] TraHang traHang)
        {
            if (ModelState.IsValid)
            {
                db.TraHangs.Add(traHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon", traHang.hoaDonID);
            return View(traHang);
        }

        // GET: Admin/TraHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraHang traHang = db.TraHangs.Find(id);
            if (traHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon", traHang.hoaDonID);
            return View(traHang);
        }

        // POST: Admin/TraHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "phieuTraHangID,hoaDonID,ngayTra,lyDo")] TraHang traHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon", traHang.hoaDonID);
            return View(traHang);
        }

        // GET: Admin/TraHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraHang traHang = db.TraHangs.Find(id);
            if (traHang == null)
            {
                return HttpNotFound();
            }
            return View(traHang);
        }

        // POST: Admin/TraHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraHang traHang = db.TraHangs.Find(id);
            db.TraHangs.Remove(traHang);
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
