using Microsoft.EntityFrameworkCore;
using RealPage.Properties.Domain.Entity;
using RealPage.Properties.Infrastructure.Interface;

namespace RealPage.Properties.Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext, IApplicationDBContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public ApplicationDbContext()
        {

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityConfig.SetEntityBuilder(modelBuilder.Entity<Property>());
            EntityConfig.SetEntityBuilder(modelBuilder.Entity<User>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
