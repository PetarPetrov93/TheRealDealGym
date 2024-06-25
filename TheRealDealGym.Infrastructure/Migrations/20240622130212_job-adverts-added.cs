using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheRealDealGym.Infrastructure.Migrations
{
    public partial class jobadvertsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "JobAdverts",
                columns: new[] { "Id", "Description", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("73d5830c-73bc-4d1f-9533-1d44fd4621e5"), "We are looking for a motivated and experienced CrossFit coach for a position in our great team.", false, "CrossFit coach full time" },
                    { new Guid("d53d3db8-5856-48a0-a739-eefd609aee1e"), "We are looking for a motivated and experienced fitness coach for a position in our great team.", true, "Fitness coach full time" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobAdverts",
                keyColumn: "Id",
                keyValue: new Guid("73d5830c-73bc-4d1f-9533-1d44fd4621e5"));

            migrationBuilder.DeleteData(
                table: "JobAdverts",
                keyColumn: "Id",
                keyValue: new Guid("d53d3db8-5856-48a0-a739-eefd609aee1e"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06c362f9-c953-4507-a4ba-f53bd9e920f9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "90e99ebd-4e6a-454d-9ffd-ba3829a4ba10", "AQAAAAEAACcQAAAAEOxr99fas44hddZ2J7VBQz/ejCSWuzlu4hZBwUPdVOTRBBqO81f+QotvhrTx/29MwA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("42b0f438-188e-4a5c-b379-e6256e6f4584"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05765398-ecce-4045-bcf5-7358daa80cbe", "AQAAAAEAACcQAAAAEEhW+f314cAkBlzbjdkahmQKNYXnqPPCGR0pvABQhyMtGFn/oodOsHRUf3y9FNzuqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85209a1-3dec-4171-a17c-0d5203286df4"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a66fb8ed-1b5a-466c-a1c4-503e44fb7ff5", "AQAAAAEAACcQAAAAEJ4JTkum0bLd8lvtGTjFlxlRchXU5c2Gn5LHwgKlgq8qLejD59qYsmHxU3oCbs9nFQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0dc4d9-e723-4df4-8cb0-80d8afc9122a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "826dd416-c3e0-422d-97ff-e4d923f1d4ed", "AQAAAAEAACcQAAAAEL1P/D28jc5OhjA36/dOQUm16X7PwMDNmsIxVUSOolAQb/wq1vgcXigtGnufaiTbVw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0e351a5-b55d-4fd0-a0f3-d011c415f5ef"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5c3d6eb-4bdb-43bc-879a-06258467ec7b", "AQAAAAEAACcQAAAAEGZ+uNAyGtDFWtef308V8DQRoUntSIk2u6m8ZtIx8duiaCFVPLUmw6VWGP9TXDsydQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8dd07d2-ec9f-40f0-af98-36edb03a66c3", "AQAAAAEAACcQAAAAEChqHULP5C4vj7bT4WlE+KirY7MhQgXfNXuNkCvQN6X+CtGRovz7E2+cPDUMKBZTIQ==" });
        }
    }
}
