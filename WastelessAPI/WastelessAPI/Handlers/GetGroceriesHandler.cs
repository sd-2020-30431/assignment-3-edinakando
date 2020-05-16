using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Handlers
{
    public class GetGroceriesHandler : IRequestHandler<GetGroceriesQuery, IList<Groceries>>
    {
        private GroceriesLogic _groceriesLogic;

        public GetGroceriesHandler(GroceriesLogic groceriesLogic)
        {
            _groceriesLogic = groceriesLogic;
        }

        public async Task<IList<Groceries>> Handle(GetGroceriesQuery request)
        {
            return await _groceriesLogic.GetGroceries(request.UserId);
        }
    }
}
