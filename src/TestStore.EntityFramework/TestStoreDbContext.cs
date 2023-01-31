using Microsoft.EntityFrameworkCore;
using TestStore.Core.Entities;
using TestStore.Core.Interfaces.Data;
using TestStore.EntityFramework.ConfigurationProfiles;

namespace TestStore.EntityFramework
{
    public class TestStoreDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public TestStoreDbContext(DbContextOptions<TestStoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TestStoreDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductProfile());
            modelBuilder.ApplyConfiguration(new OrderProfile());
            modelBuilder.ApplyConfiguration(new OrderItemProfile());

            //Test data
            modelBuilder.Entity<Product>().HasData(new Product(1, "Soup", 0.65m));
            modelBuilder.Entity<Product>().HasData(new Product(2, "Bread", 0.80m));
            modelBuilder.Entity<Product>().HasData(new Product(3, "Milk", 1.15m));
            modelBuilder.Entity<Product>().HasData(new Product(4, "Apples", 1.00m));
        }

        public async Task<bool> Commit()
        {
            //Do other validations and updates, like soft deletes, creation time, last updated time, etc...
            return await base.SaveChangesAsync() > 0;
        }
    }
}
