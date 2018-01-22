using ClothesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ClothesStoreEntities db = new ClothesStoreEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int idCate)
        {
            ViewBag.nameCate = db.CATEGORY.Find(idCate).nameCate;
            return View(db.PRODUCT.Where(x => x.CATEGORY_idCate == idCate).ToList());
        }
        public PartialViewResult PageProduct()
        {
            var listMan = db.PRODUCT.Where(r => db.CATEGORY.Where(x => x.moreCate == "1").Select(x => x.idCate).ToList().Contains(r.CATEGORY_idCate?? 0));
            var listWoman = db.PRODUCT.Where(r => db.CATEGORY.Where(x => x.moreCate == "0").Select(x => x.idCate).ToList().Contains(r.CATEGORY_idCate ?? 0));
            var listBag = db.PRODUCT.Where(r => db.CATEGORY.Where(x => x.nameCate == "Bag").Select(x => x.idCate).ToList().Contains(r.CATEGORY_idCate ?? 0));
            var listFootwear = db.PRODUCT.Where(r => db.CATEGORY.Where(x => x.nameCate == "Footwear").Select(x => x.idCate).ToList().Contains(r.CATEGORY_idCate ?? 0));
            ViewBag.ProductsMen = listMan.Take(8).ToList();
            ViewBag.ProductsWomen = listWoman.Take(8).ToList();
            ViewBag.ProductsBag = listBag.Take(8).ToList();
            ViewBag.ProductsFootwear = listFootwear.Take(8).ToList();
            return PartialView("_PartialProduct");

        }
        
        public PartialViewResult liMenuMan()
        {
            IEnumerable<CATEGORY> listCateMan = db.CATEGORY.Where(s => s.moreCate =="1").ToList();
            List<CATEGORY> a = listCateMan as List<CATEGORY>;
            ViewBag.listCateMan = a;
            return PartialView("_PartialMan");
        }
        public PartialViewResult liMenuWoMan()
        {
            IEnumerable<CATEGORY> listCateWoman = db.CATEGORY.Where(s => s.moreCate == "0").ToList();
            List<CATEGORY> a = listCateWoman as List<CATEGORY>;
            ViewBag.listCateWoman = a;
            return PartialView("_PartialWoMan");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            CUSTOMER kh = db.CUSTOMER.ToList().SingleOrDefault(x => x.emailCus == username && x.passCus == password);
            if (kh != null)
            {
                Session["taikhoan"] = kh;
            }
            ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            return Json(kh,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ClearSession()
        {
            string msg = "true";
            if (Session["taikhoan"] != null)
                Session["taikhoan"] = null;
            else msg = "false";
            return Json(new { message = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}