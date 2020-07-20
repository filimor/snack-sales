using System.Collections.Generic;
using SnackSales.Models;

namespace SnackSales.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Snack> FavoriteSnacks { get; set; }
    }
}