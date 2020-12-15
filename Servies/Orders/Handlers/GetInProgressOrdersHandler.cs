using Data.Models;
using Data.Repository;
using MediatR;
using Servies.Orders.Queries;
using Servies.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    public class GetInProgressOrdersHandler : IRequestHandler<GetInProgressOrdersQuery, List<OrderModel>>
    {


        public GetInProgressOrdersHandler()
        {

        }
        public async Task<List<OrderModel>> Handle(GetInProgressOrdersQuery request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();

            var orderById = ordersInMemory.OrderList.Where(x => x.Status == OrderStatus.InProgress).ToList();

            return await Task.FromResult(orderById);
        }
    }

}