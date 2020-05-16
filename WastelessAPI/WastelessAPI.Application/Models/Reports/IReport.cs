using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Application.Models.Groceries;

namespace WastelessAPI.Application.Models.Reports
{
    public interface IReport
    {
        public Task<IList<GroceryItem>> GetReport(Int32 userId);
    }

    public enum ReportType
    {
        Weekly,
        Monthly
    }
}
