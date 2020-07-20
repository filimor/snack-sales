using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SnackSales.Context;
using SnackSales.Models;

namespace SnackSales.Repositories
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;

        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Snack> Snacks => _context.Snacks.Include(c => c.Category);
        public IEnumerable<Snack> FavoriteSnacks => _context.Snacks.Where(f => f.Favorite).Include(c => c.Category);

        public Snack GetSnackById(int snackId)
        {
            return _context.Snacks.FirstOrDefault(s => s.Id == snackId);
        }
    }
}