using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class AddDataBreeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "0656e083-0979-489b-8326-1f373d058246", "Cat" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "c9bbfad5-8140-4e81-bb87-75456d8ac9a1", "Dog" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "d12deb4e-e07d-4178-8e46-0ef65811353d", "Others" });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "breedID", "breedName", "speciesID" },
                values: new object[,]
                {
                    { "1cdb0b79-c5ed-4c69-9426-b0f4b6ee90b7", "Fish", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "1d9948ac-c287-4dc2-a460-5c2d3e76abd5", "Rabbit", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "265b4eea-33b8-4387-b52d-55b7494e9aef", "Hamster", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "3555ee7c-b574-4d73-aef8-8df67a11ce6a", "Others", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "44a9c2c2-6900-4090-9601-7b505987a57c", "Tortoise", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "514d6676-cc8f-4bdb-95fa-272e23b7759a", "Monkey", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "692ef102-e320-4f14-8a2d-d9ef6ffcaba7", "Snake", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "6a06df46-3a91-4db7-83c5-ad8e419b2511", "Chicken", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "aac59a3b-a513-42da-a334-9c31aaf7b945", "Turtle", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "cb233460-d4bc-4422-a890-3710e5d08f03", "Bird", "d12deb4e-e07d-4178-8e46-0ef65811353d" },
                    { "dccc78d1-63c4-49fc-97a9-41ba98684843", "Hedgehog", "d12deb4e-e07d-4178-8e46-0ef65811353d" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "1cdb0b79-c5ed-4c69-9426-b0f4b6ee90b7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "1d9948ac-c287-4dc2-a460-5c2d3e76abd5");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "265b4eea-33b8-4387-b52d-55b7494e9aef");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "3555ee7c-b574-4d73-aef8-8df67a11ce6a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "44a9c2c2-6900-4090-9601-7b505987a57c");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "514d6676-cc8f-4bdb-95fa-272e23b7759a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "692ef102-e320-4f14-8a2d-d9ef6ffcaba7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "6a06df46-3a91-4db7-83c5-ad8e419b2511");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "aac59a3b-a513-42da-a334-9c31aaf7b945");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "cb233460-d4bc-4422-a890-3710e5d08f03");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "dccc78d1-63c4-49fc-97a9-41ba98684843");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "0656e083-0979-489b-8326-1f373d058246");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "c9bbfad5-8140-4e81-bb87-75456d8ac9a1");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "d12deb4e-e07d-4178-8e46-0ef65811353d");

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
    }
}
