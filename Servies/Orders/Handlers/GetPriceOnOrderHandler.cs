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
    public class GetPriceOnOrderHandler : IRequestHandler<GetPriceOnOrderQuery, double>
    {


        public GetPriceOnOrderHandler()
        {

        }
        public async Task<double> Handle(GetPriceOnOrderQuery request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();



            var orderById = ordersInMemory.OrderList.Where(x => x.OrderId == request.OrderId).FirstOrDefault();
            return await Task.FromResult(orderById.TotalPrice);
        }
    }
}