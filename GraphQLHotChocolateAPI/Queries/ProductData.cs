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

        public List<ProductInfo> GetProducts()
        {
            var data = _context.ProductInfo.AsNoTracking().ToList();
            return data;
        }
    }
}
