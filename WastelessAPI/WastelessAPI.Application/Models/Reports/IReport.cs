using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.Application.Models.Reports
{
    public interface IReport
    {
        public Task<IList<ReportDto>> GetReport(Int32 userId);
    }

    public enum ReportType
    {
        Weekly,
        Monthly
    }
}
