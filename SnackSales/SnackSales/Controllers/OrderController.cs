using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SnackSales.Models;
using SnackSales.Repositories;

namespace SnackSales.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart _cart;
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _cart.CartItems = _cart.GetCartItems();

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("","Seu carrinho está vazio.");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                ViewBag.TotalValue = _cart.GetTotalValue();
                ViewBag.CompletedCheckoutMessage = "Obrigado pelo seu pedido :)";
                _cart.ClearCart();

                return View("~/Views/Order/CompletedCheckout.cshtml", order);
            }

            return View(order);
        }
    }
}