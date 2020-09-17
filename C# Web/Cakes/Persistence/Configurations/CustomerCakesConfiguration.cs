namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerCakesConfiguration : IEntityTypeConfiguration<CustomerCakes>
    {
        public void Configure(EntityTypeBuilder<CustomerCakes> builder)
        {
            builder.HasKey(k => new { k.CustomerId, k.CakeId });

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.CustomerCakes)
                .HasForeignKey(e => e.CustomerId);

            builder.HasOne(e => e.Cake)
                .WithMany(e => e.CustomerCakes)
                .HasForeignKey(e => e.CakeId);
        }
    }
}
