namespace fuzzy.core.Models
{
    public class OrderDetails
    {
        public int ProductId { get; set; }

        public string CustomerID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int Id { get; set; }
    }
}
