using Data.Repository;
using System.Linq;
using Xunit;

namespace PizzaTest.Menu
{
    public class GetMenuHandlerTest
    {
        [Fact]
        public void GetMenuHandlerSuccessTest()
        {
            var getMenu = MockData.GetInstance();

            var actual = getMenu.MenuList.Count();

            Assert.Equal(7, actual);

            Assert.Equal(7, actual);

        }
        //[Fact]
        //public void GetMenuHandlerFailure()
        //{
        //    //Assert.Equals(4, Add(2, 2));
        //}
    }
}

