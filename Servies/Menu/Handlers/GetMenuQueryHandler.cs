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
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, List<MenuItem>>
    {


        public GetMenuQueryHandler()
        {

        }
        public async Task<List<MenuItem>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            var getMenu = MockData.GetInstance();

            return await Task.FromResult(getMenu.MenuList); 
        }
    }

}
