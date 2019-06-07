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
    public class HoaDonsController : Controller
    {
        private CamShopDbContext db = new CamShopDbContext();

        public static int hoadonID;

        // GET: Admin/HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.KhachHang).Include(h => h.ThanhToan);
            return View(hoaDons.ToList());
        }

        // GET: Admin/HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.giaoHang = db.GiaoHangs.SingleOrDefault(x => x.hoaDonID == id);
            ViewBag.traHang = db.TraHangs.Where(x => x.hoaDonID == id).ToList();
            HoaDon hoadon = db.HoaDons.Find(id);
            hoadonID = hoadon.hoaDonID;
            var chitietHoaDons = db.ChiTietHoaDons.Where(z => z.hoaDonID == hoadon.hoaDonID &&
                                                         !db.TraHangs.Any(th => th.chitietHDID == z.chitietID)).ToList();
            ViewBag.hoaDonTraHang = db.HoaDons.Find(id);
            double tongtien = 0;
            foreach (var item in chitietHoaDons)
            {
                if (item.SanPham.giaKhuyenMai > 0)
                {

                    tongtien = tongtien + double.Parse((item.giaKhuyenMai * item.soLuong).ToString());
                }
                else
                {
                    tongtien = tongtien + double.Parse((item.donGia * item.soLuong).ToString());
                }
            }
            ViewBag.tongTien = tongtien;
            return View(chitietHoaDons);
        }

        // GET: Admin/HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen");
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID");
            return View();
        }

        // POST: Admin/HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hoaDonID,maKhach,loaiHoaDon,trangThai,tongTien,ngayMuaHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen", hoaDon.maKhach);
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID", hoaDon.hoaDonID);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen", hoaDon.maKhach);
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID", hoaDon.hoaDonID);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hoaDonID,maKhach,loaiHoaDon,trangThai,tongTien,ngayMuaHang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maKhach = new SelectList(db.KhachHangs, "khachHangID", "hoTen", hoaDon.maKhach);
            ViewBag.hoaDonID = new SelectList(db.ThanhToans, "hoaDonID", "hoaDonID", hoaDon.hoaDonID);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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

        [HttpPost]
        public ActionResult DeleteDetails(int id)
        {
            ChiTietHoaDon chiTiet = db.ChiTietHoaDons.Find(id);
            db.ChiTietHoaDons.Remove(chiTiet);
            var sanPham = db.SanPhams.Find(chiTiet.sanPhamID);
            HoaDon hoaDon = db.HoaDons.Find(hoadonID);
            hoadonID = hoaDon.hoaDonID;
            var khuyenMai = db.KhuyenMais.Find(chiTiet.sanPhamID);
            if (khuyenMai != null)
            {
                hoaDon.tongTien -= double.Parse((chiTiet.soLuong * sanPham.giaKhuyenMai).ToString());
            }
            else
            {
                hoaDon.tongTien -= double.Parse((chiTiet.soLuong * sanPham.donGia).ToString());
            }
            sanPham.soLuong += chiTiet.soLuong;
            db.Entry(sanPham).State = EntityState.Modified;
            db.Entry(hoaDon).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { id = hoadonID });
        }
    }
}
