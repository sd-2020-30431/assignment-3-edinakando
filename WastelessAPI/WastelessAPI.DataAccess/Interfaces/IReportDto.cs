using System.Collections.Generic;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.DataAccess.Interfaces
{
    public interface IReportDto
    {
        public GroceryItem Grocery { get; set; }
        public bool IsWaste { get; set; }
        public Color Color { get; set; }
    }

    public enum Color
    {
        Red,
        Green
    }
}