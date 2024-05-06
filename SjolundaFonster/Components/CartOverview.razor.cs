//using Microsoft.AspNetCore.Components;
//using SjolundaFonster.Data.Models;

//namespace SjolundaFonster.Components
//{
//    partial class CartOverview
//    {
//        private List<Window>? CartItems;
//        private int Sum { get; set; }

//        [Parameter]
//        public EventCallback OnClick { get; set; }

//        protected override void OnInitialized()
//        {
//            CartItems = CartService.GetCartItems();
//            UpdateCart();
//            CartService.OnChange += UpdateCart;
//        }

//        private void UpdateCart()
//        {
//            CartItems = CartService.GetCartItems();
//            Sum = CartService.GetCartSum();
//            StateHasChanged();
//        }

//        public void Dispose()
//        {
//            CartService.OnChange -= UpdateCart;
//        }
//    }
//}
