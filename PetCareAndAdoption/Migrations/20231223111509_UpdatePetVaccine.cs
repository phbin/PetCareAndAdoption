using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class UpdatePetVaccine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoryVaccine",
                columns: table => new
                {
                    historyVaccineID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    petID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryVaccine", x => x.historyVaccineID);
                });

            migrationBuilder.CreateTable(
                name: "NextVaccine",
                columns: table => new
                {
                    nextVaccineID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    petID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextVaccine", x => x.nextVaccineID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryVaccine");

            migrationBuilder.DropTable(
                name: "NextVaccine");
        }
    }
}
