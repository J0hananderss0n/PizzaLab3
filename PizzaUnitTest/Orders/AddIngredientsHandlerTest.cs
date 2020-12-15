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
    [TestPriority(30)]
    public class AddIngredientsHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(301)]
        public async void AddIngredientsHandlerSuccess()
        {
            AddIngredientsHandler addIngredientsHandler = new AddIngredientsHandler();
            MockOrderData mockData = new MockOrderData();
            var itemOrder = mockData.AddItemToOrder(1);
            var itemId = itemOrder.Items.Select(x => x.OrderItemId).FirstOrDefault();
            AddIngredientsCommand addIngredientsCommand = new AddIngredientsCommand(itemId, 4, itemOrder.OrderId);
            var order = await addIngredientsHandler.Handle(addIngredientsCommand, new CancellationToken());
            var orderIngredients = order.Data.Items.Where(x => x.Cost > 0).ToList();
            var actualName = order.Data.Items.FirstOrDefault();
            var numberOfExtraIngredients = actualName.Ingredients.Where(c => c.Cost > 0).ToList().Count();
            var expected = 1;

            Assert.Equal(expected, numberOfExtraIngredients);


        }
        [Fact]
        [TestPriority(302)]
        public async void AddIngredientsHandlerFailure()
        {
            AddIngredientsHandler addIngredientsHandler = new AddIngredientsHandler();
            MockOrderData mockData = new MockOrderData();
            var itemOrder = mockData.AddItemToOrder(5);
            var itemId = itemOrder.Items.Select(x => x.OrderItemId).FirstOrDefault();
            AddIngredientsCommand addIngredientsCommand = new AddIngredientsCommand(itemId, 4, itemOrder.OrderId);
            var order = await addIngredientsHandler.Handle(addIngredientsCommand, new CancellationToken());

            var actual = order.Error;
            var expected = false;

            Assert.NotEqual(expected, actual);
        }
    }
}
