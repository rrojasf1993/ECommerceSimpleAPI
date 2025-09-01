using ECommerce.TechnicalTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.TechnicalTest.Data;

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Product> products = new List<Product>();
            for (int i = 1; i <= 30; i++)
            {
               products.Add(new Product
                {
                    Id = i, Name = $"Product_{i} ", Description = $"Description for product {i}", Price = i + 6,
                    StockQuantity = i + 100, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
                });
            }

            modelBuilder.Entity<Product>().HasData(
                         products);
        }
    }

