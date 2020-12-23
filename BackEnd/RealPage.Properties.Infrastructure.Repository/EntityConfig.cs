using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealPage.Properties.Domain.Entity;

namespace RealPage.Properties.Infrastructure.Repository
{
    public class EntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Property> entityBuilder)
        {

            entityBuilder.ToTable("Property");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.State).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Type).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Location).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Area).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Contact).IsRequired().HasMaxLength(150);
            entityBuilder.Property(x => x.PhoneContact).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Price).IsRequired();

        }

        public static void SetEntityBuilder(EntityTypeBuilder<User> entityBuilder)
        {

            entityBuilder.ToTable("User");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.DateFrom).IsRequired();
            entityBuilder.Property(x => x.DateTo);

        }
    }
}
