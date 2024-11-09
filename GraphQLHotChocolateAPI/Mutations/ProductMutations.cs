using GraphQLHotChocolateAPI.Context;
using GraphQLHotChocolateAPI.Data;
using GraphQLHotChocolateAPI.Inputs;  // Import the Inputs namespace
using HotChocolate;

namespace GraphQLHotChocolateAPI.Mutations
{
    public class ProductMutations
    {
        private readonly databaseContext _context;

        // Constructor to inject the database context
        public ProductMutations(databaseContext context)
        {
            _context = context;
        }

        // Mutation for creating a new product
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

            _context.ProductInfo.Add(newProduct); // Add the new product to the context
            await _context.SaveChangesAsync();    // Save changes to the database
            return newProduct;                    // Return the newly created product
        }

        // Mutation for updating an existing product by its ID
        public async Task<ProductInfo> UpdateProduct(int id, ProductInput input)
        {
            var product = await _context.ProductInfo.FindAsync(id);
            if (product == null) return null; // If the product does not exist, return null

            // Update the product properties only if the client provides new values
            product.name = input.Name ?? product.name;
            product.code = input.Code ?? product.code;
            product.sku = input.Sku ?? product.sku;
            product.qty = input.Qty ?? product.qty;
            product.stock = input.Stock ?? product.stock;

            await _context.SaveChangesAsync(); // Save changes to the database
            return product;                     // Return the updated product
        }

        // Mutation for deleting a product by its ID
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.ProductInfo.FindAsync(id);
            if (product == null) return false; // If the product doesn't exist, return false

            _context.ProductInfo.Remove(product); // Remove the product from the context
            await _context.SaveChangesAsync();    // Save changes to the database
            return true;                          // Return true indicating the deletion was successful
        }
    }
}
