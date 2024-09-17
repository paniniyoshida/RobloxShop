using Microsoft.EntityFrameworkCore;
using RobloxShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobloxShop.Repository
{
    public class ShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Check> Checks { get; set; }

        public DbSet<CheckPosition> CheckPositions { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentProvider> PaymentProviders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCart> ProductCarts { get; set; }

        public DbSet<ProductCartItem> ProductCartItems { get; set; }

        public DbSet<Promocode> Promocodes { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WarehouseStock> WarehouseStocks { get; set; }

        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public ShopContext()
        {
            Database.EnsureCreated();
        }
    }
}
