namespace SjolundaFonster.Components
{
    partial class CartIcon
    {
        private int count { get; set; }

        protected override void OnInitialized()
        {
            UpdateCount();
            CartService.OnChange += UpdateCount;
        }

        private void UpdateCount()
        {
            count = CartService.GetCartQuantity();
            StateHasChanged();
        }


        public void Dispose()
        {
            CartService.OnChange -= UpdateCount;
        }
    }
}
