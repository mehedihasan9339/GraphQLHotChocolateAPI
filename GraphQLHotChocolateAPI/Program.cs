using GraphQLHotChocolateAPI.Context;
using GraphQLHotChocolateAPI.Mutations;
using GraphQLHotChocolateAPI.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext with a scoped lifetime (default behavior)
builder.Services.AddDbContext<databaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProductData>();
builder.Services.AddScoped<ProductMutations>();

// Add GraphQL server and register ProductData as query root
builder.Services
    .AddGraphQLServer()
    .AddQueryType<ProductData>()
    .AddMutationType<ProductMutations>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.MapGraphQL("/graphql");

app.Run();
