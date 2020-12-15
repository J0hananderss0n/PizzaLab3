using Data.Models;
using Data.Repository;
using Servies.Orders.Commands;
using Servies.Wrappers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    public class CreateNewOrderHandler : IHandlerWrapper<CreateNewOrderCommand, OrderModel>
    {


        public CreateNewOrderHandler()
        {

        }
        public async Task<Response<OrderModel>> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();

            var order = new OrderModel
            {
                OrderId = Guid.NewGuid(),
                Name = request.Name,
                Items = new List<OrderItem>(),
                Created = DateTime.Now,
                Status = OrderStatus.InProgress
            };

            ordersInMemory.OrderList.Add(order); 

            return await Task.FromResult(Response.Ok(order, "OrderCreated"));
        }
    }

}