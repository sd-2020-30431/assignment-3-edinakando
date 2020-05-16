using System.Collections.Generic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;

namespace WastelessAPI.Queries
{
    public class GetNotificationQuery : IRequest<IList<GroceryItem>>
    {
        public int UserId { get; set; }
    }
}