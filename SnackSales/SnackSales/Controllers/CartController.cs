using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnackSales.Models;
using SnackSales.Repositories;
using SnackSales.ViewModels;

namespace SnackSales.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly ISnackRepository _snackRepository;

        public CartController(ISnackRepository snackRepository, Cart cart)
        {
            _snackRepository = snackRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            _cart.CartItems = _cart.GetCartItems();
            var cartViewModel = new CartViewModel
            {
                Cart = _cart,
                TotalValue = _cart.GetTotalValue()
            };
            return View(cartViewModel);
        }

        public IActionResult AddToCart(int snackId)
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(s => s.Id == snackId);
            if (snack != null)
            {
                _cart.AddItem(snack, 1);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int snackId)
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(s => s.Id == snackId);
            if (snack != null)
            {
                _cart.RemoveItem(snack);
            }

            return RedirectToAction("Index");
        }
    }
}