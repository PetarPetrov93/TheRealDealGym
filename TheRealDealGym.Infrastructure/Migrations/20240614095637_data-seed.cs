using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Trainers",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                comment: "More information about the trainer (Biography)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "More information about the trainer (Biography)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"), 0, "1db3ac6c-6dd7-4eff-8ab3-5b72d689cd9e", "StretchingTrainer@trdg.com", false, "Katie", "Thompson", false, null, "STRETCHINGTRAINER@TRDG.COM", "STRETCHINGTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAEIjoUqd6/OyJqRYFLcUNtsjMJbNUthFjyf3/H8Q0dGxO7d4OcRQNOoMqm50+OV7ZUQ==", null, false, "5160ac97-f58f-479a-9d26-6b1caa75bad5", false, "StretchingTrainer@trdg.com" },
                    { new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"), 0, "ed839df7-b3a9-4ee7-a778-22f5e87a9b27", "WaterTrainer@trdg.com", false, "Michael", "Phelps", false, null, "WATERTRAINER@TRDG.COM", "WATERTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAEN+HUmryY3EJWLns993laN1Nw69r997oCXNVj06qfWmiO8LVrxMsdoZfEaq3z4LaBg==", null, false, "0cecaf15-dc12-427f-8118-5f537802d729", false, "WaterTrainer@trdg.com" },
                    { new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"), 0, "9a485611-6d5d-4520-b505-7011a0bedd26", "secondGuest@trdg.com", false, "Stella", "Clay", false, null, "SECONDGUEST@TRDG.COM", "SECONDGUEST@TRDG.COM", "AQAAAAEAACcQAAAAELLbCVdrv8xjMAEx/4yCkW5hIT2ksrpwiGu5z96vyXwMgFTWnXgKoTaEggvhXOENMQ==", null, false, "bae0779c-fe46-4361-a8b4-2e5e5b705e64", false, "secondGuest@trdg.com" },
                    { new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"), 0, "a6807a45-a594-44a5-832a-30273bf9a74d", "firstGuest@trdg.com", false, "Pete", "Johnson", false, null, "FIRSTGUEST@TRDG.COM", "FIRSTGUEST@TRDG.COM", "AQAAAAEAACcQAAAAEP4HAklTm+L/Ttg2hb9qAhglIbxvFJ9gfwVNvWY/ssDTBQblyYle1Rwx/2eysmuC2Q==", null, false, "e7326130-1924-49a0-9912-e1f874200182", false, "firstGuest@trdg.com" },
                    { new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 0, "38677e91-e5a2-4b9f-9fe6-38f5c3befaa3", "FightingTrainer@trdg.com", false, "Trainer", "Gae", false, null, "FIGHTINGTRAINER@TRDG.COM", "FIGHTINGTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAEGsCRAnO4o5WLsqll0HdFNmdxfCjggNEJwLiTcMqXjMLZhW6+1XNCKPiOpQZfGahig==", null, false, "78f47fd7-d3d5-4fa4-bedc-e1ce253f5f6f", false, "FightingTrainer@trdg.com" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("3db85752-7746-4d29-a638-5a54c2e07075"), 50, false, "Fighting room" },
                    { new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"), 40, false, "Pool" },
                    { new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"), 1, false, "Open Space room" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Category", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"), "FightingSports", false, "MuayThai" },
                    { new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"), "WaterSports", false, "Swimming" },
                    { new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"), "Stretching", false, "Yoga" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Age", "Bio", "IsDeleted", "UserId", "YearsOfExperience" },
                values: new object[] { new Guid("3c944adc-2b2b-4e81-a643-643fcb116262"), 40, "I am one of the best swimmers in the world", false, new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"), 19 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Age", "Bio", "IsDeleted", "UserId", "YearsOfExperience" },
                values: new object[] { new Guid("62cf1550-e01e-452b-9fe4-95487b14514e"), 24, "I am very positive person and great professional.", false, new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"), 3 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Age", "Bio", "IsDeleted", "UserId", "YearsOfExperience" },
                values: new object[] { new Guid("966d1ddc-b505-4aae-b790-595a4c688931"), 51, "I am one of the best MyaiThai coaches in the world", false, new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 25 });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "DateAndTime", "Description", "IsDeleted", "Price", "RoomId", "SportId", "Title", "TrainerId" },
                values: new object[,]
                {
                    { new Guid("6a05950a-e1bf-4b6c-9577-2c289c3e6de6"), new DateTime(2025, 9, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), "This is a swimming class for children only.", false, 10m, new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"), new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"), "Swimming for kids", new Guid("3c944adc-2b2b-4e81-a643-643fcb116262") },
                    { new Guid("7a90a874-0c11-4e70-9391-cc3487e60b0e"), new DateTime(2025, 3, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), "This is a Yoga class suitable experienced people with at least 1 year of experience in yoga/stretching.", false, 14m, new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"), new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"), "Yoga Advanced", new Guid("62cf1550-e01e-452b-9fe4-95487b14514e") },
                    { new Guid("86cc93b0-3993-4a88-b41c-c0414538c7f4"), new DateTime(2025, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "This is a Muay Thai class suitable for beginners.", false, 15m, new Guid("3db85752-7746-4d29-a638-5a54c2e07075"), new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"), "Muay Thai for beginners", new Guid("966d1ddc-b505-4aae-b790-595a4c688931") }
                });

            migrationBuilder.InsertData(
                table: "TrainersSports",
                columns: new[] { "SportId", "TrainerId" },
                values: new object[,]
                {
                    { new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"), new Guid("3c944adc-2b2b-4e81-a643-643fcb116262") },
                    { new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"), new Guid("62cf1550-e01e-452b-9fe4-95487b14514e") },
                    { new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"), new Guid("966d1ddc-b505-4aae-b790-595a4c688931") }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ClassId", "IsDeleted", "UserId" },
                values: new object[] { new Guid("2283428d-0ed0-4837-9bb2-028485808ac5"), new Guid("86cc93b0-3993-4a88-b41c-c0414538c7f4"), false, new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("2283428d-0ed0-4837-9bb2-028485808ac5"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("6a05950a-e1bf-4b6c-9577-2c289c3e6de6"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("7a90a874-0c11-4e70-9391-cc3487e60b0e"));

            migrationBuilder.DeleteData(
                table: "TrainersSports",
                keyColumns: new[] { "SportId", "TrainerId" },
                keyValues: new object[] { new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"), new Guid("3c944adc-2b2b-4e81-a643-643fcb116262") });

            migrationBuilder.DeleteData(
                table: "TrainersSports",
                keyColumns: new[] { "SportId", "TrainerId" },
                keyValues: new object[] { new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"), new Guid("62cf1550-e01e-452b-9fe4-95487b14514e") });

            migrationBuilder.DeleteData(
                table: "TrainersSports",
                keyColumns: new[] { "SportId", "TrainerId" },
                keyValues: new object[] { new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"), new Guid("966d1ddc-b505-4aae-b790-595a4c688931") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"));

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: new Guid("86cc93b0-3993-4a88-b41c-c0414538c7f4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("3c944adc-2b2b-4e81-a643-643fcb116262"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("62cf1550-e01e-452b-9fe4-95487b14514e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3db85752-7746-4d29-a638-5a54c2e07075"));

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("966d1ddc-b505-4aae-b790-595a4c688931"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"));

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: false,
                comment: "More information about the trainer (Biography)",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldComment: "More information about the trainer (Biography)");
        }
    }
}
