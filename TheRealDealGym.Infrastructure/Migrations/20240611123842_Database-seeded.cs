using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class Databaseseeded : Migration
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
                    { new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"), 0, "f1fb76e7-2b2e-44d3-ab2d-d58a5c6741b0", "StretchingTrainer@trdg.com", false, "Katie", "Thompson", false, null, "STRETCHINGTRAINER@TRDG.COM", "STRETCHINGTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAEM09r3SDV6QiNDjMPBkm3csqMchitmxstT4MByedhV/1B7f4IdV3a8sIedldgUf3Sw==", null, false, null, false, "StretchingTrainer@trdg.com" },
                    { new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"), 0, "ef1e1ad8-f0ce-4275-b000-9e01a844b651", "WaterTrainer@trdg.com", false, "Michael", "Phelps", false, null, "WATERTRAINER@TRDG.COM", "WATERTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAELs9bo65UNqxNFoQk9V6V4NHeY1L9OcAgu4MShiV4jyEA/hid5Zb2lX4KYtfINgVzQ==", null, false, null, false, "WaterTrainer@trdg.com" },
                    { new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"), 0, "a9e44232-9c50-4fea-8db2-e0ebc16b2b13", "secondGuest@trdg.com", false, "Stella", "Clay", false, null, "SECONDGUEST@TRDG.COM", "SECONDGUEST@TRDG.COM", "AQAAAAEAACcQAAAAEGl82a0lONOnLVLln1lXuShUnZGqUGUwutTDcBEk1RWfP/u8pDdEOFUGXdsvFwR2CQ==", null, false, null, false, "secondGuest@trdg.com" },
                    { new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"), 0, "89923b9b-1c4b-4e8f-b5d5-70f953a3e467", "firstGuest@trdg.com", false, "Pete", "Johnson", false, null, "FIRSTGUEST@TRDG.COM", "FIRSTGUEST@TRDG.COM", "AQAAAAEAACcQAAAAEMXF+5vef0dKKhCmpygi08DceuIGkOEyrKbz3/F30Zh01BBDz97RrUFzeUTmHxlLZw==", null, false, null, false, "firstGuest@trdg.com" },
                    { new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 0, "f55ea46f-5842-45d0-bd12-6878bbda6139", "FightingTrainer@trdg.com", false, "Trainer", "Gae", false, null, "FIGHTINGTRAINER@TRDG.COM", "FIGHTINGTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAEFGS/N6ad/RVrBNTPixyShBVnlpMKX3XKfV3UzHKlDywtlcW1s04v6pLIeDbJudC5A==", null, false, null, false, "FightingTrainer@trdg.com" }
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
