using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataTablesInlineUpdate.Models;

namespace DataTablesInlineUpdate.Controllers
{
    public class BillingAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BillingAddresses
        public ActionResult Index()
        {
            return View(db.BillingAddress.ToList());
        }

        // GET: BillingAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingAddress billingAddress = db.BillingAddress.Find(id);
            if (billingAddress == null)
            {
                return HttpNotFound();
            }
            return View(billingAddress);
        }

        // GET: BillingAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillingAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingAddressId,Name,Address1,Address2,Address3,PostCode,City,CountryCode,PhoneNumber,MobileNumber,MailAddress")] BillingAddress billingAddress)
        {
            if (ModelState.IsValid)
            {
                db.BillingAddress.Add(billingAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billingAddress);
        }

        // GET: BillingAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingAddress billingAddress = db.BillingAddress.Find(id);
            if (billingAddress == null)
            {
                return HttpNotFound();
            }
            return View(billingAddress);
        }

        // POST: BillingAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingAddressId,Name,Address1,Address2,Address3,PostCode,City,CountryCode,PhoneNumber,MobileNumber,MailAddress")] BillingAddress billingAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billingAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billingAddress);
        }

        // GET: BillingAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingAddress billingAddress = db.BillingAddress.Find(id);
            if (billingAddress == null)
            {
                return HttpNotFound();
            }
            return View(billingAddress);
        }

        // POST: BillingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillingAddress billingAddress = db.BillingAddress.Find(id);
            db.BillingAddress.Remove(billingAddress);
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
