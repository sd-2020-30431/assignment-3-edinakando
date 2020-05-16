using System.Collections.Generic;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;

namespace WastelessAPI.Queries
{
    public class GetCharitiesQuery : IRequest<IList<Charity>>
    {
    }
}
