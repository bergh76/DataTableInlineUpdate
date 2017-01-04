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
    public class OrderLinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderLines
        public ActionResult Index()
        {
            var orderLines = db.OrderLines.Include(o => o.Article);
            return View(orderLines.ToList());
        }

        // GET: OrderLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // GET: OrderLines/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleNumber");
            return View();
        }

        // POST: OrderLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderLineId,NumberOfItems,PickedNumberOfItems,ArticleId,DeliveryDate,CreatedDate")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.OrderLines.Add(orderLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleNumber", orderLine.ArticleId);
            return View(orderLine);
        }

        // GET: OrderLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleNumber", orderLine.ArticleId);
            return View(orderLine);
        }

        // POST: OrderLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderLine orderLine, FormCollection form,  int id)
        {
            if (ModelState.IsValid)
            {
                string aId = form[1].ToString();
                var artId = db.Articles.Where(x => x.ArticleNumber == aId).Select(x => x.ArticleId).SingleOrDefault();
                orderLine = db.OrderLines.Find(id);
                orderLine.ArticleId = Convert.ToInt32(artId);
                db.Entry(orderLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ArticleId = new SelectList(db.Articles, "ArticleId", "ArticleNumber", orderLine.ArticleId);
            return RedirectToAction("Index");
        }

        // GET: OrderLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // POST: OrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderLine orderLine = db.OrderLines.Find(id);
            db.OrderLines.Remove(orderLine);
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

        [HttpPost]
        public JsonResult GetArticleNrValue(string artnrVal)
        {
            var s = db.Articles.Where(w => w.ArticleNumber
                .ToLower()
                .Contains(artnrVal.ToLower()
                )
            )
            .ToList();
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetArticleName(string artName)
        {
            var s = db.Articles.Where(w => w.ArticleName
                .ToLower()
                .Contains(artName.ToLower()
                )
            )
            .ToList();
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}
