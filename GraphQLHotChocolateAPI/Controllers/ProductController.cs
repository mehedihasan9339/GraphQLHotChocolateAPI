using GraphQLHotChocolateAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolateAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly databaseContext _context;

        public ProductController(databaseContext context)
        {
            _context = context;
        }



        [HttpGet("/api/GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            var data = await _context.ProductInfo.AsNoTracking().ToListAsync();
            return Ok(data);
        }

    }
}
