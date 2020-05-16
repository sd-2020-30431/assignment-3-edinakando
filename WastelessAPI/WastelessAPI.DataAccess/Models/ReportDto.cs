using System.Collections.Generic;
using WastelessAPI.DataAccess.Interfaces;

namespace WastelessAPI.DataAccess.Models
{
    public class ReportDto : IReportDto
    {
        public GroceryItem Grocery { get; set; }
        public bool IsWaste { get; set; }
        public Color Color { get; set; }
    }
}
