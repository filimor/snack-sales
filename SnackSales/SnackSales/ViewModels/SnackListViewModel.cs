using System.Collections.Generic;
using SnackSales.Models;

namespace SnackSales.ViewModels
{
    public class SnackListViewModel
    {
        public IEnumerable<Snack> Snacks { get; set; }
        public string CurrentCategory { get; set; }
    }
}