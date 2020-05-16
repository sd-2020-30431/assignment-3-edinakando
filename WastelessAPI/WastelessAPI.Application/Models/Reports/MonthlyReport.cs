using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.DataAccess;
using WastelessAPI.DataAccess.Models;
using WastelessAPI.DataAccess.Repositories;

namespace WastelessAPI.Application.Models.Reports
{
    public class MonthlyReport : IReport
    {
        private WastelessDbContext _context;

        public MonthlyReport(WastelessDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ReportDto>> GetReport(Int32 userId)
        {
            var reportRepository = new ReportRepository(_context);
            return await reportRepository.GetMonthlyReport(userId);
        }
    }
}