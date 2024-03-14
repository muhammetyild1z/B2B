using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sjsc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceID",
                table: "baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_baskets_PriceID",
                table: "baskets",
                column: "PriceID");

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

            migrationBuilder.DropIndex(
                name: "IX_baskets_PriceID",
                table: "baskets");

            migrationBuilder.DropColumn(
                name: "PriceID",
                table: "baskets");
        }
    }
}
