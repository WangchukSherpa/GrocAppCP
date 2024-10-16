using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjWork.Entities.User;

namespace ProjWork.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x=>x.Email).IsUnique();
            builder.HasOne(u => u.Address)
               .WithMany()   // Address does not have a collection of Users
               .HasForeignKey(u => u.AddressId)  // Foreign key in User pointing to Address
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
