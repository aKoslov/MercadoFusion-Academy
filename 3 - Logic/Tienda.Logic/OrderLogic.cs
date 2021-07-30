using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.DapperDA;
using Tienda.Dto;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class OrderLogic : IOrderLogic
    {
        public DapperDataAccess dataAccess { get; }

        public OrderLogic()
        {
            this.dataAccess = new DapperDataAccess();
        }

        public OrderLogic(string connString)
        {
            this.dataAccess = new DapperDataAccess(connString);
        }

        public OrderList GetOrders(int userId)
        {
            return this.dataAccess.GetOrders(userId);
        }
        public string SendOrder(OrderToStore newOrder, List<OrderLines> orderItems)
        {
            newOrder.BillingNumber = Guid.NewGuid().ToString();
            return this.dataAccess.SendOrder(newOrder, orderItems);
        }
        public bool UpdateOrderStatus(Order updatedOrder)
        {
            return this.dataAccess.UpdateOrderStatus(updatedOrder);
        }
    }
}
