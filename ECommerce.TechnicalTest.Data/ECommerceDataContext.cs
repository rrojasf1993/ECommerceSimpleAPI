using ECommerce.TechnicalTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.TechnicalTest.Data;

public class ECommerceTechnicalTestDataContext:DbContext
{
      public ECommerceTechnicalTestDataContext(DbContextOptions<ECommerceTechnicalTestDataContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItemDetail> OrderItemDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string schema = "C##ECOMMERCE";
            
            //Initial data seed
            modelBuilder.Seed();
            
            modelBuilder.Entity<Order>().ToTable("ORDERS", schema);
            modelBuilder.Entity<OrderItemDetail>().ToTable("ORDER_ITEM_DETAILS", schema);
            modelBuilder.Entity<Product>().ToTable("PRODUCTS", schema);

            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderItemDetail>()
                .Property(oi => oi.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderedItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItemDetails)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItemDetail>()
                .Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    
    }
