using Data.Models;
using Data.Repository;
using MediatR;
using Servies.Orders.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, List<OrderModel>>
    {


        public GetAllOrderHandler()
        {

        }
        public async Task<List<OrderModel>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();

            return await Task.FromResult(ordersInMemory.OrderList);

        }
    }

}