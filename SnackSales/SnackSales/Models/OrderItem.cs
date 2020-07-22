namespace SnackSales.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SnackId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public virtual Snack Snack { get; set; }
        public virtual Order Order { get; set; }
    }
}