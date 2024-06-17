using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class Dbsetsaddedanddataseeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "This is an extension to the User. Adds FirstName and LastName properties to the User and changes the Id from string to GUID");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "FirstName property - extension to the default User");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "LastName property - extension to the default User");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Room identifier"),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "The name of the room"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "The maximum capacity of the room"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Serves a soft delete purpose")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                },
                comment: "The room is the place where a specific type of classes will be taking place.");

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Sport identifier"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "The title of the sport"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Serves a soft delete purpose")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                },
                comment: "The Sport holds the title of a given sport and its category (type of sport)");

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Trainer identifier"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Trainer's age"),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Trainer's years of experience."),
                    Bio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "More information about the trainer (Biography)"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ApplicationUser"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Serves a soft delete purpose")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Trainer can organize classes and teach all the Sports which he is qualified to teach");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Class identifier"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "The title of the class"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Description and additional info about the class"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Starting date and time of the class"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price of the class"),
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Trainer"),
                    SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Sport"),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Room"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Serves a soft delete purpose")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Classes_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Classes_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id");
                },
                comment: "The Class entity stores information about a specific class");

            migrationBuilder.CreateTable(
                name: "TrainersSports",
                columns: table => new
                {
                    TrainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Trainer identifier"),
                    SportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Sport identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainersSports", x => new { x.TrainerId, x.SportId });
                    table.ForeignKey(
                        name: "FK_TrainersSports_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainersSports_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mapping the Trainer and Sport entities");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Booking identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ApplicationUser"),
                    ClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Class"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Serves a soft delete purpose")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                },
                comment: "Many bookings by different users can be made for one Class. One User can have many bookings for different classes");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"), 0, "88e63e6d-5862-43af-9cb1-fbfe0a26558d", "StretchingTrainer@trdg.com", false, "Katie", "Thompson", false, null, "STRETCHINGTRAINER@TRDG.COM", "STRETCHINGTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAEESVZhmvtA8IQyYCKwEL13FuWzgnFKsdFLzHdsdpJjFCcuHqqYHrTOTqLMFBabd59w==", null, false, "5160ac97-f58f-479a-9d26-6b1caa75bad5", false, "StretchingTrainer@trdg.com" },
                    { new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"), 0, "3f44dfca-fa4d-470e-90d8-fe4c3c3a240d", "WaterTrainer@trdg.com", false, "Michael", "Phelps", false, null, "WATERTRAINER@TRDG.COM", "WATERTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAENG+Aq2dO0qtfsIWZhpeunIpSL/QDVh/n+oX9IUE8qbB4+t5t8v7ays+Cd8v/+ZD8Q==", null, false, "0cecaf15-dc12-427f-8118-5f537802d729", false, "WaterTrainer@trdg.com" },
                    { new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"), 0, "790dd16f-5600-4ceb-8a04-e058909de1be", "secondGuest@trdg.com", false, "Stella", "Clay", false, null, "SECONDGUEST@TRDG.COM", "SECONDGUEST@TRDG.COM", "AQAAAAEAACcQAAAAED3XzpYO8QDck5kC7UtlmfjKSiPUsGzA73QYGWDuOSHEhKocxTnK1vRSvXjSVbqAbw==", null, false, "bae0779c-fe46-4361-a8b4-2e5e5b705e64", false, "secondGuest@trdg.com" },
                    { new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"), 0, "76bc9bb3-c593-4d30-95aa-1d05847e613b", "firstGuest@trdg.com", false, "Pete", "Johnson", false, null, "FIRSTGUEST@TRDG.COM", "FIRSTGUEST@TRDG.COM", "AQAAAAEAACcQAAAAEP1lMUP5pgcbTzIcFZW0v7Y1E2F1cKRKqdlzWnUR0A73Y0HMozOYZe4LIApo3VpFKQ==", null, false, "e7326130-1924-49a0-9912-e1f874200182", false, "firstGuest@trdg.com" },
                    { new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 0, "4fc91d77-2058-47eb-8767-0d38edae48fa", "FightingTrainer@trdg.com", false, "Trainer", "Gae", false, null, "FIGHTINGTRAINER@TRDG.COM", "FIGHTINGTRAINER@TRDG.COM", "AQAAAAEAACcQAAAAEP/F8KTmvmCPQJd/xiNUyLRmHzOkJITNZU1ioU4Yz3OHvty8WeR5cJNgO1O9FE/EAw==", null, false, "78f47fd7-d3d5-4fa4-bedc-e1ce253f5f6f", false, "FightingTrainer@trdg.com" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "IsDeleted", "Type" },
                values: new object[,]
                {
                    { new Guid("3db85752-7746-4d29-a638-5a54c2e07075"), 50, false, "Fighting room" },
                    { new Guid("70e053fc-61a0-4ab7-9104-08572c23aa38"), 40, false, "Pool" },
                    { new Guid("d88e930f-8694-4c04-a58a-ca71373b6c22"), 1, false, "Open Space room" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { new Guid("28b80b07-87c8-42f7-9af6-28d832ce7b2b"), false, "MuayThai" },
                    { new Guid("7e20cc5c-6c1b-4ba6-a070-517660fead98"), false, "Swimming" },
                    { new Guid("890d3966-eb5e-42f1-97e2-79382ce3ac96"), false, "Yoga" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClassId",
                table: "Bookings",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_RoomId",
                table: "Classes",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SportId",
                table: "Classes",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TrainerId",
                table: "Classes",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_UserId",
                table: "Trainers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainersSports_SportId",
                table: "TrainersSports",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "TrainersSports");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "This is an extension to the User. Adds FirstName and LastName properties to the User and changes the Id from string to GUID");
        }
    }
}
