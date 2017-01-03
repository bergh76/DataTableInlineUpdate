using DataTablesInlineUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DataTablesInlineUpdate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController() { }
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public async Task<ActionResult> Orders(int orderline, ApplicationDbContext context, UnitOfWork repo)
        //{
        //    return View(await repo.OrderLines(orderline, context));
        //}

        [HttpPost]
        public JsonResult GetArticleNrValue(string artnrVal)
        {
            var search = from o in _context.OrderLines
                         join a in _context.Articles on o.ArticleId equals a.ArticleId
                  where a.ArticleNumber.StartsWith(artnrVal)
                         select new { a.ArticleNumber };
            return Json(search, JsonRequestBehavior.AllowGet);
        }
    }
}