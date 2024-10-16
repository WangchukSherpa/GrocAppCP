using Microsoft.EntityFrameworkCore;
using ProjWork.Entities;
using ProjWork.Entities.Basket;
using ProjWork.Entities.Order;
using ProjWork.Entities.User;



namespace ProjWork.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<CustomersBasket> CustomersBaskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderedItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        
        public DbSet<BasketItem> BasketItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //when we create the migration this is the
        //method This model is responsible for creating that migration
        {
            base.OnModelCreating(modelBuilder);//USer Prod 

            /* modelBuilder.Entity<Product>(entity =>
             {
                 entity.HasKey(p => p.Id);
                 entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                 entity.Property(p => p.Price).HasColumnType("decimal(18,2)");


                 entity.HasOne(p => p.ProductBrand)
                       .WithMany()
                       .HasForeignKey(p => p.ProductBrandId);

                 entity.HasOne(p => p.ProductType)
                       .WithMany()
                       .HasForeignKey(p => p.ProductTypeId);
             });*/
        }

    }
}
