using ECommerceApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
 
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public async Task<IActionResult> GetProducts(
            [FromQuery] string? search, 
            [FromQuery] int? categoryId)
        {

            var query = _context.Products.Include(p => p.Category).AsQueryable();
 
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => 
                    p.Name.Contains(search) || 
                    p.Description.Contains(search)
                );
            }

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }
 
            var products = await query.ToListAsync();
            return Ok(products);
        }
    }
}