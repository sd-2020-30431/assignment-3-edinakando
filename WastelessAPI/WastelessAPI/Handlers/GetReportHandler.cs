using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Handlers
{
    public class GetReportHandler : IRequestHandler<GetReportQuery, IList<ColorDecorator>>
    {
        private WastelessDbContext _context;

        public GetReportHandler(WastelessDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ColorDecorator>> Handle(GetReportQuery request)
        {
            return await new ReportLogic(request.Factory, _context).GetReport(request.UserId);
            //return colorDecorators.Select(c => new ReportDto
            //{
            //    Grocery = c.Grocery,
            //    Color = c.Color
            //}).ToList();
        }
    }
}