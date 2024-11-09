using GraphQLHotChocolateAPI.Context;
using GraphQLHotChocolateAPI.Data;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GraphQLHotChocolateAPI.Queries
{
    public class ProductData
    {
        private readonly databaseContext _context;

        // Ensure that context is injected correctly through constructor
        public ProductData(databaseContext context)
        {
            _context = context;
        }

        // This should be fine, as it’s still within the scope of the request
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<ProductInfo> fetchAllProducts()
        {
            var data = _context.ProductInfo.AsNoTracking().ToList();
            return data;
        }
    }
}
