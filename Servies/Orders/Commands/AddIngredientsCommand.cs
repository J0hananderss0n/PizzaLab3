using Data.Models;
using Servies.Wrappers;
using System;

namespace Servies.Orders.Commands
{
    public class AddIngredientsCommand : IRequestWrapper<OrderModel>
    {

        public AddIngredientsCommand(Guid pizzaId, int Ingredients, Guid orderId)
        {
            this.PizzaId = pizzaId;
            this.IngredientId = Ingredients;
            this.OrderId = orderId;


        }
        public Guid PizzaId { get; set; }
        public int IngredientId { get; set; }
        public Guid OrderId { get; set; }

    }
}
