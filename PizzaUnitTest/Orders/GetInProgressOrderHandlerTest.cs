using Data.Models;
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
    [TestPriority(80)]
    public class GetInProgressOrderHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(801)]
        public async void GetInProgressOrderHandlerSuccess()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.CreateOrder();
            GetInProgressOrdersQuery getInProgressOrdersQuery = new GetInProgressOrdersQuery();
            GetInProgressOrdersHandler getInProgressOrdersHandler = new GetInProgressOrdersHandler();
            var actual = await getInProgressOrdersHandler.Handle(getInProgressOrdersQuery, new CancellationToken());

            var actualInProgress = actual.Where(x => x.Status == OrderStatus.InProgress).Count();
            var orders = OrdersInMemory.GetInstance();

            var expected = orders.OrderList.Where(x => x.Status == OrderStatus.InProgress).Count();

            Assert.Equal(expected, actualInProgress);
        }
        [Fact]
        [TestPriority(802)]
        public async void GetInProgressOrderHandlerFailure()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.CreateOrder();
            GetInProgressOrdersQuery getInProgressOrdersQuery = new GetInProgressOrdersQuery();
            GetInProgressOrdersHandler getInProgressOrdersHandler = new GetInProgressOrdersHandler();
            var actual = await getInProgressOrdersHandler.Handle(getInProgressOrdersQuery, new CancellationToken());

            var actualInProgress = actual.Where(x => x.Status == OrderStatus.InProgress).Count();
            var orders = OrdersInMemory.GetInstance();

            var expected = orders.OrderList.Where(x => x.Status == OrderStatus.InProgress).Count() + 1;

            Assert.NotEqual(expected, actualInProgress);
        }
    }
}
