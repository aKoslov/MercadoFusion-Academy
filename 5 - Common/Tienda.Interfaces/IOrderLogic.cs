using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dto;

namespace Tienda.Interfaces
{
    public interface IOrderLogic
    {
        public OrderList GetOrders(int userId);
        public string SendOrder(OrderToStore newOrder, List<OrderLines> orderItems);
        public bool UpdateOrderStatus(Order updatedOrder);
    }
}
              