using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjWork.Entities.Order;

namespace ProjWork.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(i => i.ItemOrdered, io =>
            {
                io.WithOwner();
                // Explicitly map the properties
                io.Property(x => x.ProductItemId).IsRequired();
                io.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
                io.Property(x => x.PictureUrl).HasMaxLength(255);
            });

            builder.Property(i => i.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(i => i.Quantity)
                .IsRequired();
        }
    }
}