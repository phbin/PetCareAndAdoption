using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class RemoveBirthdayUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                    name: "birthday",
                    table: "UserInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
