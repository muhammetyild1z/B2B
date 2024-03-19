using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class kdkss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baskets_AspNetUsers_UserID",
                table: "baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets");

            migrationBuilder.AddColumn<int>(
                name: "StockID",
                table: "baskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_baskets_StockID",
                table: "baskets",
                column: "StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_AspNetUsers_UserID",
                table: "baskets",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets",
                column: "PriceID",
                principalTable: "productPrices",
                principalColumn: "PriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_stock_StockID",
                table: "baskets",
                column: "StockID",
                principalTable: "stock",
                principalColumn: "StockID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baskets_AspNetUsers_UserID",
                table: "baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_baskets_stock_StockID",
                table: "baskets");

            migrationBuilder.DropIndex(
                name: "IX_baskets_StockID",
                table: "baskets");

            migrationBuilder.DropColumn(
                name: "StockID",
                table: "baskets");

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_AspNetUsers_UserID",
                table: "baskets",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets",
                column: "PriceID",
                principalTable: "productPrices",
                principalColumn: "PriceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
