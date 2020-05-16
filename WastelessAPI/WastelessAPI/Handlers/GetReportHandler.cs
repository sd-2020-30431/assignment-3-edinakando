using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.DataAccess;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Handlers
{
    public class GetReportHandler : IRequestHandler<GetReportQuery, IList<GroceryItem>>
    {
        private WastelessDbContext _context;

        public GetReportHandler(WastelessDbContext context)
        {
            _context = context;
        }

        public async Task<IList<GroceryItem>> Handle(GetReportQuery request)
        {
            return await new ReportLogic(request.Factory, _context).GetReport(request.UserId);
        }
    }
}