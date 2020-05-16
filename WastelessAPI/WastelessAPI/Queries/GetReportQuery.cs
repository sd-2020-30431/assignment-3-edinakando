using System.Collections.Generic;
using WastelessAPI.Application.Factory;
using WastelessAPI.Application.Models.Reports;
using WastelessAPI.Mediator;

namespace WastelessAPI.Queries
{
    public class GetReportQuery : IRequest<IList<ColorDecorator>>
    {
        public int UserId { get; set; }
        public IAbstractReportFactory Factory { get; set; }
    }
}