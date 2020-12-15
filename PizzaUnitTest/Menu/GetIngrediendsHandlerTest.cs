using Data.Repository;
using Servies.Menu.Handlers;
using Servies.Menu.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;
using XunitOrderer;

namespace PizzaUnitTest.Menu
{
    [TestPriority(10)]
    public class GetIngrediendsHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(101)]

        public async void GetIngrediendsHandlerSuccess()
        {
            GetIngrediendsQuery getIngrediendsQuery = new GetIngrediendsQuery();
            GetIngrediendsQueryHandler getIngrediendsQueryHandler = new GetIngrediendsQueryHandler();
            var actual = await getIngrediendsQueryHandler.Handle(getIngrediendsQuery, new CancellationToken());
            Assert.Equal(10, actual.Count());
        }
        [Fact]
        [TestPriority(102)]

        public async void GetIngrediendsHandlerFailure()
        {
            GetIngrediendsQuery getIngrediendsQuery = new GetIngrediendsQuery();
            GetIngrediendsQueryHandler getIngrediendsQueryHandler = new GetIngrediendsQueryHandler();
            var actual = await getIngrediendsQueryHandler.Handle(getIngrediendsQuery, new CancellationToken());
            Assert.NotEqual(5, actual.Count());
        }
    }
}
