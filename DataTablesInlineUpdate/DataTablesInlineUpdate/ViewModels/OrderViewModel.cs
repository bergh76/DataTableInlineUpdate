using DataTablesInlineUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTablesInlineUpdate.ViewModels
{
    public class OrderViewModel
    {
        public Article Articles { get; set; }
        public string Articlename { get; set; }
        public string ArticleId { get; set; }
        public OrderLine OrderLine { get; set; }
        public int OrderLineId { get; set; }
        public int OrderLineAmount { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}