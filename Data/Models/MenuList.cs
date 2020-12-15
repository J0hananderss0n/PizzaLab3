using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class MenuList
    {
        public List<MenuItem> MenuItems { get; set; }
    }
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Type { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
    public class Ingredient
    {

        public int IngredientId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
    public class OrderItem : MenuItem
    {
        public Guid OrderItemId { get; set; }
    }
}
