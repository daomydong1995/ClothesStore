using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesStore.Models;

namespace ClothesStore.Areas.Admin.Controllers
{
    public class ORDERController : Controller
    {
        private ClothesStoreEntities db = new ClothesStoreEntities();

        // GET: Admin/ORDER
        public ActionResult Index()
        {
            var oRDER = db.ORDER.Include(o => o.CUSTOMER);
            return View(oRDER.ToList());
        }
        // GET: Admin/ORDER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // GET: Admin/ORDER/Create
        public ActionResult Create()
        {
            ViewBag.CUSTOMER_idCus = new SelectList(db.CUSTOMER, "idCus", "nameCus");
            return View();
        }

        // POST: Admin/ORDER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOrd,nameOrd,descriptionOrd,dateOrded,totalPrice,CUSTOMER_idCus")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.ORDER.Add(oRDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CUSTOMER_idCus = new SelectList(db.CUSTOMER, "idCus", "nameCus", oRDER.CUSTOMER_idCus);
            return View(oRDER);
        }

        // GET: Admin/ORDER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.CUSTOMER_idCus = new SelectList(db.CUSTOMER, "idCus", "nameCus", oRDER.CUSTOMER_idCus);
            return View(oRDER);
        }

        // POST: Admin/ORDER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOrd,nameOrd,descriptionOrd,dateOrded,totalPrice,CUSTOMER_idCus")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CUSTOMER_idCus = new SelectList(db.CUSTOMER, "idCus", "nameCus", oRDER.CUSTOMER_idCus);
            return View(oRDER);
        }

        // GET: Admin/ORDER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // POST: Admin/ORDER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDER oRDER = db.ORDER.Find(id);
            db.ORDER.Remove(oRDER);
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
    }
}
