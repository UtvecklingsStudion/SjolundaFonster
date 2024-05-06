using SjolundaFonster.Data.Models;
using Microsoft.JSInterop;
using System.Data;
using Microsoft.AspNetCore.Components;

namespace SjolundaFonster.Services
{
    public class CartService
    {
        public List<Window> CartItems = new();

        public event Action OnChange;

        public void NotifyCartUpdated() => OnChange?.Invoke();

        public void DeleteWindowFromCart(Window window)
        {
           CartItems.Remove(window);
       
           NotifyCartUpdated();
        }

        public void IncreaseWindowInCart(Window window)
        {
            var existingItem = CartItems.FirstOrDefault(item =>
             item.Height == window.Height &&
             item.Width == window.Width &&
             item.Color.Id == window.Color.Id &&
             item.UnitPrice == window.UnitPrice &&
             item.Model.Id == window.Model.Id
         );

            if (existingItem.Quantity != 0)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItems.Add(window);
            }

            NotifyCartUpdated();

            NotifyCartUpdated();
        }

        public void DecreaseWindowInCart(Window window)
        {
            var existingItem = CartItems.FirstOrDefault(item =>
                item.Height == window.Height &&
                item.Width == window.Width &&
                item.Color.Id == window.Color.Id &&
                item.UnitPrice == window.UnitPrice &&
                item.Model.Id == window.Model.Id
            );

            if (existingItem.Quantity >= 2)
            {
                existingItem.Quantity--;
            }
            else 
            {
                CartItems.Remove(window);
            }

            NotifyCartUpdated();
        }

        public void AddWindowToCart(Window window)
        {
            var existingItem = CartItems.FirstOrDefault(item =>
                item.Height == window.Height &&
                item.Width == window.Width &&
                item.Color.Id == window.Color.Id &&
                item.UnitPrice == window.UnitPrice &&
                item.Model.Id == window.Model.Id
            );

            if (existingItem != null)
            {
                existingItem.Quantity += window.Quantity;
            }
            else
            {
                CartItems.Add(window);
            }

            NotifyCartUpdated();
        }

        public int GetCartSum() 
        {
            int sum= 0;
            foreach (var item in CartItems) 
            { 
                sum += item.Quantity * item.UnitPrice;

            }
            return sum;
        }
        public List<Window> GetCartItems()
        {
            return CartItems;
        }

        public int GetCartQuantity()
        {
            int quantity = 0;
            foreach (var item in CartItems) 
            { 
                quantity += item.Quantity;
            }
            return quantity;
         
        }

   
    }
}
