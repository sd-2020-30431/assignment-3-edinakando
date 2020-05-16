using System.Collections.Generic;
using WastelessAPI.Application.Factory;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Mediator;

namespace WastelessAPI.Queries
{
    public class GetReportQuery : IRequest<IList<GroceryItem>>
    {
        public int UserId { get; set; }
        public IAbstractReportFactory Factory { get; set; }
    }
}