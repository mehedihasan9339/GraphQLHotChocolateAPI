using GraphQLHotChocolateAPI.Context;
using GraphQLHotChocolateAPI.Data;
using GraphQLHotChocolateAPI.Inputs;

namespace GraphQLHotChocolateAPI.Mutations
{
    public class ProductMutations
    {
        private readonly databaseContext _context;

        public ProductMutations(databaseContext context)
        {
            _context = context;
        }

        public async Task<ProductInfo> CreateProduct(ProductInput input)
        {
            var newProduct = new ProductInfo
            {
                name = input.Name,
                code = input.Code,
                sku = input.Sku,
                qty = input.Qty,
                stock = input.Stock
            };

            _context.ProductInfo.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<ProductInfo> UpdateProduct(int id, ProductInput input)
        {
            var product = await _context.ProductInfo.FindAsync(id);
            if (product == null) return null;

            product.name = input.Name ?? product.name;
            product.code = input.Code ?? product.code;
            product.sku = input.Sku ?? product.sku;
            product.qty = input.Qty ?? product.qty;
            product.stock = input.Stock ?? product.stock;

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.ProductInfo.FindAsync(id);
            if (product == null) return false;

            _context.ProductInfo.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
