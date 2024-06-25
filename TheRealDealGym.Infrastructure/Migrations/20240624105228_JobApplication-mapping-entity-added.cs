using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class JobApplicationmappingentityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "JobApplication identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ApplicationUser"),
                    JobAdvertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ApplicationUser"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Applicant's age"),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Applicant's years of experience."),
                    Bio = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "More information about the applicant (Biography)"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Serves a soft delete purpose")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobAdverts_JobAdvertId",
                        column: x => x.JobAdvertId,
                        principalTable: "JobAdverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "170eb9c6-3607-42d3-a6e2-19f1ca6fa2db", "AQAAAAEAACcQAAAAEHRt60H6tHag8lh75c1BA5SoRbaqEDXaWKkrDfpKnYjBaJrfSOSQ5dIrTRJGEeAiMA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0e4b5f3c-de17-4537-9b9b-b591e756760a", "AQAAAAEAACcQAAAAECHVtVlduL44howBlaR3RhAILrhfv4p/u7X+CODUKHsr6vWqWyc6Mf22bSNyuI58xg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa646f17-dab4-4ccb-a2e3-aab70f68ea83", "AQAAAAEAACcQAAAAECdJkIJSiRPFqUcgxV8500FDjWQVvLNKXZHwfAS8rVi7P59VbaRTz8qKpakhBTswpA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a204b029-2a22-42dd-990b-93b3a1549341", "AQAAAAEAACcQAAAAENfwtZ4Ra7qkSO9CtI3I8uZ6Xrmh3H9tgzrUQ+F1MDRXG8tqL/bnq0QP9HwTUIKFdw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "972b31df-10fe-4601-a99f-813cd3404569", "AQAAAAEAACcQAAAAEE8LHTfakGqPYTcluLkKLm+m9BgF14Z421LIdHXOfvRls/qaW9zRjCrMFzoahoTPzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4d2959d8-8003-40e2-a85e-ddde8c3aed9e", "AQAAAAEAACcQAAAAECpRc6smybhHHLsB6KH7QbUv1chTc+0CoNipYEuyX+xmiPrpNrCF4ko/iun06zBDNw==" });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobAdvertId",
                table: "JobApplications",
                column: "JobAdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b5eff68-f03b-45f2-81cf-e164157a2d9e", "AQAAAAEAACcQAAAAELiaRmN3Z5dsSvUCBSlpwm2rmr317lcGoosD/eMHgHoYk/LK5FCVx7AmwWCoz0kVLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ba1d1043-04fa-41e0-ae23-e7acc64b1da8", "AQAAAAEAACcQAAAAEC4xZjVjaSWToPDZ8TlOIgZtfUuPuTsG4TzhhK9uW29+I6tjJLdRA+6Zg7XzAgm0aQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54bbd941-3e60-4020-be33-4a9a20100b3a", "AQAAAAEAACcQAAAAEInECdejL3WrNpW5dbHuudLYZ+N/DJN4V6B4bqfLNRody4V5LxbppNAerL/i7UiXYQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fffea464-e16d-4cfb-9e1d-b0ec8cea4029", "AQAAAAEAACcQAAAAEHT8jdIq5zHFIaU5UtxIIBw7K5VyWyXqQ6qCMCvDamRU79BPoyUKBSIkC3/F4rGEIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a041cf16-d75e-4f8f-9596-7889c2af6763", "AQAAAAEAACcQAAAAEN2kVnU3jagXcd3HCzxpYVNrZdwERb2Fz0L0PQYBSY4nsMlNq8CVwelJ0Yg/suG8ig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0adf285e-ced7-4859-b9cf-eb74760c7e61", "AQAAAAEAACcQAAAAEKLNFqZvRY9NWsDMhbWPpXqVq9Y9K6DvZsYng9WxmiWhKd9WVnLO3cX2tY3pH5N1tQ==" });
        }
    }
}
