using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaLab3.Models;
using Servies;
using Servies.Orders.Commands;
using Servies.Orders.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaLab3.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : Controller
    {
        public readonly IMediator mediator;
         // Alla querys ska inte ha response bara commands
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation("See all orders")] // fixa detta på alla
        public Task<List<OrderModel>> Get()
        {
            return mediator.Send(new GetAllOrderQuery());
        }

        [HttpGet]
        [SwaggerOperation("Get order by id")] // fixa detta på alla
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            OrderModel order = await mediator.Send(new GetOrderQuery(id));
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
       
        [HttpGet]
        [SwaggerOperation("See all orders that are in progress")] // fixa detta på alla
        [Route("inprogress")]
        public Task<List<OrderModel>> GetInProgress()
        {
            return mediator.Send(new GetInProgressOrdersQuery());
        }
        [HttpGet]
        [SwaggerOperation("See the total price on order")] // fixa detta på alla
        [Route("totalprice/{id}")]
        public Task<double> GetPriceOnOrder(Guid id)
        {
            return mediator.Send(new GetPriceOnOrderQuery(id));
        }
        [HttpGet]
        [SwaggerOperation("Changes Orderstatus on order to done")] // fixa detta på alla

        [Route("complete/{id}")]
        public async Task<IActionResult> GetCompleteOrder(Guid id)
        {
            OrderModel order = await mediator.Send(new CompleteOrderCommand(id));
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        [SwaggerOperation("Add menu item to order")] // fixa detta på alla
        [Route("add")]
        public async Task<IActionResult> GetAddItem(AddMenuItemRequest request)
        {
            OrderModel order = await mediator.Send(new AddItemToOrderCommand(request.OrderId, request.MenuItemId));
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        [SwaggerOperation("Create order")] // fixa detta på alla

        public Task<Response<OrderModel>> PostCreateOrder([FromBody] CreateNewOrderCommand command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("ingredient")]
        public async Task<Response<OrderModel>> GetAddIngredients(AddIngredientToOrderRequest request)
        {
            return await mediator.Send(new AddIngredientsCommand(request.OrderItemId, request.IngredientId, request.OrderId));
        }
        [HttpDelete]
        [Route("ingredient")]
        public async Task<Response<OrderModel>> GetRemoveProducts(RemoveIngredientRequest request)
        {
            return await mediator.Send(new RemoveProductFromOrderCommand(request.MenuItemId, request.OrderId));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<Response<OrderModel>> GetRemoveOrder(Guid id)
        {
            return await mediator.Send(new RemoveOrderCommand( id));
        }
    }
}
