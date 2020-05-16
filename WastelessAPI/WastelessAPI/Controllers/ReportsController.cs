using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Factory;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;
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
        public async Task<IActionResult> Index(ReportType type, Int32 userId)
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
            return new JsonResult(await _mediator.Handle<GetReportQuery, IList<GroceryItem>>(new GetReportQuery { UserId = userId, Factory = factory}));
        }
    }
}
