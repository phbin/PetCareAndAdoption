using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class AddDataSpecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "6bab659d-e6a6-4188-8e3f-7206a0e83618", "Dog" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "983b11eb-8beb-432e-8d13-bb95c119d8ea", "Others" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "cd988331-7288-4ef4-be4d-ca59876c7cff", "Cat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "6bab659d-e6a6-4188-8e3f-7206a0e83618");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "983b11eb-8beb-432e-8d13-bb95c119d8ea");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "cd988331-7288-4ef4-be4d-ca59876c7cff");
        }
    }
}
