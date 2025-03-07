using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductContext context, ILogger<ProductController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        // GET: api/products
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                await Task.Delay(1000);
                List<Product> products = new List<Product>();
                products.Add(
                    new Product
                    {
                        Id = "1",  // Assuming Id is a string and is unique
                        Name = "Hard-coded Product 1",
                        Category = "Category A",
                        Description = "Description of Product 1 " + ex.Message,
                        ImageFile = "product1.jpg",
                        Price = 100
                    });
                products.Add(new Product
                {
                    Id = "2",
                    Name = "Hard-coded Product 2",
                    Category = "Category B",
                    Description = "Description of Product 2 " + ex.Message,
                    ImageFile = "product2.jpg",
                    Price = 200
                });
                products.Add(new Product
                {
                    Id = "3",
                    Name = "Hard-coded Product 3",
                    Category = "Category C",
                    Description = "Description of Product 3 " + ex.Message,
                    ImageFile = "product3.jpg",
                    Price = 300
                });
                return products.ToList();
            }
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}
