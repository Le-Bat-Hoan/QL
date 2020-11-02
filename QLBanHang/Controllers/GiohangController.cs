using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;

namespace QLBanHang.Controllers
{
    public class GiohangController : Controller
    {
        private QLBanhangEF db = new QLBanhangEF();
        // GET: Giohang
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }
        //khai báo phương thức thêm sản phẩm vào giỏ hàng
        public RedirectToRouteResult AddToCart(string MaSP)
        {
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<CartItem>();
            }
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            //kiểm tra phần khách đang chọn có trong giỏ hàng chưa
            if (giohang.FirstOrDefault(m => m.MaSP == MaSP) == null)//chưa có trong giỏ hàng
            {
                SanPham sp = db.Sanphams.Find(MaSP);
                CartItem newItem = new CartItem();
                newItem.MaSP = MaSP;
                newItem.TenSP = sp.TenSP;
                newItem.SoLuong = 1;
                newItem.DonGia = Convert.ToDouble(sp.Dongia);
                giohang.Add(newItem);
            }
            else//sản phẩm đã có trong giỏ hàng ==> tăng số lượng lên 1
            {
                CartItem cartIteam = giohang.FirstOrDefault(m => m.MaSP == MaSP);
                cartIteam.SoLuong++;
            }
            Session["giohang"] = giohang;
            return RedirectToAction("Index");
        }
    }
}