using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tienda.Dto;
using Tienda.Interfaces;
using Tienda.WebAPI.Models;

namespace TiendaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("send")]
        public ActionResult<string> PostOrder([FromBody] OrderToSend newOrder, [FromServices] IOrderLogic orderLogic)
        {
                try
                {
                var orderItemsDTO = new List<OrderLines>();
                foreach(CartItem item in newOrder.Cart)
                {
                    orderItemsDTO.Add(new OrderLines(-1, item.ProductId, item.UnitPrice, item.Quantity));
                }
                    return Ok(orderLogic.SendOrder(new OrderToStore("", newOrder.CreatedDate, newOrder.UserId, newOrder.StatusId), orderItemsDTO));
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
        }
        [HttpPut("update")]
        public ActionResult PutOrderStatus([FromBody] Order updatedOrder, [FromServices] IOrderLogic orderLogic)
        {
            try 
                {
                if (orderLogic.UpdateOrderStatus(updatedOrder))
                    return Ok();
                else
                    return NotFound();
                } 
                catch (Exception e) 
                {
                    return BadRequest(e.Message);
                }

        }
        [HttpGet("list")]
        public ActionResult<OrderList> GetUserOrderList([FromQuery] int userId, [FromServices] IOrderLogic orderLogic)
        {
            try
            {
                var orderListRequest = orderLogic.GetOrders(userId);
                if (orderListRequest != null)
                    return orderListRequest;
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    } 
}
