using DataTablesInlineUpdate.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DataTablesInlineUpdate.Models
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork() { }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        internal async Task<IEnumerable<OrderViewModel>> ListOrder(ApplicationDbContext context)
        {
            var result = from a in context.Articles
                         join o in context.OrderLines on a.ArticleId equals o.ArticleId
                         select new OrderViewModel
                         {
                             ArticleId = a.ArticleNumber,
                             Articlename = a.ArticleName,

                         };
            List<OrderViewModel> resOut = await result.ToListAsync();
            return resOut;

        }

        internal async Task<IEnumerable<OrderLine>> OrderLines(ApplicationDbContext context)
        {
            return await context.OrderLines.ToListAsync();
        }
    }
}