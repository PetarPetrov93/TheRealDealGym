using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class claimsseeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Admin Adminov", new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584") },
                    { 2, "user:fullname", "Trainer Gae", new Guid("dea12856-c198-4129-b3f3-b893d8395082") },
                    { 3, "user:fullname", "Michael Phelps", new Guid("c85209a1-3dec-4171-a17c-0d5203286df4") },
                    { 4, "user:fullname", "Katie Thompson", new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9") },
                    { 5, "user:fullname", "Pete Johnson", new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef") },
                    { 6, "user:fullname", "Stella Clay", new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a") }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9351a302-972a-4aa0-94a8-7696913b009e", "AQAAAAEAACcQAAAAEISJ223vUFXNX9d7k/SvSH+ssdnzvdH8YgEb5FrpE+YsFeujaEfdaFLDq1lcE177kw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a29885fe-aff8-4417-9127-66f9beaaac84", "AQAAAAEAACcQAAAAEDMCb4q/xbctFMrH4qDzfivNKS9fhEH+4yHJGfK6/4hm5WJPyETD21Td6pUiKEy3aA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "793b288b-6b95-4989-b2a6-431fcc6f59df", "AQAAAAEAACcQAAAAECvRUEmhMPpfhHk7iY7SUiXqU62FoKpvQsPCAiE24+q9tuqk8z/gxKmUWcJ9D/jYPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6ce3cbc-8b6c-4141-a8bd-24112610b52b", "AQAAAAEAACcQAAAAEHcUEDB5aultJ124XaIyIK2z4p78HkpfxCQJ6iqFR76QjDkm2+GinS++98Ex1pAz4Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "225fc215-f5e3-4106-b154-663588e7e6ea", "AQAAAAEAACcQAAAAEKVv5B3ocTgci54YM0NDmFVh6ekXKoTImftin8VvimuyrXdonw/kitcl3MOOWEvHhQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b3f7b64-2a3b-4022-8e54-e1e99a696ea2", "AQAAAAEAACcQAAAAEHt3EvhtiAc81VPz/qcy9BO/pNjYXB1iajuaT8AvgI1ZbD3R4Ega9Nxudzk6XUnqzw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0488bb71-ee50-4c95-a1dc-b42a53130579", "AQAAAAEAACcQAAAAEGPTMtvpo+n10sQ7Xo+/zZLng8wk/2ph58twXgga/v3zPXjjmc5AGMl5ecDyjt78xA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a528a5be-5ef9-4016-ae81-31a1cbbe9a03", "AQAAAAEAACcQAAAAEMKfm4PX7ZlH7QdNMg9aErtQO4jsR7uw/uy/Z4Q1gRCcRBmtmFYfHsJgHshpq0qAhA==" });

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
        }
    }
}
