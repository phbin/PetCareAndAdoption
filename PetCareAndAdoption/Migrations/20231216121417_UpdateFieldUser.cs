using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class UpdateFieldUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "address",
                table: "UserInfo",
                newName: "province");

            migrationBuilder.AddColumn<string>(
                name: "avatar",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "district",
                table: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "province",
                table: "UserInfo",
                newName: "address");
        }
    }
}
