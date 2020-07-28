using Microsoft.AspNetCore.Mvc;
using SnackSales.Models;
using SnackSales.ViewModels;

namespace SnackSales.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummary(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            _cart.CartItems = _cart.GetCartItems();

            var cartViewModel = new CartViewModel
            {
                Cart = _cart,
                TotalValue = _cart.GetTotalValue()
            };
            return View(cartViewModel);
        }
    }
}