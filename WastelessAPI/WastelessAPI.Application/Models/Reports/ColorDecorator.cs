using WastelessAPI.DataAccess.Interfaces;
using WastelessAPI.DataAccess.Models;

namespace WastelessAPI.Application.Models.Reports
{
    public class ColorDecorator : IReportDto
    {
        private IReportDto _instance;

        public ColorDecorator(IReportDto instance)
        {
            _instance = instance;
        }

        public GroceryItem Grocery
        {
            get { return _instance.Grocery; }
            set { _instance.Grocery = value; }
        }
        public bool IsWaste
        {
            get { return _instance.IsWaste; }
            set { _instance.IsWaste = value; }
        }

        public Color Color
        {
            get
            {
                if (_instance.IsWaste)
                    return Color.Red;
                return Color.Green;
            }
            set { _instance.Color = value; }
        }
    }
}