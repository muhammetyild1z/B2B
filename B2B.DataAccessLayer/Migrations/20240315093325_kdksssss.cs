using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class kdksssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "StockID",
                table: "productPrices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productPrices_StockID",
                table: "productPrices",
                column: "StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_productPrices_stock_StockID",
                table: "productPrices",
                column: "StockID",
                principalTable: "stock",
                principalColumn: "StockID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productPrices_stock_StockID",
                table: "productPrices");

            migrationBuilder.DropIndex(
                name: "IX_productPrices_StockID",
                table: "productPrices");

            migrationBuilder.DropColumn(
                name: "StockID",
                table: "productPrices");

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
    }
}
