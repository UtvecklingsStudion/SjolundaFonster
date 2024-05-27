using SjolundaFonster.Data.Models;

namespace SjolundaFonster.Services
{
    public class PriceCalculatorService
    {
        public int CalculateUnitPrice(Window window)
        {
         
            decimal area = window.Width * window.Height;
            decimal UnitPrice = area * 6500 /1000000;
            if (window.Model.Id == 2)
            {
                UnitPrice = UnitPrice * 1.2m;
            }
            if (window.Model.Id == 1)
            {
                UnitPrice *= 1.3m;
            }
            if (window.Color.Id != 1)
            {
                UnitPrice += 300;
            }

            return ((int)Math.Round(UnitPrice/10)*10);
        }
    }
}
