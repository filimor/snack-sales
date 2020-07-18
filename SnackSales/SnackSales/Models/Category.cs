using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SnackSales.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public List<Snack> Snacks { get; set; }
    }
}