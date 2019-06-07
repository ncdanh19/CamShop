using CamShop.Models;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CamShop.Controllers
{
    public class CartController : Controller
    {
        //Gọi session cart
        private const string CartSession = "CartSession";
        CamShopDbContext db = new CamShopDbContext();
        // GET: Admin/Cart Trang giỏ hàng
        public ActionResult Index()
        {
            // tạo biến lưu session
            var cart = Session[CartSession];
            // tạo list lưu sản phẩm giỏ hàng
            var list = new List<CartItem>();
            // nếu chưa có sản phẩm trong giỏ hàng
            if (cart != null)
                // lưu sản phẩm trong giỏ hàng vào session
                list = (List<CartItem>)cart;
            // trả list cho view

            return View(list);
        }

        //Update số lượng bằng javascript
        public JsonResult Update(string cartModel)
        {
            // tạo biến json cho list sản phẩm trong giỏ hàng theo cấu trúc json
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            // tạo biến sesstion giỏ hàng
            var sessionCart = (List<CartItem>)Session[CartSession];
            // duyệt item sản phẩm trong session giỏ hàng 
            foreach(var item in sessionCart)
            {
                // tạo biến jsonItem với giá trị là item sản phẩm trong giỏ hàng theo ID sản phẩm
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.sanPhamID == item.SanPham.sanPhamID);
                    // nếu jsonItem có giá trị/ có sản phẩm
                    if (jsonItem != null)
                    {
                        //số lượng của jsonItem gán vào số lượng của item
                        item.SoLuong = jsonItem.SoLuong;
                        //thành tiền của jsonitem gán cho thành tiền của item
                        item.ThanhTien = item.SoLuong * item.SanPham.donGia;
                    }
            }
            // lưu session vừa xử lý vào session giỏ hàng
            Session[CartSession] = sessionCart;
            return Json(new { status = true });
        }

        //Xóa sản phẩm
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPham.sanPhamID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        //Thêm sản phẩm
        public ActionResult AddItem(int sanPhamID,short soLuong)
        {
            var sanPham = new SanPhamDao().ViewDetail(sanPhamID);
            var cart = Session[CartSession];
            if(cart!=null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.SanPham.sanPhamID==sanPhamID))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.sanPhamID == sanPhamID)
                        {
                            item.SoLuong += soLuong;
                            item.ThanhTien += soLuong * sanPham.donGia;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart
                    var item = new CartItem();
                    item.SanPham = sanPham;
                    item.SoLuong = soLuong;
                    item.ThanhTien = soLuong*sanPham.donGia;
                    list.Add(item);
                }

                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart
                var item = new CartItem();
                item.SanPham = sanPham;
                item.SoLuong = soLuong;
                item.ThanhTien = soLuong * sanPham.donGia;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }    }
}