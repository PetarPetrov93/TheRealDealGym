using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class adminadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0488bb71-ee50-4c95-a1dc-b42a53130579", "AQAAAAEAACcQAAAAEGPTMtvpo+n10sQ7Xo+/zZLng8wk/2ph58twXgga/v3zPXjjmc5AGMl5ecDyjt78xA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73844c12-51ac-41b7-a0c6-1fc773e10caf", "AQAAAAEAACcQAAAAEAS6ZzbgQlr2EVyYOwZIQ7kKAYolVZhJoBKng4b/98JHd1kOJoe+pm+OvdbfZdgrWg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8fd7ae77-143f-4c53-a91f-2549e50b364e", "AQAAAAEAACcQAAAAELKPjmuZ2aM8OhojS4nE/9l2niiWVpqqXA4NG4Od8rwreQ9OXujbjo9dTmTvg+6MUQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5640b812-6fd6-4569-919b-5597b0f71483", "AQAAAAEAACcQAAAAEJBGB2IBFdWWWKv8Ym47quuWbRyDc2mV3fAMspkrsNfr0WEQ9NLVlLc13RMJf7s09Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "489c32c3-b6e6-4f10-a5d0-36fc6a273a91", "AQAAAAEAACcQAAAAELLnQwcnPYV6OzHX4ludEATKFkkQ7tI51wHe2R5dmx7DGAo/JmPiSbgNQEYn8i6F1Q==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"), 0, "a528a5be-5ef9-4016-ae81-31a1cbbe9a03", "admin@trdg.com", false, "Admin", "Adminov", false, null, "ADMIN@TRDG.COM", "ADMIN@TRDG.COM", "AQAAAAEAACcQAAAAEMKfm4PX7ZlH7QdNMg9aErtQO4jsR7uw/uy/Z4Q1gRCcRBmtmFYfHsJgHshpq0qAhA==", null, false, "62f2b46f-f90f-44bb-94fd-9cd7fc523047", false, "admin@trdg.com" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Age", "Bio", "IsDeleted", "UserId", "YearsOfExperience" },
                values: new object[] { new Guid("1d674a7f-78ca-42f0-96a3-856cb26fb7c3"), 37, "I am one of the best admins in the world! Nobody is better than me!", false, new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"), 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("1d674a7f-78ca-42f0-96a3-856cb26fb7c3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88e63e6d-5862-43af-9cb1-fbfe0a26558d", "AQAAAAEAACcQAAAAEESVZhmvtA8IQyYCKwEL13FuWzgnFKsdFLzHdsdpJjFCcuHqqYHrTOTqLMFBabd59w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f44dfca-fa4d-470e-90d8-fe4c3c3a240d", "AQAAAAEAACcQAAAAENG+Aq2dO0qtfsIWZhpeunIpSL/QDVh/n+oX9IUE8qbB4+t5t8v7ays+Cd8v/+ZD8Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "790dd16f-5600-4ceb-8a04-e058909de1be", "AQAAAAEAACcQAAAAED3XzpYO8QDck5kC7UtlmfjKSiPUsGzA73QYGWDuOSHEhKocxTnK1vRSvXjSVbqAbw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76bc9bb3-c593-4d30-95aa-1d05847e613b", "AQAAAAEAACcQAAAAEP1lMUP5pgcbTzIcFZW0v7Y1E2F1cKRKqdlzWnUR0A73Y0HMozOYZe4LIApo3VpFKQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4fc91d77-2058-47eb-8767-0d38edae48fa", "AQAAAAEAACcQAAAAEP/F8KTmvmCPQJd/xiNUyLRmHzOkJITNZU1ioU4Yz3OHvty8WeR5cJNgO1O9FE/EAw==" });
        }
    }
}
