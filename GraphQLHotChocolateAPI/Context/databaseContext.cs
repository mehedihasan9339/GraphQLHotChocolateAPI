using GraphQLHotChocolateAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GraphQLHotChocolateAPI.Context
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options) : base(options)
        {
        }

        public DbSet<ProductInfo> ProductInfo { get; set; }

    }
}
