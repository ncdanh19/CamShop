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
    public class GiaoHangsController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/GiaoHangs
        public ActionResult Index()
        {
            var giaoHangs = db.GiaoHangs.Include(g => g.HoaDon);
            return View(giaoHangs.ToList());
        }

        // GET: Admin/GiaoHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoHang giaoHang = db.GiaoHangs.Find(id);
            if (giaoHang == null)
            {
                return HttpNotFound();
            }
            return View(giaoHang);
        }

        // GET: Admin/GiaoHangs/Create
        public ActionResult Create()
        {
            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon");
            return View();
        }

        // POST: Admin/GiaoHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "giaoHangID,hoaDonID,donViGiaoHang,ngayGiaoHang")] GiaoHang giaoHang)
        {

            if (ModelState.IsValid)
            {
                if (db.GiaoHangs.Where(x => x.hoaDonID == giaoHang.hoaDonID).Count() == 0)
                {
                    //AlertMess("Thêm đơn vị giao hàng thành công", "success");
                    db.GiaoHangs.Add(giaoHang);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Hóa đơn đã được giao");
                }

            }

            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon", giaoHang.hoaDonID);
            return View(giaoHang);
        }

        // GET: Admin/GiaoHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoHang giaoHang = db.GiaoHangs.Find(id);
            if (giaoHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon", giaoHang.hoaDonID);
            return View(giaoHang);
        }

        // POST: Admin/GiaoHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "giaoHangID,hoaDonID,donViGiaoHang,ngayGiaoHang")] GiaoHang giaoHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaoHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hoaDonID = new SelectList(db.HoaDons, "hoaDonID", "loaiHoaDon", giaoHang.hoaDonID);
            return View(giaoHang);
        }

        // GET: Admin/GiaoHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoHang giaoHang = db.GiaoHangs.Find(id);
            if (giaoHang == null)
            {
                return HttpNotFound();
            }
            return View(giaoHang);
        }

        // POST: Admin/GiaoHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaoHang giaoHang = db.GiaoHangs.Find(id);
            db.GiaoHangs.Remove(giaoHang);
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
