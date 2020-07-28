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
                TempData["Customer"] = order.Name;
                TempData["OrderNumber"] = order.Id;
                TempData["OrderDate"] = order.ShipmentDate;
                TempData["TotalValue"] = _cart.GetTotalValue();
                _cart.ClearCart();

                return RedirectToAction("CompletedCheckout");
            }

            return View(order);
        }

        public IActionResult CompletedCheckout()
        {
            ViewBag.Customer = TempData["Customer"];
            ViewBag.OrderNumber = TempData["OrderNumber"];
            ViewBag.OrderDate = TempData["OrderDate"];
            ViewBag.TotalValue = TempData["TotalValue"];
            ViewBag.CompletedCheckoutMessage = "Obrigado pelo seu pedido :)";

            return View();
        }
    }
}