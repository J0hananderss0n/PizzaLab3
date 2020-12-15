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
    [TestPriority(100)]
    public class GetPriceOnOrderHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(1001)]
        public async void GetPriceOnOrderHandlerSuccess()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.AddItemToOrder(5);
            GetPriceOnOrderQuery getPriceOnOrderQuery = new GetPriceOnOrderQuery(createOrder.OrderId);
            GetPriceOnOrderHandler getPriceOnOrderHandler = new GetPriceOnOrderHandler();
            var actual = await getPriceOnOrderHandler.Handle(getPriceOnOrderQuery, new CancellationToken());
            var expected = 20;
            Assert.Equal(expected, actual);
        }
        [Fact]
        [TestPriority(1002)]
        public async void GetPriceOnOrderHandlerFailure()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.AddItemToOrder(1);
            GetPriceOnOrderQuery getPriceOnOrderQuery = new GetPriceOnOrderQuery(createOrder.OrderId);
            GetPriceOnOrderHandler getPriceOnOrderHandler = new GetPriceOnOrderHandler();
            var actual = await getPriceOnOrderHandler.Handle(getPriceOnOrderQuery, new CancellationToken());
            var expected = 20;
            Assert.NotEqual(expected, actual);
        }

    }
}
