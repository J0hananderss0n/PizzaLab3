using Data.Models;
using Servies.Wrappers;
using System;
namespace Servies.Orders.Commands
{
    public class RemoveOrderCommand : IRequestWrapper<OrderModel>
    {

        public RemoveOrderCommand(Guid id)
        {
            this.id = id;
        }
        public Guid id { get; set; }

    }
}
