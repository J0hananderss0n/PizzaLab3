using System;

namespace PizzaLab3.Models
{
    public class RemoveIngredientRequest
    {
        public Guid MenuItemId { get; set; }
        public Guid OrderId { get; set; }
    }
}
