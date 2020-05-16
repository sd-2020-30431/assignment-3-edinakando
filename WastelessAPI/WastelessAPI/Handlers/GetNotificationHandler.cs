using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Handlers
{
    public class GetNotificationHandler : IRequestHandler<GetNotificationQuery, IList<GroceryItem>>
    {
        private GroceriesLogic _groceriesLogic;

        public GetNotificationHandler(GroceriesLogic groceriesLogic)
        {
            _groceriesLogic = groceriesLogic;
        }

        public async Task<IList<GroceryItem>> Handle(GetNotificationQuery request)
        {
            return await _groceriesLogic.GetExpirationNotification(request.UserId);
        }
    }
}
