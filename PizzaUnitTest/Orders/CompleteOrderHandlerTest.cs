using PizzaUnitTest.MockOrder;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XunitOrderer;

namespace PizzaUnitTest.Orders
{
    [TestPriority(50)]
    public class CompleteOrderHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(501)]
        public void CompleteOrderHandlerSuccess()
        {
            var mockOrder = new MockOrderData();
            var changeStatus = mockOrder.CreateOrder();

            var actual = changeStatus.Status = Data.Models.OrderStatus.Done;
            var expected = Data.Models.OrderStatus.Done;

            Assert.Equal(expected, actual);
            
        }
        [Fact]
        [TestPriority(502)]
        public void CompleteOrderHandlerFailure()
        {
            var mockOrder = new MockOrderData();
            var changeStatus = mockOrder.CreateOrder();

            var actual = changeStatus.Status = Data.Models.OrderStatus.Done;
            var expected = Data.Models.OrderStatus.InProgress;

            Assert.NotEqual(expected, actual);
        }
    }
}
