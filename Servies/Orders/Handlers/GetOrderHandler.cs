using Data.Models;
using Data.Repository;
using MediatR;
using Servies.Orders.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, OrderModel>
    {


        public GetOrderHandler()
        {

        }
        public async Task<OrderModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();

            var orderById = ordersInMemory.OrderList.Where(x => x.OrderId == request.OrderId).FirstOrDefault();

            return await Task.FromResult(orderById);
        }
    }

}