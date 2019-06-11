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
    public class KhuyenMaisController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        // GET: Admin/KhuyenMais
        public ActionResult Index()
        {
            var khuyenMais = db.KhuyenMais.Include(k => k.SanPham);
            return View(khuyenMais.ToList());
        }

        // GET: Admin/KhuyenMais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuyenMai khuyenMai = db.KhuyenMais.Find(id);
            if (khuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Create
        public ActionResult Create()
        {
            var dropdown = db.SanPhams.Where(x => x.giaKhuyenMai < 1 || x.giaKhuyenMai == null).ToList();
            ViewBag.SanPhamID = new SelectList(dropdown, "sanPhamID", "tenSanPham");
            return View();
        }

        // POST: Admin/KhuyenMais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SanPhamID,tyLe,trangThai")] KhuyenMai khuyenMai)
        {
            var sanPham = db.SanPhams.Find(khuyenMai.SanPhamID);
            sanPham.giaKhuyenMai = sanPham.donGia - ((sanPham.donGia * khuyenMai.tyLe) / 100);
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.KhuyenMais.Add(khuyenMai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var dropdown = db.SanPhams.Where(x => x.giaKhuyenMai < 1).ToList();
            ViewBag.SanPhamID = new SelectList(dropdown, "sanPhamID", "tenSanPham", khuyenMai.SanPhamID);
            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuyenMai khuyenMai = db.KhuyenMais.Find(id);
            if (khuyenMai == null)
            {
                return HttpNotFound();
            }
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "sanPhamID", "tenSanPham", khuyenMai.SanPhamID);
            return View(khuyenMai);
        }

        // POST: Admin/KhuyenMais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SanPhamID,tyLe,trangThai")] KhuyenMai khuyenMai)
        {
            if (ModelState.IsValid)
            {
                var sanPham = db.SanPhams.Find(khuyenMai.SanPhamID);
                sanPham.giaKhuyenMai = sanPham.donGia - ((sanPham.donGia * khuyenMai.tyLe) / 100);

                db.Entry(khuyenMai).State = EntityState.Modified;
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SanPhamID = new SelectList(db.SanPhams, "sanPhamID", "tenSanPham", khuyenMai.SanPhamID);
            return View(khuyenMai);
        }

        // GET: Admin/KhuyenMais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuyenMai khuyenMai = db.KhuyenMais.Find(id);
            if (khuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(khuyenMai);
        }

        // POST: Admin/KhuyenMais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sanPham = db.SanPhams.Find(id);
            sanPham.giaKhuyenMai = 0;

            KhuyenMai khuyenMai = db.KhuyenMais.Find(id);
            db.KhuyenMais.Remove(khuyenMai);
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
