using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sjsjs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userFavoriLists_products_productID",
                table: "userFavoriLists");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "userFavoriLists",
                newName: "priceID");

            migrationBuilder.RenameIndex(
                name: "IX_userFavoriLists_productID",
                table: "userFavoriLists",
                newName: "IX_userFavoriLists_priceID");

            migrationBuilder.AddForeignKey(
                name: "FK_userFavoriLists_productPrices_priceID",
                table: "userFavoriLists",
                column: "priceID",
                principalTable: "productPrices",
                principalColumn: "PriceID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userFavoriLists_productPrices_priceID",
                table: "userFavoriLists");

            migrationBuilder.RenameColumn(
                name: "priceID",
                table: "userFavoriLists",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "IX_userFavoriLists_priceID",
                table: "userFavoriLists",
                newName: "IX_userFavoriLists_productID");

            migrationBuilder.AddForeignKey(
                name: "FK_userFavoriLists_products_productID",
                table: "userFavoriLists",
                column: "productID",
                principalTable: "products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
