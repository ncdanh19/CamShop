using CamShop.Models;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CamShop.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Admin/Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
                list = (List<CartItem>)cart;
            return View(list);
        }
        //Update số lượng
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.sanPhamID == item.SanPham.sanPhamID);
                    if (jsonItem!=null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new { status = true });
        }

        //Xóa sản phẩm
        public JsonResult Delete()
        {
            Session[CartSession] = null;
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
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart
                    var item = new CartItem();
                    item.SanPham = sanPham;
                    item.SoLuong = soLuong;
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
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}