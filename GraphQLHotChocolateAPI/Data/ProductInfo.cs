using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLHotChocolateAPI.Data
{
    public class ProductInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public string? sku { get; set; }
        public string? qty { get; set; }
        public string? stock { get; set; }
    }
}
