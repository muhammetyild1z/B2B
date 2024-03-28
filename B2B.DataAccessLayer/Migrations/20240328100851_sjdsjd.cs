using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sjdsjd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_productPrices_stock_StockID",
                table: "productPrices");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropIndex(
                name: "IX_productPrices_StockID",
                table: "productPrices");

            migrationBuilder.DropColumn(
                name: "StockID",
                table: "productPrices");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "productPrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets",
                column: "PriceID",
                principalTable: "productPrices",
                principalColumn: "PriceID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "productPrices");

            migrationBuilder.AddColumn<int>(
                name: "StockID",
                table: "productPrices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    StockID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.StockID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productPrices_StockID",
                table: "productPrices",
                column: "StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_baskets_productPrices_PriceID",
                table: "baskets",
                column: "PriceID",
                principalTable: "productPrices",
                principalColumn: "PriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_productPrices_stock_StockID",
                table: "productPrices",
                column: "StockID",
                principalTable: "stock",
                principalColumn: "StockID");
        }
    }
}
