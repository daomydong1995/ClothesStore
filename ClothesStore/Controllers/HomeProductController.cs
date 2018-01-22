using ClothesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesStore.Controllers
{
    public class HomeProductController : Controller
    {
        ClothesStoreEntities db = new ClothesStoreEntities();
        // GET: Product
        public ActionResult Details(int id)
        {
            return View(db.PRODUCT.Find(id));
        }
        [HttpPost]
        public JsonResult AutoComplete(string key)
        {
            var list = db.PRODUCT.Where(s => s.namePro != null && s.namePro.ToLower().Contains(key.ToLower())).Select(s => s.namePro).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Search(string keyword)
        {
            List<PRODUCT> list = new List<PRODUCT>();
            ViewBag.search = keyword;
            if (!String.IsNullOrEmpty(keyword))
            {
                list = db.PRODUCT.Where(x => x.namePro.ToLower().Contains(keyword.ToLower())).ToList();
            }
            return View(list);
        }
    }
}