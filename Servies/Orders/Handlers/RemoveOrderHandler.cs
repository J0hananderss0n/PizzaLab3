using Data.Models;
using Data.Repository;
using Servies.Orders.Commands;
using Servies.Wrappers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    public class RemoveOrderHandler : IHandlerWrapper<RemoveOrderCommand, OrderModel>
    {


        public RemoveOrderHandler()
        {

        }
        public async Task<Response<OrderModel>> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {

            var ordersInMemory = OrdersInMemory.GetInstance();

            var orderById = ordersInMemory.OrderList.Where(x => x.OrderId == request.id).FirstOrDefault();


            ordersInMemory.OrderList.Remove(orderById);




            return await Task.FromResult(Response.Ok(orderById, " success"));
        }
    }

}