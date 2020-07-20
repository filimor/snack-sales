using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnackSales.Context;

namespace SnackSales.Models
{
    public class Cart
    {
        private readonly AppDbContext _context;

        public Cart(AppDbContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            // Define a Session accessing the current context (remember to register it in IServicesContext
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Get a service of a type context
            var context = services.GetService<AppDbContext>();

            // Get or set the Cart Id
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            // Set the session Cart Id
            session.SetString("CartId", cartId);

            // Return the Cart with the current context and id assigned
            return new Cart(context) {Id = cartId};
        }

        public void AddItem(Snack snack, int amount)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s => s.Snack.Id == snack.Id && s.CartId == Id);

            // Create a Cart if necessary, otherwise increase amount
            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    CartId = Id,
                    Snack = snack,
                    Amount = amount
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount += amount;
            }
        }

        public int RemoveItem(Snack snack)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s => s.Snack.Id == snack.Id && s.CartId == Id);

            var localAmount = 0;

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                    localAmount = cartItem.Amount;
                }
                else
                {
                    _context.CartItems.Remove(cartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ??= _context.CartItems.Where(
                    c => c.CartId == Id).Include(s => s.Snack).ToList();
        }

        public void ClearCart()
        {
            var cartItems = _context.CartItems.Where(
                c => c.CartId == Id);
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetTotalValue()
        {
            return _context.CartItems.Where(c => c.CartId == Id).Select(c => c.Snack.Price * c.Amount).Sum();
        }
    }
}