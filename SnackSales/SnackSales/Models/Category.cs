using System.Collections.Generic;

namespace SnackSales.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Snack> Snacks { get; set; }
    }
}