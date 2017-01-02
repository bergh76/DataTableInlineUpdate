using DataTablesInlineUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTablesInlineUpdate.ViewModels
{
    public class OrderViewModel
    {
        public Article Article { get; set; }
        public string Articlename { get; set; }
        public string ArticleId { get; set; }
        public OrderLine OrderLine { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}