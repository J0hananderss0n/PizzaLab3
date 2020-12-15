using Data.Models;
using Data.Repository;
using Servies.Orders.Commands;
using Servies.Wrappers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Servies.Orders.Handlers
{
    public class AddIngredientsHandler : IHandlerWrapper<AddIngredientsCommand, OrderModel>
    {


        public AddIngredientsHandler()
        {

        }
        public async Task<Response<OrderModel>> Handle(AddIngredientsCommand request, CancellationToken cancellationToken)
        {

            var ordersInMemory = OrdersInMemory.GetInstance();

            var order = ordersInMemory.OrderList.Where(x => x.OrderId == request.OrderId).FirstOrDefault();

            var menuItem = order.Items.Where(x => x.OrderItemId == request.PizzaId).FirstOrDefault();

            var ingredients = MockData.GetInstance();

            var pickIngredients = ingredients.IngredientsList.Where(x => x.IngredientId == request.IngredientId).FirstOrDefault();

            order.TotalPrice += pickIngredients.Cost;

            if (menuItem.Type == "Pizza")
            {
                menuItem.Ingredients.Add(pickIngredients);
                return await Task.FromResult(Response.Ok(order, " success"));

            }
            return await Task.FromResult(Response.Fail("Need to be a pizza to add ingredients", order));
        }
    }
}