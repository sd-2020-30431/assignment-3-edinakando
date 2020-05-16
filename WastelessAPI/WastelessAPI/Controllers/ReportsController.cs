using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Factory;
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ReportType type, int userId)
        {
            IAbstractReportFactory factory = null;

            if (type == ReportType.Weekly)
            {
                factory = new WeeklyReportFactory();
            }
            else if (type == ReportType.Monthly)
            {
                factory = new MonthlyReportFactory();
            }
            return new JsonResult(await _mediator.Handle<GetReportQuery, IList<ColorDecorator>>(new GetReportQuery { UserId = userId, Factory = factory}));
        }
    }
}
