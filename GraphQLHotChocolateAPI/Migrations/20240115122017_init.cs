using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLHotChocolateAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stock = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInfo");
        }
    }
}
