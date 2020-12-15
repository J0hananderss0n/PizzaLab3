using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public List<OrderItem> Items { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Created { get; set; }
        public OrderStatus Status { get; set; }
    }
   
    public enum OrderStatus
    {
        InProgress,
        Cancelled,
        Done
    }
}
