using System.Collections.Generic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;

namespace WastelessAPI.Queries
{
    public class GetGroceriesQuery : IRequest<IList<Groceries>>
    {
        public int UserId { get; set; }
    }
}
