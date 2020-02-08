namespace Cakes.Utilities.Handlers
{
    using global::Cakes.Utilities.Cakes;

    public class CakeHandler
    {
        public CakeHandler()
        {
        }

        public BuyCake BuyCake { get; set; } = new BuyCake();

        public CreateCake CreateCake { get; set; } = new CreateCake();

        public RemoveAllCakes RemoveAllCakes { get; set; } = new RemoveAllCakes();

        public RemoveCake RemoveCake { get; set; } = new RemoveCake();
    }
}
