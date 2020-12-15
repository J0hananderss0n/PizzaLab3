using Data.Models;
using Data.Repository;
using MediatR;
using Servies.Menu.Queries;
using Servies.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Servies.Menu.Handlers
{

    public class GetIngrediendsQueryHandler : IRequestHandler<GetIngrediendsQuery, List<Ingredient>>
    {


        public GetIngrediendsQueryHandler()
        {

        }
        public async Task<List<Ingredient>> Handle(GetIngrediendsQuery request, CancellationToken cancellationToken)
        {
            var ordersInMemory = MockData.GetInstance();

            return await Task.FromResult(ordersInMemory.IngredientsList);
        }
    }
}

