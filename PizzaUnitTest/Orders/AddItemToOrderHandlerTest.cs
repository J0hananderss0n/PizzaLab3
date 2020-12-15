using Data.Models;
using Data.Repository;
using PizzaUnitTest.MockOrder;
using Servies.Orders.Commands;
using Servies.Orders.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;
using XunitOrderer;

namespace PizzaUnitTest.Orders
{
    [TestPriority(40)]
    public class AddItemToOrderHandlerTest : TestClassBase
    {

        [Fact]
        [TestPriority(401)]
        public async void AddItemToOrderHandlerSuccess()
        {
            AddItemToOrderHandler addItemToOrderHandler = new AddItemToOrderHandler();

            var ordersInMemory = OrdersInMemory.GetInstance();
            var mockOrder = new MockOrderData();

            var request = mockOrder.CreateOrder();
            var order = ordersInMemory.OrderList.Where(x => x.OrderId == request.OrderId).FirstOrDefault();

            AddItemToOrderCommand addItemToOrderCommand = new AddItemToOrderCommand(request.OrderId, 3);

            var actual = await addItemToOrderHandler.Handle(addItemToOrderCommand, new CancellationToken());

            var actualName = actual.Items.Select(x => x.MenuItemId).FirstOrDefault();
            var expected = 3;

            Assert.Equal(expected, actualName);
        }
        [Fact]
        [TestPriority(402)]
        public async void AddItemToORderHandlerFailure()
        {
            AddItemToOrderHandler addItemToOrderHandler = new AddItemToOrderHandler();

            var ordersInMemory = OrdersInMemory.GetInstance();
            var mockOrder = new MockOrderData();

            var request = mockOrder.CreateOrder();
            var order = ordersInMemory.OrderList.Where(x => x.OrderId == request.OrderId).FirstOrDefault();

            AddItemToOrderCommand addItemToOrderCommand = new AddItemToOrderCommand(request.OrderId, 3);

            var actual = await addItemToOrderHandler.Handle(addItemToOrderCommand, new CancellationToken());

            var actualName = actual.Items.Select(x => x.MenuItemId).FirstOrDefault();
            var expected = 1;

            Assert.Single(actual.Items);
            Assert.NotEqual(expected, actualName);
        }
    }
}
