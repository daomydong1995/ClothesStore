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
    public class CUSTOMERController : Controller
    {
        private ClothesStoreEntities db = new ClothesStoreEntities();

        // GET: Admin/CUSTOMER
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Getpaging(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewCustomer", db.CUSTOMER.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/CUSTOMER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMER.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // GET: Admin/CUSTOMER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CUSTOMER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCus,nameCus,emailCus,passCus,AdressCus,phoneCus,avaCus")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMER.Add(cUSTOMER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUSTOMER);
        }

        // GET: Admin/CUSTOMER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMER.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Admin/CUSTOMER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCus,nameCus,emailCus,passCus,AdressCus,phoneCus,avaCus")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUSTOMER);
        }

        // GET: Admin/CUSTOMER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMER.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Admin/CUSTOMER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER cUSTOMER = db.CUSTOMER.Find(id);
            db.CUSTOMER.Remove(cUSTOMER);
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
