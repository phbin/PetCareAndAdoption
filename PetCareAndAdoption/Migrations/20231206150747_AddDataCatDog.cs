using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCareAndAdoption.Migrations
{
    public partial class AddDataCatDog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1f174c8c-7c69-4674-b478-9f1fa9e958af", "Dog" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "6b35ea48-c99b-4731-99c0-95f263f4db3d", "Cat" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "speciesID", "speciesName" },
                values: new object[] { "7a9c0369-d114-49e3-abbb-33d7f05f1571", "Others" });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "breedID", "breedName", "speciesID" },
                values: new object[,]
                {
                    { "01ee0b80-60ec-468e-af15-4ab32f2022cb", "Basset Hound", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "0257502e-86f3-45fa-906d-79cc5fe1a3bd", "Snake", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "03577fed-0915-4787-952a-f21becec5ba1", "Labrador", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "0beab5f0-c8d2-4a71-aeba-c2004337ee11", "Exotic Shorthair", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "1ea3141f-d755-4200-9f84-cf5570329499", "Siamese", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "28ca6816-8afb-47c6-8612-f2f4eb8bbef5", "Beagle", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "378ae4ff-942d-42c8-a2f9-e0035427db5f", "Ragdoll", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "397efe80-c575-40b9-9829-d7aa1d6ec2d6", "Rabbit", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "3c3a57d8-1d1a-4397-b892-0f77cdcab827", "British Shorthair", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "456cc89a-e834-4955-9fb3-4832296a83a5", "Bengal", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "479eb831-f94a-4773-bc32-22043a2fdcde", "Boxer", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "49a547a3-e23c-449a-96c9-24aa48a95db6", "Cornish Rex", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "4dc1132c-665c-47a1-80db-1039abdb04da", "Maltese", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "4ee7649c-c733-42c2-9807-a4caad7d6ac8", "Siberian Husky", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "51a86e81-e0e2-4e08-a802-20ac246eed74", "Others", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "5a097716-d63c-45f9-8bf2-97525e706f64", "Poodle", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "601fac43-b412-4de0-84a3-798d32539aed", "Norwegian Forest", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "6796babd-fce8-4bdc-9a82-68eb47abcd96", "Oriental Shorthair", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "6838c16f-e06d-47cf-bc89-067886fe094d", "Devon Rex", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "6b4b80af-5f24-4b16-85ea-30900e502592", "Chihuahua", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "6c45540c-6736-4bbb-97f3-7b8b3884779f", "Fish", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "762b5768-d68a-4456-8f6c-0a840e721ce3", "Sphynx", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "77da7ca9-f883-4e5e-892d-0e94b54f8709", "Hedgehog", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "7cf7df56-0f72-4cf0-b4e5-77b4580b35e7", "Persian", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "807917dc-bd43-455f-bfd4-973e4cb2e31e", "Egyptian Mau", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "81da21ea-7837-4c0a-8ed9-00ffb1267237", "Tortoise", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "8710d68a-5981-4c0c-bf83-d7a1c7be1f58", "Maine Coon", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "8730de0e-254a-470c-9e74-58822f419d67", "Chicken", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "88608b6b-3dba-4983-bfa2-43e1bfce63d9", "Abyssinian", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "91ecb4ac-b379-4587-8360-d04cbb114d5d", "Bernese Mountain Dog", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "93bce8b5-3ca0-49d9-b795-f8bb6ab09566", "Shih Tzu", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "9bcb2138-4a16-4c9f-853a-27c31759236d", "German Shepherd", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "a15ca33c-4590-4063-8545-265574947210", "Russian Blue", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "a5cd329c-c35f-4384-9001-0f5fea03d935", "Shetland Sheepdog", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "ab3783c2-6c2d-4282-9e03-50a3a2b55744", "Bulldog", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "b6271f6e-9362-488f-8288-2e2e63231109", "Doberman Pinscher", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "b71faf1b-6b08-4608-968a-8bad374ec43f", "Dachshund", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "bc48283d-5e3f-4c7c-a31c-6b44ffc0d907", "Turtle", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "c887a8a4-5eb5-4a63-8a88-efe913c9e7fc", "Himalayan", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "c96f5f8a-25d5-412f-a9f4-c8db5c3dcd4b", "Corgi", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "cbf55df0-6d70-48c0-a458-6843bb1515f7", "Burmese", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "cfd85b40-0934-4fec-9053-b7acf37bb0bd", "Bird", "7a9c0369-d114-49e3-abbb-33d7f05f1571" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "breedID", "breedName", "speciesID" },
                values: new object[,]
                {
                    { "d11fa3a6-6145-412e-b85f-60f54cd4623d", "Pug", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "d2c51bae-140d-419f-b78e-8b4a08bfea5b", "Hamster", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "e502684c-b19a-47ef-9e26-dbeb091865df", "Turkish Angora", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "ef7ecbec-3421-4118-9422-9c9a4206821f", "Monkey", "7a9c0369-d114-49e3-abbb-33d7f05f1571" },
                    { "f1b2a18f-1cb1-4380-b44b-51beb8fb708a", "Balinese", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "f63adc4e-a610-4b86-bcfb-c29e5bc6aa1a", "Scottish Fold", "6b35ea48-c99b-4731-99c0-95f263f4db3d" },
                    { "f92a0604-6e1d-4ac2-934e-d810f67dbc84", "Dalmatian", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "fc85f084-1569-4e16-b11f-f3a295a4982b", "Golden Retriever", "1f174c8c-7c69-4674-b478-9f1fa9e958af" },
                    { "ff2299fa-caf6-48dd-b9d9-41a154986098", "Great Dane", "1f174c8c-7c69-4674-b478-9f1fa9e958af" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "01ee0b80-60ec-468e-af15-4ab32f2022cb");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "0257502e-86f3-45fa-906d-79cc5fe1a3bd");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "03577fed-0915-4787-952a-f21becec5ba1");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "0beab5f0-c8d2-4a71-aeba-c2004337ee11");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "1ea3141f-d755-4200-9f84-cf5570329499");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "28ca6816-8afb-47c6-8612-f2f4eb8bbef5");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "378ae4ff-942d-42c8-a2f9-e0035427db5f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "397efe80-c575-40b9-9829-d7aa1d6ec2d6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "3c3a57d8-1d1a-4397-b892-0f77cdcab827");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "456cc89a-e834-4955-9fb3-4832296a83a5");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "479eb831-f94a-4773-bc32-22043a2fdcde");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "49a547a3-e23c-449a-96c9-24aa48a95db6");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "4dc1132c-665c-47a1-80db-1039abdb04da");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "4ee7649c-c733-42c2-9807-a4caad7d6ac8");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "51a86e81-e0e2-4e08-a802-20ac246eed74");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "5a097716-d63c-45f9-8bf2-97525e706f64");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "601fac43-b412-4de0-84a3-798d32539aed");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "6796babd-fce8-4bdc-9a82-68eb47abcd96");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "6838c16f-e06d-47cf-bc89-067886fe094d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "6b4b80af-5f24-4b16-85ea-30900e502592");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "6c45540c-6736-4bbb-97f3-7b8b3884779f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "762b5768-d68a-4456-8f6c-0a840e721ce3");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "77da7ca9-f883-4e5e-892d-0e94b54f8709");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "7cf7df56-0f72-4cf0-b4e5-77b4580b35e7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "807917dc-bd43-455f-bfd4-973e4cb2e31e");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "81da21ea-7837-4c0a-8ed9-00ffb1267237");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "8710d68a-5981-4c0c-bf83-d7a1c7be1f58");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "8730de0e-254a-470c-9e74-58822f419d67");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "88608b6b-3dba-4983-bfa2-43e1bfce63d9");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "91ecb4ac-b379-4587-8360-d04cbb114d5d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "93bce8b5-3ca0-49d9-b795-f8bb6ab09566");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "9bcb2138-4a16-4c9f-853a-27c31759236d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "a15ca33c-4590-4063-8545-265574947210");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "a5cd329c-c35f-4384-9001-0f5fea03d935");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "ab3783c2-6c2d-4282-9e03-50a3a2b55744");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "b6271f6e-9362-488f-8288-2e2e63231109");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "b71faf1b-6b08-4608-968a-8bad374ec43f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "bc48283d-5e3f-4c7c-a31c-6b44ffc0d907");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "c887a8a4-5eb5-4a63-8a88-efe913c9e7fc");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "c96f5f8a-25d5-412f-a9f4-c8db5c3dcd4b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "cbf55df0-6d70-48c0-a458-6843bb1515f7");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "cfd85b40-0934-4fec-9053-b7acf37bb0bd");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "d11fa3a6-6145-412e-b85f-60f54cd4623d");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "d2c51bae-140d-419f-b78e-8b4a08bfea5b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "e502684c-b19a-47ef-9e26-dbeb091865df");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "ef7ecbec-3421-4118-9422-9c9a4206821f");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "f1b2a18f-1cb1-4380-b44b-51beb8fb708a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "f63adc4e-a610-4b86-bcfb-c29e5bc6aa1a");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "f92a0604-6e1d-4ac2-934e-d810f67dbc84");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "fc85f084-1569-4e16-b11f-f3a295a4982b");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "breedID",
                keyValue: "ff2299fa-caf6-48dd-b9d9-41a154986098");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "1f174c8c-7c69-4674-b478-9f1fa9e958af");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "6b35ea48-c99b-4731-99c0-95f263f4db3d");

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "speciesID",
                keyValue: "7a9c0369-d114-49e3-abbb-33d7f05f1571");

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
    }
}
