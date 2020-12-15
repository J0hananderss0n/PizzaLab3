using Data.Models;
using MediatR;
using System;

namespace Servies.Orders.Commands
{
    public class CompleteOrderCommand : IRequest<OrderModel> {

        public CompleteOrderCommand(Guid Id)
        {
            this.Id = Id;
        }
        public Guid Id { get; set; }

    }
}
