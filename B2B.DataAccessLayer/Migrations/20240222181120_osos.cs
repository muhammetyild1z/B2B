using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class osos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_childSubCategories_parentSubCategories_ParentSubCategoryID",
                table: "childSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_parentSubCategories_categories_CategoryId",
                table: "parentSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_parentSubCategories_CategoryId",
                table: "parentSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_childSubCategories_ParentSubCategoryID",
                table: "childSubCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "parentSubCategories");

            migrationBuilder.DropColumn(
                name: "ParentSubCategoryID",
                table: "childSubCategories");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "productCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_ProductID",
                table: "productCategories",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_products_ProductID",
                table: "productCategories",
                column: "ProductID",
                principalTable: "products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_products_ProductID",
                table: "productCategories");

            migrationBuilder.DropIndex(
                name: "IX_productCategories_ProductID",
                table: "productCategories");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "productCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "parentSubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentSubCategoryID",
                table: "childSubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_parentSubCategories_CategoryId",
                table: "parentSubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_childSubCategories_ParentSubCategoryID",
                table: "childSubCategories",
                column: "ParentSubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_childSubCategories_parentSubCategories_ParentSubCategoryID",
                table: "childSubCategories",
                column: "ParentSubCategoryID",
                principalTable: "parentSubCategories",
                principalColumn: "ParentSubCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_parentSubCategories_categories_CategoryId",
                table: "parentSubCategories",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
