using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class AddSpeciesBreedsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    speciesID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    speciesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.speciesID);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    breedID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    speciesID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    breedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.breedID);
                    table.ForeignKey(
                        name: "FK_Breeds_Species_speciesID",
                        column: x => x.speciesID,
                        principalTable: "Species",
                        principalColumn: "speciesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_speciesID",
                table: "Breeds",
                column: "speciesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
