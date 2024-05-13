using Microsoft.EntityFrameworkCore;
using SjolundaFonster.Data.Models;
using SjolundaFonster.Services;

namespace SjolundaFonster.Pages
{
    partial class Index
    {
        private Window Window { get; set; } = new();
        private List<Color>? Colors { get; set; }
        private List<Model>? Models { get; set; }
        private string? MeasureHeader { get; set; }


        public PriceCalculatorService priceCalculator = new();

        private void AddToCart()
        {

            CartService.AddWindowToCart(Window);
            var SC = Window.Color;
            var SM = Window.Model;
            LoadSimularWindow(SC, SM);
        }
        protected override async Task OnInitializedAsync()
        {
            using var context = ContextFactory.CreateDbContext();
            Colors = await context.ProductColors.ToListAsync();
            Models = await context.ProductModels.ToListAsync();
            LoadNewWindow();
        }

        private void LoadNewWindow()
        {
            Window = new Window();
            if (Colors is not null)
            {
                var firstColor = Colors.FirstOrDefault();
                if (firstColor != null)
                {
                    Window.Color = firstColor;
                }

            }
            if (Models is not null)
            {
                var firstModel = Models.FirstOrDefault();
                if (firstModel != null)
                {
                    Window.Model = firstModel;
                }
            }

            Window.Height = 1000;
            Window.Width = 800;
            Window.UnitPrice = priceCalculator.CalculateUnitPrice(Window);
        }

        private void LoadSimularWindow(Color SC, Model SM)
        {
            Window = new Window();

            Window.Color = SC;
            Window.Model = SM;
            Window.Height = 1000;
            Window.Width = 800;
            Window.UnitPrice = priceCalculator.CalculateUnitPrice(Window);
        }

        public void HandleModelUpdate(Model model)
        {

            Window.Model = model;
            Window.UnitPrice = priceCalculator.CalculateUnitPrice(Window);

        }

        public void HandleColorUpdate(Color color)
        {
            Window.Color = color;
            Window.UnitPrice = priceCalculator.CalculateUnitPrice(Window);

        }


        public void GetMeasureHeader()
        {
            MeasureHeader = Window.Width + " x " + Window.Height;

        }
        private void UpdateQuantity(int newValue)
        {
            Window.Quantity = newValue;
        }

        private void UpdateWidth(int newValue)
        {
            Window.Width = newValue;
        }
       
        private void UpdateHeight(int newValue)
        {
            Window.Height = newValue;
        }
    }
}
