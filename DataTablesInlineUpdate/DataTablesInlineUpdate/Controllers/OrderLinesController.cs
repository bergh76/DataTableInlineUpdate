using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
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

        public ActionResult OrderFilterOrderDate(string dateQ)
        {
          

            //if (Request.IsAjaxRequest())
            //{
            //    var q = dateQ;
            //    if (String.IsNullOrEmpty(q))
            //    {
            //        var emptyorders = new List<Order>();
            //        model.Orders = emptyorders;
            //        ViewBag.Filter = "No date added";
            //        return PartialView("_OrderList", model);
            //    }
            //    try
            //    {
            //        var fromDate = q.Substring(0, 10);
            //        var toDate = q.Substring(13, 10);

            //        var sDate = Convert.ToDateTime(fromDate);
            //        var eDate = Convert.ToDateTime(toDate);

            //        var orders =
            //            db.Orders.Where(s => s.Status != OrderStatus.Makulated)
            //                .Where(d => d.CreatedDate >= sDate && d.CreatedDate <= eDate)
            //                .Include(ii => ii.Customer)
            //                .Include(o => o.OrderLines)
            //                .ToList();
            //        model.Orders = orders;
            //        ViewBag.Filter = "Filtered on created date";
            //        return PartialView("_OrderList", model);

            //    }
            //    catch (Exception e)
            //    {
            //        return RedirectToAction("Index", "Manage");

            //    }



            //}

            return null;

        }
        
        public JsonResult Tester(string artNum, string orderlineid, int numberofitems, string deliverydate)
        {
            if (Request.IsAjaxRequest())
            {

                TempData["IsFixd"] = "true";

                return Json("", JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Edit(string artNum, string orderlineid, int numberofitems, string deliverydate)
        {
            if (ModelState.IsValid)
            {
         
                //var artId = db.Articles.Where(x => x.ArticleNumber == aId).Select(x => x.ArticleId).SingleOrDefault();
                //var orderLine = db.OrderLines.Find(id);
                //orderLine.ArticleId = Convert.ToInt32(artId);
                //db.Entry(orderLine).State = EntityState.Modified;
                //db.SaveChanges();
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

        public JsonResult GetArticleNrValue(string artnrVal)
        {
            if (Request.IsAjaxRequest())
            {
                var s = db.Articles.Where(w => w.ArticleNumber
                .ToLower()
                .Contains(artnrVal.ToLower()
                )
            )
            .ToList();
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return Json(false);
        }

        public JsonResult GetArticleName(string artName)
        {
            if (Request.IsAjaxRequest())
            {
                var s = db.Articles.Where(w => w.ArticleName
                .ToLower()
                .Contains(artName.ToLower()
                )
            )
            .ToList();
                return Json(s, JsonRequestBehavior.AllowGet);
            }
            return Json(false);
        }
    }
}
