using Data.Models;
using MediatR;
using System;

namespace Servies.Orders.Queries
{
    public class GetOrderQuery : IRequest<OrderModel> 
    {
        
        public GetOrderQuery(Guid orderId)
        {
           this.OrderId = orderId;
        }
        public Guid OrderId { get; set; }
    }
  
}
