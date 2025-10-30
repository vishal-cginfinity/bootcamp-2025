using Microsoft.AspNetCore.Mvc;
using MyWebApiProject.Models;

namespace MyWebApiProject.controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private static List<Product> Products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 999.99m},
                new Product { Id = 2, Name = "Smartphone", Price = 499.99m},
                new Product { Id = 3, Name = "Headphones", Price = 199.99m}
            };

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(Products);
        }

        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            product.Id = Products.Count > 0 ? Products.Max(p => p.Id) + 1 : 1;
            Products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Products.Remove(product);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);


        }

        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return Ok(product);
        }
    }
} 
