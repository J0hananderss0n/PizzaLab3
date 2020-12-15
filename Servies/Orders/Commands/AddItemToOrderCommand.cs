using Data.Models;
using MediatR;
using System;

namespace Servies.Orders.Commands
{
    public class AddItemToOrderCommand : IRequest<OrderModel> 
    {
        public AddItemToOrderCommand(Guid Id, int menuItemId)
        {
            this.Id = Id;
            this.MenuItemId = menuItemId;
        }
        public Guid Id { get; set; }
        public int MenuItemId { get; set; }

    }

}
