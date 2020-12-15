using Data.Models;
using Servies.Wrappers;
using System;

namespace Servies.Orders.Commands
{
    public class RemoveProductFromOrderCommand : IRequestWrapper<OrderModel>
    {

        public RemoveProductFromOrderCommand(Guid menuId, Guid orderId)
        {
            this.MenuId = menuId;
            this.OrderId = orderId;
        }
        public Guid MenuId { get; set; }
        public Guid OrderId { get; set; }

    }
}
