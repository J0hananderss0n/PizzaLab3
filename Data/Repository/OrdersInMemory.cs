using Data.Models;
using System.Collections.Generic;

namespace Data.Repository
{
    public class OrdersInMemory
    {
        private static OrdersInMemory _instance;

        public static OrdersInMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new OrdersInMemory();
            }
            return _instance;
        }
        private OrdersInMemory()
        {
            SetOrderList();
        }
        public List<OrderModel> OrderList { get; set; }

        private void SetOrderList()
        {
            OrderList = new List<OrderModel>();
        }
    }
}
