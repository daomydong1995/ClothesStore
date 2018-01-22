using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesStore.Models;
using PagedList;

namespace ClothesStore.Areas.Admin.Controllers
{
    public class PARTNERController : Controller
    {
        private ClothesStoreEntities db = new ClothesStoreEntities();

        // GET: Admin/PARTNER
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Getpaging(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewPartner", db.PARTNER.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/PARTNER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTNER pARTNER = db.PARTNER.Find(id);
            if (pARTNER == null)
            {
                return HttpNotFound();
            }
            return View(pARTNER);
        }

        // GET: Admin/PARTNER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PARTNER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPart,namePart,coverPart,linkPart")] PARTNER pARTNER)
        {
            if (ModelState.IsValid)
            {
                db.PARTNER.Add(pARTNER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pARTNER);
        }

        // GET: Admin/PARTNER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTNER pARTNER = db.PARTNER.Find(id);
            if (pARTNER == null)
            {
                return HttpNotFound();
            }
            return View(pARTNER);
        }

        // POST: Admin/PARTNER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPart,namePart,coverPart,linkPart")] PARTNER pARTNER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARTNER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pARTNER);
        }

        // GET: Admin/PARTNER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARTNER pARTNER = db.PARTNER.Find(id);
            if (pARTNER == null)
            {
                return HttpNotFound();
            }
            return View(pARTNER);
        }

        // POST: Admin/PARTNER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARTNER pARTNER = db.PARTNER.Find(id);
            db.PARTNER.Remove(pARTNER);
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
            PARTNER p = db.PARTNER.Find(ID);
            if (p == null)
            {
                return " Mã không tồn tại";
            }
            p.coverPart = picture;
            db.SaveChanges();
            return "";
        }
    }
}
