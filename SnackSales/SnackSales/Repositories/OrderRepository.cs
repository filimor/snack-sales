using System;
using SnackSales.Context;
using SnackSales.Models;

namespace SnackSales.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Cart _cart;
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.ShipmentDate = DateTime.Now;
            _context.Orders.Add(order);

            var cartItems = _cart.GetCartItems();
            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    Amount = cartItem.Amount,
                    SnackId = cartItem.Snack.Id,
                    OrderId = order.Id,
                    Price = cartItem.Snack.Price
                };

                _context.OrderItems.Add(orderItem);
            }

            _context.SaveChanges();
        }
    }
}