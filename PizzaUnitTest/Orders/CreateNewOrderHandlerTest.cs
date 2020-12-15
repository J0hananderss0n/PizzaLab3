using Data.Repository;
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
    [TestPriority(60)]
    public class CreateNewOrderHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(601)]

        public async void CreateNewOrderHandlerSuccess()
        {
            CreateNewOrderCommand CreateNewOrderCommand = new CreateNewOrderCommand();
            CreateNewOrderHandler CreateNewOrderHandler = new CreateNewOrderHandler();

            CreateNewOrderCommand.Name = "Johan";

            var actual = await CreateNewOrderHandler.Handle(CreateNewOrderCommand, new CancellationToken());

            Assert.Equal("Johan", actual.Data.Name);
        }
        [Fact]
        [TestPriority(602)]
        public async void CreateNewOrderHandlerFailure()
        {
            CreateNewOrderCommand CreateNewOrderCommand = new CreateNewOrderCommand();
            CreateNewOrderHandler CreateNewOrderHandler = new CreateNewOrderHandler();

            CreateNewOrderCommand.Name = "Johan";

            var actual = await CreateNewOrderHandler.Handle(CreateNewOrderCommand, new CancellationToken());

            Assert.NotEqual("Andree", actual.Data.Name);
        }
    }
}
