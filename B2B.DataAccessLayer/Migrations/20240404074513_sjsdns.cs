using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sjsdns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductPriceID",
                table: "productCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_ProductPriceID",
                table: "productCategories",
                column: "ProductPriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_productPrices_ProductPriceID",
                table: "productCategories",
                column: "ProductPriceID",
                principalTable: "productPrices",
                principalColumn: "PriceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_productPrices_ProductPriceID",
                table: "productCategories");

            migrationBuilder.DropIndex(
                name: "IX_productCategories_ProductPriceID",
                table: "productCategories");

            migrationBuilder.DropColumn(
                name: "ProductPriceID",
                table: "productCategories");
        }
    }
}
