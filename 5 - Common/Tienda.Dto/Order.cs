using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Tienda.Dto
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string BillingNumber { get; set; }       
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
    }

    [Table("Orders")]
    public class OrderToStore
    {
        public string BillingNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public OrderToStore(string BillingNumber, DateTime CreatedDate, int UserId, int StatusId) {
            this.BillingNumber = BillingNumber;
            this.CreatedDate = CreatedDate;
            this.UserId = UserId;
            this.StatusId = StatusId;
        }
    }

    public class OrderList
    {
        public List<OrderResponse> List { get; set; }
        public int Count { get; set; }
    }

    public class OrderResponse
    {
       public Order Details { get; set; }
        public List<OrderLines> Items { get; set; }
    }

    [Table("OrderLines")]
    public class OrderLines
    {
        [ExplicitKey]
        public int OrderId { get; set; }
        [ExplicitKey]
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public OrderLines() { }

        public OrderLines(int OrderId, int ProductId, decimal UnitPrice, int Quantity) 
        {
            this.OrderId = OrderId;
            this.ProductId = ProductId;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;

        }
    }

}

