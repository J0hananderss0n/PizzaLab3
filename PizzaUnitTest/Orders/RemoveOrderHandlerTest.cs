using PizzaUnitTest.MockOrder;
using Servies.Orders.Commands;
using Servies.Orders.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using XunitOrderer;

namespace PizzaUnitTest.Orders
{
    [TestPriority(110)]
    public class RemoveOrderHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(1101)]
        public async void RemoveOrderHandlerSuccess()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.CreateOrder();
            RemoveOrderCommand removeOrderCommand = new RemoveOrderCommand(createOrder.OrderId);
            RemoveOrderHandler removeOrderHandler = new RemoveOrderHandler();

            var actual = await removeOrderHandler.Handle(removeOrderCommand, new CancellationToken());

            var actualbool = actual.Error;
            var expectedbool = false;

            Assert.Equal(expectedbool, actualbool);

        }
        [Fact]
        [TestPriority(1102)]
        public async void RemoveOrderHandlerFailure()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.CreateOrder();
            RemoveOrderCommand removeOrderCommand = new RemoveOrderCommand(createOrder.OrderId);
            RemoveOrderHandler removeOrderHandler = new RemoveOrderHandler();

            var actual = await removeOrderHandler.Handle(removeOrderCommand, new CancellationToken());

            var actualbool = actual.Error;
            var expectedbool = true;

            Assert.NotEqual(expectedbool, actualbool);
        }
    }
}
