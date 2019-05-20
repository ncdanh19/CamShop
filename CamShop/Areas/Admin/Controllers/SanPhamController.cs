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
    public class SanPhamController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai");
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sanPhamID,loaiHang,thuongHieu,tenSanPham,donGia,moTa,hinhAnh,nhieuHinhAnh,NgayTao,MetaTitle,Hot,soLuong")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai", sanPham.loaiHang);
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu", sanPham.thuongHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai", sanPham.loaiHang);
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu", sanPham.thuongHieu);
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sanPhamID,loaiHang,thuongHieu,tenSanPham,donGia,moTa,hinhAnh,nhieuHinhAnh,NgayTao,MetaTitle,Hot,soLuong")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.loaiHang = new SelectList(db.LoaiHangs, "loaiHangID", "tenLoai", sanPham.loaiHang);
            ViewBag.thuongHieu = new SelectList(db.ThuongHieux, "thuongHieuID", "tenThuongHieu", sanPham.thuongHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
