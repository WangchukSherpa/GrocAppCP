using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjWork.Model;

namespace ProjWork.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p=>p.MfgDate).IsRequired();
            builder.Property(p=>p.ExpDate).IsRequired();
            builder.HasOne(b => b.ProductBrand)
                .WithMany().HasForeignKey(p => p.ProductBrandId);

            builder.HasOne(b => b.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
            //product has one brand and one type
            //one product brand has many product
            //one product type has many product 
        }
    }
}
