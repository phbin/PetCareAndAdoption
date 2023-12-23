using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class UpdateRemoveAddressPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "district",
                table: "MyPets");

            migrationBuilder.DropColumn(
                name: "province",
                table: "MyPets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "MyPets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "province",
                table: "MyPets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
