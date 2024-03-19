using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class kdksss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_colors_ColorID",
                table: "stock");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_dimensions_DimensionsID",
                table: "stock");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_products_ProductID",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "IX_stock_ColorID",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "IX_stock_DimensionsID",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "IX_stock_ProductID",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "DimensionsID",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "stock");

            migrationBuilder.AddColumn<int>(
                name: "PriceID",
                table: "stock",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_PriceID",
                table: "stock",
                column: "PriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_productPrices_PriceID",
                table: "stock",
                column: "PriceID",
                principalTable: "productPrices",
                principalColumn: "PriceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_productPrices_PriceID",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "IX_stock_PriceID",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "PriceID",
                table: "stock");

            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DimensionsID",
                table: "stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_stock_ColorID",
                table: "stock",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_stock_DimensionsID",
                table: "stock",
                column: "DimensionsID");

            migrationBuilder.CreateIndex(
                name: "IX_stock_ProductID",
                table: "stock",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_colors_ColorID",
                table: "stock",
                column: "ColorID",
                principalTable: "colors",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_dimensions_DimensionsID",
                table: "stock",
                column: "DimensionsID",
                principalTable: "dimensions",
                principalColumn: "DimensionsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_products_ProductID",
                table: "stock",
                column: "ProductID",
                principalTable: "products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
