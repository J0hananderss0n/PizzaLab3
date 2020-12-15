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
    [TestPriority(120)]

    public class RemoveProductFromOrderHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(1201)]
        public async void RemoveProductFromOrderHandlerSuccess()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.AddItemToOrder(4);
            RemoveProductFromOrderCommand removeProductFromOrderCommand = new RemoveProductFromOrderCommand(createOrder.Items[0].OrderItemId ,createOrder.OrderId);
            RemoveProductFromOrderHandler removeProductFromOrderHandler = new RemoveProductFromOrderHandler();

            var actual = await removeProductFromOrderHandler.Handle(removeProductFromOrderCommand, new CancellationToken());


            var actualbool = actual.Error;
            var expectedbool = false;

            Assert.Equal(expectedbool, actualbool);
        }
        [Fact]
        [TestPriority(1202)]
        public async void RemoveProductFromOrderHandlerFailure()
        {
            var mockOrder = new MockOrderData();
            var createOrder = mockOrder.AddItemToOrder(4);
            RemoveProductFromOrderCommand removeProductFromOrderCommand = new RemoveProductFromOrderCommand(createOrder.Items[0].OrderItemId, createOrder.OrderId);
            RemoveProductFromOrderHandler removeProductFromOrderHandler = new RemoveProductFromOrderHandler();

            var actual = await removeProductFromOrderHandler.Handle(removeProductFromOrderCommand, new CancellationToken());


            var actualbool = actual.Error;
            var expectedbool = true;

            Assert.NotEqual(expectedbool, actualbool);
        }
    }
}
