using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class kdkssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_baskets_stock_StockID",
                table: "baskets");

            migrationBuilder.DropIndex(
                name: "IX_baskets_StockID",
                table: "baskets");

            migrationBuilder.DropColumn(
                name: "StockID",
                table: "baskets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_baskets_stock_StockID",
                table: "baskets",
                column: "StockID",
                principalTable: "stock",
                principalColumn: "StockID");
        }
    }
}
