namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(k => new { k.CustomerId, k.CakeId });

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.ShoppingCarts)
                .HasForeignKey(e => e.CustomerId);

            builder.HasOne(e => e.Cake)
                .WithMany(e => e.ShoppingCarts)
                .HasForeignKey(e => e.CakeId);
        }
    }
}
