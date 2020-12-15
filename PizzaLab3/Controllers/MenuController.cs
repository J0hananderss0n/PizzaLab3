using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Servies;
using Servies.Menu.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaLab3.Controllers
{

    [ApiController]
    [Route("menu")]
    public class MenuController : Controller
    {
        public readonly IMediator mediator;

        public MenuController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation("See the menu")] // fixa detta på alla

        public Task<List<MenuItem>> GetMenu()
        {
            return mediator.Send(new GetMenuQuery());

        }
        [HttpGet]
        [SwaggerOperation("See all the ingredients that can be added")] // fixa detta på alla

        [Route("/ingredients")]
        public Task<List<Ingredient>> GetIngredient()
        {
            return mediator.Send(new GetIngrediendsQuery());

        }
      
    }
}
