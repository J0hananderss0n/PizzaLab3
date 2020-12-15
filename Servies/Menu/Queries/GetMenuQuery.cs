using Data.Models;
using MediatR;
using Servies.Wrappers;
using System.Collections.Generic;

namespace Servies.Menu.Queries
{
    public class GetMenuQuery : IRequest<List<MenuItem>> { }

   
}
