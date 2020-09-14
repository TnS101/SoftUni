namespace Persistance.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Content)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(e => e.Category)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.CustomerId)
                .IsRequired();
        }
    }
}
