using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
<<<<<<< HEAD
using ProjWork.Model;
=======
using ProjWork.Entities.Basket;
>>>>>>> a39f4f9b259a1733d0a9c5e04c29cdfa27f7a4aa

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
<<<<<<< HEAD
            .OnDelete(DeleteBehavior.Cascade); // Optional: Define delete behavior
=======
            .OnDelete(DeleteBehavior.Cascade); 
>>>>>>> a39f4f9b259a1733d0a9c5e04c29cdfa27f7a4aa
        }
    }
}
