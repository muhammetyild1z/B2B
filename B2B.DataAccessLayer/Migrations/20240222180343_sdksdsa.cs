using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sdksdsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Product_ID);
                });

            migrationBuilder.CreateTable(
                name: "parentSubCategories",
                columns: table => new
                {
                    ParentSubCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parentSubCategories", x => x.ParentSubCategoryID);
                    table.ForeignKey(
                        name: "FK_parentSubCategories_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "childSubCategories",
                columns: table => new
                {
                    ChildSubCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentSubCategoryID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_childSubCategories", x => x.ChildSubCategoryID);
                    table.ForeignKey(
                        name: "FK_childSubCategories_parentSubCategories_ParentSubCategoryID",
                        column: x => x.ParentSubCategoryID,
                        principalTable: "parentSubCategories",
                        principalColumn: "ParentSubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ParentSubCategoryID = table.Column<int>(type: "int", nullable: true),
                    ChildSubCategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => x.ProductCategoryID);
                    table.ForeignKey(
                        name: "FK_productCategories_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productCategories_childSubCategories_ChildSubCategoryID",
                        column: x => x.ChildSubCategoryID,
                        principalTable: "childSubCategories",
                        principalColumn: "ChildSubCategoryID");
                    table.ForeignKey(
                        name: "FK_productCategories_parentSubCategories_ParentSubCategoryID",
                        column: x => x.ParentSubCategoryID,
                        principalTable: "parentSubCategories",
                        principalColumn: "ParentSubCategoryID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_childSubCategories_ParentSubCategoryID",
                table: "childSubCategories",
                column: "ParentSubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_parentSubCategories_CategoryId",
                table: "parentSubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_CategoryID",
                table: "productCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_ChildSubCategoryID",
                table: "productCategories",
                column: "ChildSubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_ParentSubCategoryID",
                table: "productCategories",
                column: "ParentSubCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productCategories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "childSubCategories");

            migrationBuilder.DropTable(
                name: "parentSubCategories");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
