using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for the Products table
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "1",  // Assuming Id is a string and is unique
                    Name = "Product 1",
                    Category = "Category A",
                    Description = "Description of Product 1",
                    ImageFile = "product1.jpg",
                    Price = 100
                },
                new Product
                {
                    Id = "2",
                    Name = "Product 2",
                    Category = "Category B",
                    Description = "Description of Product 2",
                    ImageFile = "product2.jpg",
                    Price = 200
                },
                new Product
                {
                    Id = "3",
                    Name = "Product 3",
                    Category = "Category C",
                    Description = "Description of Product 3",
                    ImageFile = "product3.jpg",
                    Price = 300
                }
            );
        }
    }
}
