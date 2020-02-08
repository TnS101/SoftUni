namespace WebApplication1.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public decimal Check { get; set; }
    }
}
