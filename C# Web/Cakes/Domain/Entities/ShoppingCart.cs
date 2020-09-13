namespace Domain.Entities
{
    public class ShoppingCart
    {
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int CakeId { get; set; }

        public Cake Cake { get; set; }

        public int Count { get; set; }
    }
}
