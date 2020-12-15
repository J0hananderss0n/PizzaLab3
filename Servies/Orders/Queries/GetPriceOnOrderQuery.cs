using Data.Models;
using MediatR;
using System;

namespace Servies.Orders.Queries
{
    public class GetPriceOnOrderQuery : IRequest<double> 
    {
        public Guid OrderId { get; set; }
        public GetPriceOnOrderQuery(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }

}