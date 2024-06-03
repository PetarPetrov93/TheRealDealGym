using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class addingthedbsets : Migration
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
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "The name of the room"),
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
                    Category = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "The category of the sport"),
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
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "More information about the trainer (Biography)"),
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
