using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataTablesInlineUpdate.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int OngoingOrderId { get; set; }
        public string CustomerNumber { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CartIdentifier { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class OrderLine
    {
        [Key]
        public int OrderLineId { get; set; }
        public int NumberOfItems { get; set; }
        public int PickedNumberOfItems { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public enum OrderStatus
    {
        Open = 200,
        PartDelivered = 300,
        Sent = 400,
        Makulated = 1000
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public int CustomerNumber { get; set; }
        public int ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public int BillingAddressId { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public string CustomerName { get; set; }
        public string OrganisationNumber { get; set; }
        public string CountryCode { get; set; }
        public string ContactName { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string AccountId { get; set; }

    }

    public class ShippingAddress
    {
        [Key]
        public int ShippingAddressId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string MailAddress { get; set; }

    }

    public class BillingAddress
    {
        [Key]
        public int BillingAddressId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string MailAddress { get; set; }


    }

    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string ArticleNumber { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public string Ean { get; set; }
        public int NumberOfItemsPerBox { get; set; }
        public decimal Price { get; set; }
        public string MainImage { get; set; }
        public List<Image> OtherImages { get; set; }
        public int Sort { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Depth { get; set; }
    }

    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}