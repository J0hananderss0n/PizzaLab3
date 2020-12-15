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
    [TestPriority(20)]

    public class GetMenuHandlerTest : TestClassBase
    {
        [Fact]
        [TestPriority(201)]

        public async void GetMenuHandlerSuccess()
        {
            GetMenuQuery getMenuQuery = new GetMenuQuery();
            GetMenuQueryHandler getMenuHandler = new GetMenuQueryHandler();
            var actual= await getMenuHandler.Handle(getMenuQuery, new CancellationToken());
            Assert.Equal(7, actual.Count());
        }
        [Fact]
        [TestPriority(202)]

        public async void GetMenuHandlerFailure()
        {
            GetMenuQuery getMenuQuery = new GetMenuQuery();
            GetMenuQueryHandler getMenuHandler = new GetMenuQueryHandler();
            var actual = await getMenuHandler.Handle(getMenuQuery, new CancellationToken());
            Assert.NotEqual(5, actual.Count());
        }
    }
}
