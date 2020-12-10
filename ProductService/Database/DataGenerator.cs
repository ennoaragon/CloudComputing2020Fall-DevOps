
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProductDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ProductDbContext>>()))
        {
            if (context.Products.Any())
            {
                return; // Data was already seeded
            }

            context.Products.AddRange(
                new Product
                {
                    ProductId = 1,
                    Name = "Product 1",
                    Price = 19.95m,
                    Count = 514
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Product 2",
                    Price = 2099.95m,
                    Count = 101
                }
            );

            context.SaveChanges();
        }
    }
}