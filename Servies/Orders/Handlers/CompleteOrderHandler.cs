using Data.Models;
using Data.Repository;
using MediatR;
using Servies.Orders.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Orders.Handlers
{
    class CompleteOrderHandler : IRequestHandler<CompleteOrderCommand, OrderModel>
    {


        public CompleteOrderHandler()
        {

        }
        public async Task<OrderModel> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
        {
            var ordersInMemory = OrdersInMemory.GetInstance();

            var order = ordersInMemory.OrderList.Where(x => x.OrderId == request.Id).FirstOrDefault();
            order.Status = OrderStatus.Done;


            return await Task.FromResult(order);
        }
    }

}