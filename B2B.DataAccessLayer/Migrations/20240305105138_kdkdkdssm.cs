using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class kdkdkdssm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dimensions",
                columns: table => new
                {
                    DimensionsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    En = table.Column<int>(type: "int", nullable: false),
                    Boy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dimensions", x => x.DimensionsID);
                });

            migrationBuilder.CreateTable(
                name: "productStocks",
                columns: table => new
                {
                    ProductStockID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productStocks", x => new { x.ProductStockID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_productStocks_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productdimensions",
                columns: table => new
                {
                    ProductdimensionsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    DimensionsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productdimensions", x => x.ProductdimensionsID);
                    table.ForeignKey(
                        name: "FK_productdimensions_dimensions_DimensionsID",
                        column: x => x.DimensionsID,
                        principalTable: "dimensions",
                        principalColumn: "DimensionsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productdimensions_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productdimensions_DimensionsID",
                table: "productdimensions",
                column: "DimensionsID");

            migrationBuilder.CreateIndex(
                name: "IX_productdimensions_ProductID",
                table: "productdimensions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_productStocks_ProductID",
                table: "productStocks",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productdimensions");

            migrationBuilder.DropTable(
                name: "productStocks");

            migrationBuilder.DropTable(
                name: "dimensions");
        }
    }
}
