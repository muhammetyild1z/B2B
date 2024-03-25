using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class dsfso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_productPrices_ProductID",
                table: "productCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_products_ProductID",
                table: "productCategories",
                column: "ProductID",
                principalTable: "products",
                principalColumn: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_products_ProductID",
                table: "productCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_productPrices_ProductID",
                table: "productCategories",
                column: "ProductID",
                principalTable: "productPrices",
                principalColumn: "PriceID");
        }
    }
}
