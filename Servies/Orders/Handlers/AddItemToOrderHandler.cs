using Data.Models;
using Data.Repository;
using MediatR;
using Servies.Orders.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    public class AddItemToOrderHandler : IRequestHandler<AddItemToOrderCommand, OrderModel>
    {


        public AddItemToOrderHandler()
        {

        }
        public async Task<OrderModel> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();


            var order = ordersInMemory.OrderList.Where(x => x.OrderId == request.Id).FirstOrDefault();

            var menu = MockData.GetInstance();

            var menuItem = menu.MenuList.Where(item => item.MenuItemId == request.MenuItemId).FirstOrDefault();

            var orderItem = new OrderItem
            {
                OrderItemId = Guid.NewGuid(),
                MenuItemId = request.MenuItemId,
                Cost = menuItem.Cost,
                Name = menuItem.Name,
                Type = menuItem.Type
            };
            order.TotalPrice += menuItem.Cost;

            if (menuItem.Type == "Pizza")
            {
                orderItem.Ingredients = menuItem.Ingredients;
            }
            order.Items.Add(orderItem);
            return await Task.FromResult(order);
        }
    }

}