using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjWork.Entities.Basket;

namespace ProjWork.Configuration
{
    public class CustomersBasketConfiguration : IEntityTypeConfiguration<CustomersBasket>
    {
        public void Configure(EntityTypeBuilder<CustomersBasket> builder)
        {
            builder.Property(b => b.Id).IsRequired(); // Ensure that Id is required
            builder.HasMany(b => b.Items) // One CustomersBasket has many BasketItems
            .WithOne(i => i.CustomersBasket) // Each BasketItem has one CustomersBasket
            .HasForeignKey(i => i.CustomersBasketId) // Foreign key in BasketItem
            .OnDelete(DeleteBehavior.Cascade); 
            //SQL=>Redis 
        }
    }
}
