
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Tienda.WebAPI.Models
{
    public class OrderForList
    {
        public string BillingNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId{ get; set; }
        public int StatusId { get; set; }
        public CartItem[] OrderItems { get; set; }
    }

    public class OrderToSend
    {
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public List<CartItem> Cart { get; set; }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
