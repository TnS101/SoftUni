namespace Persistance.Configurations
{
    using Domain.Entities;
    using FluentValidation;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CommentId)
                .IsRequired();
        }
    }
}
