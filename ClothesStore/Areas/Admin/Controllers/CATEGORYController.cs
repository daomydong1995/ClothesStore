using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ClothesStore.Models;

namespace ClothesStore.Areas.Admin.Controllers
{
    public class CATEGORYController : Controller
    {
        private ClothesStoreEntities db = new ClothesStoreEntities();

        // GET: Admin/CATEGORY
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Getpaging(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewCategory", db.CATEGORY.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/CATEGORY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CATEGORY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCate,nameCate,coverCate,iconCate,moreCate")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORY.Add(cATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORY);
        }

        // GET: Admin/CATEGORY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCate,nameCate,coverCate,iconCate,moreCate")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORY cATEGORY = db.CATEGORY.Find(id);
            db.CATEGORY.Remove(cATEGORY);
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
        public string ChangeImage(string id, string picture)
        {
            if (id == null)
            {
                return "Chưa truyền mã" + id;
            }
            int ID = Int32.Parse(id);
            CATEGORY p = db.CATEGORY.Find(ID);
            if (p == null)
            {
                return " Mã không tồn tại";
            }
            p.coverCate = picture;
            db.SaveChanges();
            return "";
        }
    }
}

