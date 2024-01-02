using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockDAL.Migrations
{
    /// <inheritdoc />
    public partial class intialWithSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "PO Box 11621", "Tech Oasis" },
                    { 2, "PO Box 29634", "E-Store Express" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Price", "Quantity", "StoreId" },
                values: new object[,]
                {
                    { 1, "TV", 200m, 50, 1 },
                    { 2, "Mobile", 150m, 100, 2 },
                    { 3, "Tablet", 200m, 50, 2 },
                    { 4, "Microwave", 180m, 30, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_StoreId",
                table: "Items",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
