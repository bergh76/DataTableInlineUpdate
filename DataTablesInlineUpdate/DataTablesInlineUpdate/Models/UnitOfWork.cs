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

        public async Task AddCustomer(ApplicationDbContext db, CustomerViewModel customModel)
        {
            var billingModel = new BillingAddress()
            {
                Address1 = customModel.BillingAddress.Address1,
                Address2 = customModel.BillingAddress.Address2,
                Address3 = customModel.BillingAddress.Address3,
                City = customModel.BillingAddress.City,
                CountryCode = customModel.BillingAddress.CountryCode,
                MailAddress = customModel.BillingAddress.MailAddress,
                MobileNumber = customModel.BillingAddress.MobileNumber,
                Name = customModel.BillingAddress.Name,
                PhoneNumber = customModel.BillingAddress.PhoneNumber,
                PostCode = customModel.BillingAddress.PostCode,
            };
            db.BillingAddress.Add(billingModel);
            await db.SaveChangesAsync();
            var shippModel = new ShippingAddress()
            {
                Address1 = customModel.ShippingAddress.Address1,
                Address2 = customModel.ShippingAddress.Address2,
                Address3 = customModel.ShippingAddress.Address2,
                MailAddress = customModel.ShippingAddress.MailAddress,
                City = customModel.ShippingAddress.City,
                CountryCode = customModel.ShippingAddress.CountryCode,
                MobileNumber = customModel.ShippingAddress.MobileNumber,
                PhoneNumber = customModel.ShippingAddress.PhoneNumber,
                Name = customModel.ShippingAddress.Name,
                PostCode = customModel.ShippingAddress.PostCode,
            };
            db.ShippingAddress.Add(shippModel);
            await db.SaveChangesAsync();
            var customerModel = new Customer()
            {
                BillingAddressId = billingModel.BillingAddressId,
                ShippingAddressId = shippModel.ShippingAddressId,
                ContactName = customModel.Customer.ContactName,
                CountryCode = customModel.Customer.CountryCode,
                CustomerName = customModel.Customer.CustomerName,
                CustomerNumber = customModel.Customer.CustomerNumber,
                MailAddress = customModel.Customer.MailAddress,
                MobileNumber = customModel.Customer.MobileNumber,
                OrganisationNumber = customModel.Customer.OrganisationNumber,
                PhoneNumber = customModel.Customer.PhoneNumber,
                AccountId = string.Format("{0}",Guid.NewGuid()),
            };
            db.Customers.Add(customerModel);
            await db.SaveChangesAsync();
        }


        //internal async Task<IEnumerable<Order>> ListOrder(ApplicationDbContext context)
        //{
        //    var result = from a in context.Articles
        //                 join ol in context.OrderLines on a.ArticleId equals ol.ArticleId
        //                 join o in context.Orders on ol.OrderLineId equals o.OrderId
        //                 select new OrderViewModel
        //                 {
        //                     ArticleId = a,
        //                     Article = ol.Article.ArticleName,
        //                     OrderId = o.OrderId,
        //                 };
        //    return await result.ToListAsync();

        //}

        //internal async Task<IEnumerable<OrderLines>> OrderLines(int orderlineId, ApplicationDbContext context)
        //{
        //    if (orderlineId != 0)
        //    {
        //        var oLine = await context.Orders
        //            .Where(x => x. == orderlineId)
        //            .Select(x => x.OrderId)
        //            .ToListAsync();
        //        return oLine.ToList();
        //    }
        //}
    }
}