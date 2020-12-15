using System;

namespace PizzaLab3.Models
{
    public class AddIngredientToOrderRequest
    {
        public Guid OrderItemId { get; set; }
        public int IngredientId { get; set; }
        public Guid OrderId { get; set; }
    }
}
