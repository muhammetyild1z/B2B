using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class dsfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_productPrices_PriceID",
                table: "productCategories");

            migrationBuilder.RenameColumn(
                name: "PriceID",
                table: "productCategories",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_productCategories_PriceID",
                table: "productCategories",
                newName: "IX_productCategories_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_productPrices_ProductID",
                table: "productCategories",
                column: "ProductID",
                principalTable: "productPrices",
                principalColumn: "PriceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_productPrices_ProductID",
                table: "productCategories");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "productCategories",
                newName: "PriceID");

            migrationBuilder.RenameIndex(
                name: "IX_productCategories_ProductID",
                table: "productCategories",
                newName: "IX_productCategories_PriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_productPrices_PriceID",
                table: "productCategories",
                column: "PriceID",
                principalTable: "productPrices",
                principalColumn: "PriceID");
        }
    }
}
