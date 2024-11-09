namespace GraphQLHotChocolateAPI.Inputs
{
    public class ProductInput
    {
        public string? Name { get; set; }   // Product name (provided by the client)
        public string? Code { get; set; }   // Product code (provided by the client)
        public string? Sku { get; set; }    // Product SKU (provided by the client)
        public string? Qty { get; set; }    // Quantity of the product (provided by the client)
        public string? Stock { get; set; }  // Stock status (provided by the client)
    }
}
