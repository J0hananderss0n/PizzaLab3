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
    [TestPriority(70)]
    public class GetAllOrdersHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(701)]
        public async void GetAllOrdersHandlerSuccess()
        {
            var mockOrder = new MockOrderData();
            mockOrder.CreateOrder();
            mockOrder.CreateOrder();
            GetAllOrderQuery getAllOrderQuery = new GetAllOrderQuery();
            GetAllOrderHandler getAllOrderHandler = new GetAllOrderHandler();
            var actualHandle = await getAllOrderHandler.Handle(getAllOrderQuery, new CancellationToken());

            var actual = actualHandle.Select(x => x.OrderId).Count();
            var orderList = OrdersInMemory.GetInstance();
            var expected = orderList.OrderList.Count();

            Assert.Equal(expected, actual);
        }
        [Fact]
        [TestPriority(702)]
        public async void GetAllOrdersHandlerFailure()
        {
            var mockOrder = new MockOrderData();
            mockOrder.CreateOrder();
            mockOrder.CreateOrder();
            GetAllOrderQuery getAllOrderQuery = new GetAllOrderQuery();
            GetAllOrderHandler getAllOrderHandler = new GetAllOrderHandler();
            var actual = await getAllOrderHandler.Handle(getAllOrderQuery, new CancellationToken());
            Assert.NotEqual(1, actual.Count());
        }
    }
}
