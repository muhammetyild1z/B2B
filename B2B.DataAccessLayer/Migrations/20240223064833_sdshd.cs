using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sdshd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "parentSubCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "parentSubCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "homeSliders",
                columns: table => new
                {
                    SliderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SliderTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homeSliders", x => x.SliderID);
                    table.ForeignKey(
                        name: "FK_homeSliders_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_homeSliders_ProductID",
                table: "homeSliders",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "homeSliders");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "parentSubCategories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "parentSubCategories");
        }
    }
}
