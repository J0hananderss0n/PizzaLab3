using Data.Models;
using Servies.Wrappers;

namespace Servies.Orders.Commands
{
    public class CreateNewOrderCommand : IRequestWrapper<OrderModel> 
    {

        public string  Name { get; set; }


    }

}