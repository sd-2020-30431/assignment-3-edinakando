
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WastelessAPI.Application.Factory;
using WastelessAPI.Application.Models.Groceries;
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.DataAccess;

namespace WastelessAPI.Application.Logic
{
    public class ReportLogic
    {
        private IReport _report;

        public ReportLogic(IAbstractReportFactory factory, WastelessDbContext context)
        {
            _report = factory.CreateReport(context);
        }

        public async Task<IList<ColorDecorator>> GetReport(Int32 userId)
        {
           var report = await _report.GetReport(userId);
            return report.Select(r => new ColorDecorator(r)).ToList();
        }
    }
}
