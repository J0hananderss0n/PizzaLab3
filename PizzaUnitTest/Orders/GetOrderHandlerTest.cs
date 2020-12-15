using Data.Repository;
using PizzaUnitTest.MockOrder;
using Servies.Orders.Handlers;
using Servies.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;
using XunitOrderer;

namespace PizzaUnitTest.Orders
{
    [TestPriority(90)]

    public class GetOrderHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(901)]
        public async void GetOrderHandlerSuccess()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.CreateOrder();
            GetOrderQuery getOrderQuery = new GetOrderQuery(createOrder.OrderId);
            GetOrderHandler getOrderHandler = new GetOrderHandler();
            var actual = await getOrderHandler.Handle(getOrderQuery, new CancellationToken());
            
            Assert.Equal(createOrder.OrderId, actual.OrderId);
        }
        [Fact]
        [TestPriority(902)]
        public async void GetOrderHandlerFailure()
        {
            var mockOrder = new MockOrderData();
            var createOrderOne = mockOrder.CreateOrder();
            var createOrderTwo = mockOrder.CreateOrder();
            GetOrderQuery getOrderQuery = new GetOrderQuery(createOrderOne.OrderId);
            GetOrderHandler getOrderHandler = new GetOrderHandler();
            var actual = await getOrderHandler.Handle(getOrderQuery, new CancellationToken());
            Assert.NotEqual(createOrderTwo.OrderId, actual.OrderId);
        }
    }
}
