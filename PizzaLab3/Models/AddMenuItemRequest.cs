using System;

namespace PizzaLab3.Models
{
    public class AddMenuItemRequest
    {
        public Guid OrderId { get; set; }
        public int MenuItemId { get; set; }
    }
}
