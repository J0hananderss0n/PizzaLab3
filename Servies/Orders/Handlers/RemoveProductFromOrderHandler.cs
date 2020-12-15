using Data.Models;
using Data.Repository;
using Servies.Orders.Commands;
using Servies.Wrappers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    public class RemoveProductFromOrderHandler : IHandlerWrapper<RemoveProductFromOrderCommand, OrderModel>
    {


        public RemoveProductFromOrderHandler()
        {

        }
        public async Task<Response<OrderModel>> Handle(RemoveProductFromOrderCommand request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();

            var orderById = ordersInMemory.OrderList.Where(x => x.OrderId == request.OrderId).FirstOrDefault();
            var itemToRemove = orderById.Items.Where(x => x.OrderItemId == request.MenuId).FirstOrDefault();

            orderById.TotalPrice -= itemToRemove.Cost;

            orderById.Items.Remove(itemToRemove);
            return await Task.FromResult(Response.Ok(orderById, " success"));
        }
    }

}