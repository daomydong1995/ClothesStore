using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ClothesStore.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace ClothesStore.Areas.Admin.Controllers
{
    public class PRODUCTController : Controller
    {
        private ClothesStoreEntities db = new ClothesStoreEntities();

        // GET: Admin/PRODUCT
        public ActionResult Index()
        {
            ViewBag.CATEGORY_idCate = new SelectList(db.CATEGORY, "idCate", "nameCate");
            ViewBag.PARTNER_idPart = new SelectList(db.PARTNER, "idPart", "namePart");
            return View();
        }
        public ActionResult Indexd()
        {

            return View(db.PRODUCT.ToList());
        }
        [HttpGet]
        public virtual ActionResult List(int page)
        {
            int pageSize = 5;
            var data = db.PRODUCT.Select(a => new
            {
                idPro = a.idPro,
                namePro = a.namePro,
                detailsPro = a.detailsPro,
                amountPro = a.amountPro,
                coverPro = a.coverPro,
                pricePro = a.pricePro,
                percentSalePro = a.percentSalePro,
                hotProduct = a.hotProduct,
                CATEGORY = a.CATEGORY,
                PARTNER = a.PARTNER
            }).ToList();
            var list = data.OrderBy(s => s.idPro).Skip((page - 1) * pageSize).Take(pageSize);
         
            return Json(new { data = list, total = data.Count }, JsonRequestBehavior.AllowGet);
        }
        // GET: Admin/PRODUCT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: Admin/PRODUCT/Create
        public PartialViewResult pageAction()
        {
            ViewBag.CATEGORY_idCate = new SelectList(db.CATEGORY, "idCate", "nameCate");
            ViewBag.PARTNER_idPart = new SelectList(db.PARTNER, "idPart", "namePart");
            return PartialView("_Create");
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PRODUCT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "idPro,namePro,detailsPro,amountPro,coverPro,pricePro,percentSalePro,hotProduct,CATEGORY_idCate,PARTNER_idPart")] PRODUCT pRODUCT)
        {
                db.PRODUCT.Add(pRODUCT);
                return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/PRODUCT/Edit/5
        public JsonResult Edit(int? id)
        {
            var list = db.PRODUCT.Find(id);
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/PRODUCT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit([Bind(Include = "idPro,namePro,detailsPro,amountPro,coverPro,pricePro,percentSalePro,hotProduct,CATEGORY_idCate,PARTNER_idPart")] PRODUCT pRODUCT)
        {
    
                db.Entry(pRODUCT).State = EntityState.Modified;
                return Json(db.SaveChanges(),JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/PRODUCT/Delete/5
        public JsonResult Delete(int? id)
        {
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            db.PRODUCT.Remove(pRODUCT);
            return Json(db.SaveChanges(), JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public string ChangeImage(string id ,string picture)
        {
            if (id == null)
            {
                return "Chưa truyền mã"+id;
            }
            int ID = Int32.Parse(id);
            PRODUCT p = db.PRODUCT.Find(ID);
            if(p == null)
            {
                return " Mã không tồn tại";
            }
            p.coverPro = picture;
            db.SaveChanges();
            return "";
        }
    }
    
}
