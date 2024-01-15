using GraphQLHotChocolateAPI.Context;
using GraphQLHotChocolateAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphQLHotChocolateAPI.Queries
{
    public class ProductData
    {
        private readonly databaseContext _context;

        public ProductData(databaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductInfo>> GetProducts()
        {
            var data = await _context.ProductInfo.AsNoTracking().ToListAsync();
            return data;
        }
    }
}
