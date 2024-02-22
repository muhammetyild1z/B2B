using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sdlksd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aLL_SPECODEs");

            migrationBuilder.DropTable(
                name: "sPECODE1s");

            migrationBuilder.DropTable(
                name: "sPECODE2s");

            migrationBuilder.DropTable(
                name: "sPECODE3s");

            migrationBuilder.DropTable(
                name: "sPECODE4s");

            migrationBuilder.DropTable(
                name: "sPECODEs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sPECODE1s",
                columns: table => new
                {
                    SPECODE1_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SPECODE1_Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SPECODE1_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sPECODE1s", x => x.SPECODE1_ID);
                });

            migrationBuilder.CreateTable(
                name: "sPECODE2s",
                columns: table => new
                {
                    SPECODE2_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SPECODE2_Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SPECODE2_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sPECODE2s", x => x.SPECODE2_ID);
                });

            migrationBuilder.CreateTable(
                name: "sPECODE3s",
                columns: table => new
                {
                    SPECODE3_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SPECODE3_Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SPECODE3_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sPECODE3s", x => x.SPECODE3_ID);
                });

            migrationBuilder.CreateTable(
                name: "sPECODE4s",
                columns: table => new
                {
                    SPECODE4_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SPECODE4_Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SPECODE4_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sPECODE4s", x => x.SPECODE4_ID);
                });

            migrationBuilder.CreateTable(
                name: "sPECODEs",
                columns: table => new
                {
                    SPECODE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SPECODE_Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SPECODE_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sPECODEs", x => x.SPECODE_ID);
                });

            migrationBuilder.CreateTable(
                name: "aLL_SPECODEs",
                columns: table => new
                {
                    All_SpCode_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpCode_ID = table.Column<int>(type: "int", nullable: false),
                    SpCode1_ID = table.Column<int>(type: "int", nullable: true),
                    SpCode2_ID = table.Column<int>(type: "int", nullable: true),
                    SpCode3_ID = table.Column<int>(type: "int", nullable: true),
                    SpCode4_ID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aLL_SPECODEs", x => x.All_SpCode_ID);
                    table.ForeignKey(
                        name: "FK_aLL_SPECODEs_sPECODE1s_SpCode1_ID",
                        column: x => x.SpCode1_ID,
                        principalTable: "sPECODE1s",
                        principalColumn: "SPECODE1_ID");
                    table.ForeignKey(
                        name: "FK_aLL_SPECODEs_sPECODE2s_SpCode2_ID",
                        column: x => x.SpCode2_ID,
                        principalTable: "sPECODE2s",
                        principalColumn: "SPECODE2_ID");
                    table.ForeignKey(
                        name: "FK_aLL_SPECODEs_sPECODE3s_SpCode3_ID",
                        column: x => x.SpCode3_ID,
                        principalTable: "sPECODE3s",
                        principalColumn: "SPECODE3_ID");
                    table.ForeignKey(
                        name: "FK_aLL_SPECODEs_sPECODE4s_SpCode4_ID",
                        column: x => x.SpCode4_ID,
                        principalTable: "sPECODE4s",
                        principalColumn: "SPECODE4_ID");
                    table.ForeignKey(
                        name: "FK_aLL_SPECODEs_sPECODEs_SpCode_ID",
                        column: x => x.SpCode_ID,
                        principalTable: "sPECODEs",
                        principalColumn: "SPECODE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aLL_SPECODEs_SpCode_ID",
                table: "aLL_SPECODEs",
                column: "SpCode_ID");

            migrationBuilder.CreateIndex(
                name: "IX_aLL_SPECODEs_SpCode1_ID",
                table: "aLL_SPECODEs",
                column: "SpCode1_ID");

            migrationBuilder.CreateIndex(
                name: "IX_aLL_SPECODEs_SpCode2_ID",
                table: "aLL_SPECODEs",
                column: "SpCode2_ID");

            migrationBuilder.CreateIndex(
                name: "IX_aLL_SPECODEs_SpCode3_ID",
                table: "aLL_SPECODEs",
                column: "SpCode3_ID");

            migrationBuilder.CreateIndex(
                name: "IX_aLL_SPECODEs_SpCode4_ID",
                table: "aLL_SPECODEs",
                column: "SpCode4_ID");
        }
    }
}
