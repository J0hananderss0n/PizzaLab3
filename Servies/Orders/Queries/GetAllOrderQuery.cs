using Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servies.Orders.Queries
{
    public class GetAllOrderQuery : IRequest<List<OrderModel>> { }

}