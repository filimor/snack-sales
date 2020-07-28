using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnackSales.Models
{
    public class Snack
    {
        public int Id { get; set; }

        [StringLength(100)] public string Name { get; set; }

        [StringLength(100)] public string ShortDescription { get; set; }

        [StringLength(255)] public string LongDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }

        [StringLength(200)] public string ImageUrl { get; set; }

        [StringLength(200)] public string ThumbnailUrl { get; set; }

        public bool Favorite { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}