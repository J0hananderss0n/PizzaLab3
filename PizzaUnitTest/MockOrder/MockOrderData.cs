using Data.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaUnitTest.MockOrder
{
    public class MockOrderData
    {
        public OrderModel CreateOrder()
        {
            var ordersInMemory = OrdersInMemory.GetInstance();
            
            
            var order = new OrderModel
            {
                OrderId = Guid.NewGuid(),
                Name = "Johan",
                Items = new List<OrderItem>(),
                Created = DateTime.Now,
                Status = OrderStatus.InProgress
            };

          
            ordersInMemory.OrderList.Add(order);

            return order;

        }
      

        public OrderModel AddItemToOrder(int request)
        {

            var order = CreateOrder();

            var menu = MockData.GetInstance();

            var menuItem = menu.MenuList.Where(item => item.MenuItemId == request).FirstOrDefault();

            var orderItem = new OrderItem
            {
                OrderItemId = order.OrderId,
                MenuItemId = request,
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

            return order;
        }

    }
}
