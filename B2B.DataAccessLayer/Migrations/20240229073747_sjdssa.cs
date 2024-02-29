using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class sjdssa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactMailRequests",
                columns: table => new
                {
                    ContactMailRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactMailRequests", x => x.ContactMailRequestID);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDesc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ContactAdress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ContactPhone1 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ContactPhone2 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ContactMail1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactMail2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.ContactID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactMailRequests");

            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
