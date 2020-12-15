using Data.Models;
using MediatR;
using Servies.Wrappers;
using System.Collections.Generic;

namespace Servies.Orders.Queries
{
    public class GetInProgressOrdersQuery : IRequest<List<OrderModel>> { }
    
}
