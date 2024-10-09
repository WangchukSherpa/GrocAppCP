using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjWork.Entities.Basket;

namespace ProjWork.Configuration
{
    public class CustomersBasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(b => b.Price)
                    .HasPrecision(18, 2);
        }
    }
}
