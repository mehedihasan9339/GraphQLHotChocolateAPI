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

        public ProductData(databaseContext context)
        {
            _context = context;
        }

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
