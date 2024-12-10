using EcomPortal.Models.Entities;
using System.Data.Entity;

namespace EcomPortal.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=EcomDB") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });
        }
    }
}
