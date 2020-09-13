namespace Domain.Entities
{
    public class CustomerCakes
    {
        public string CustomId { get; set; }

        public Customer Customer { get; set; }

        public int CakeId { get; set; }

        public Cake Cake { get; set; }
    }
}
