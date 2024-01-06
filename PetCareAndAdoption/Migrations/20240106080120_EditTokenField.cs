using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class EditTokenField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "token",
                table: "UserInfo");

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    tokenID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.tokenID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
