using ClothesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesStore.Controllers
{
    public class CartController : Controller
    {
        ClothesStoreEntities db = new ClothesStoreEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddToCart(int id)
        {
            List<CartItem> giohang = null;
            if (Session["giohang"] == null)//giỏ hàng trống
            {
                giohang = new List<CartItem>();
                giohang.Add(new CartItem() { ProductOrder = db.PRODUCT.Find(id), Quantity = 1 });
            }
            else//đã có sách trong giỏ hàng
            {
                giohang = (List<CartItem>) Session["giohang"];
                CartItem s = giohang.SingleOrDefault(x => x.ProductOrder.idPro == id);
                if (s != null)//đã có cuốn sách đó trong giỏ hàng
                {
                    s.Quantity++;//tăng số lượng lên 1
                }
                else//chưa có
                {
                    giohang.Add(new CartItem() { ProductOrder = db.PRODUCT.Find(id), Quantity = 1 });
                }
            }
            //cập nhật biến Session["giohang"]
            Session["giohang"] = giohang;
            return Json(new { ItemAmount = giohang.Sum(x => x.Quantity) });
        }
        public JsonResult getItemAmount()
        {
            List<CartItem> giohang = null;
            if (Session["giohang"] == null)
            {
                return Json(new { ItemAmount=0 },JsonRequestBehavior.AllowGet);
            }
            else
            {
                giohang = (List<CartItem>)Session["giohang"];
                return Json(new { ItemAmount = giohang.Sum(x => x.Quantity) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ShoppingCart()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Order()
        {
            if (Session["taikhoan"] == null)//nếu chưa đăng nhập
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<CartItem> giohang = (List<CartItem>)Session["giohang"];
            return View(giohang);
        }

        [HttpPost]
        public ActionResult Order(DateTime dateOrded,string descriptionOrd)
        {
            //Thêm đơn đặt hàng
            ORDER ddh = new ORDER();
            CUSTOMER kh = (CUSTOMER)Session["taikhoan"];
            List<CartItem> giohang = Session["GioHang"] as List<CartItem>;
            ddh.CUSTOMER_idCus = kh.idCus;
            ddh.dateOrded = dateOrded;
            ddh.totalPrice = giohang.Sum(r => r.Quantity);
            ddh.descriptionOrd = descriptionOrd;
            db.ORDER.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn đặt hàng
            foreach (var item in giohang)
            {
                ORDERDETAILS ctdh = new ORDERDETAILS();
                ctdh.ORDER_idOrd = ddh.idOrd;
                ctdh.PRODUCT_idPro = item.ProductOrder.idPro;
                ctdh.unitPriceOrdDe = item.Quantity;
                db.ORDERDETAILS.Add(ctdh);
                db.SaveChanges();
            }
            Session["giohang"] = null;
            return RedirectToAction("OrderConfirm", "Cart");
        }

        public ActionResult OrderConfirm()
        {
            return View();
        }
    }

}