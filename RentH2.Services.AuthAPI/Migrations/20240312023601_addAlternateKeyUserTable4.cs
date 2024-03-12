using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addAlternateKeyUserTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_DocumentId_DriverLicenseId",
                table: "AspNetUsers");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_DocumentId",
                table: "AspNetUsers",
                column: "DocumentId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_DriverLicenseId",
                table: "AspNetUsers",
                column: "DriverLicenseId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c61bd860-72f1-422d-a1c3-2a0178ad9f18", "AQAAAAIAAYagAAAAEDakk8Y/HNiAb0bs6Crnt4lelE8t67QHOzN4rl79yWvUnPry3Z7woPDw2AOEdMe7uA==", "7adf0bf2-dd0b-414f-9e8f-c31916618bc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e82372e7-9930-482d-9e4a-35d9b8d7d322", "AQAAAAIAAYagAAAAEAFD7nUe9ZdImpSl3RxpFqFMASHqfcSQFICgouJMRSzRLVy2uoImvvg+IRFUzXv79g==", "1625eb2b-cc39-4c8b-ac87-51ece94a3085" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8396e1c5-1297-42b3-b38e-52167a2e16a5", "AQAAAAIAAYagAAAAEG93kx3safkO5X2wD8GBv0RSbqFhdRKi09DCZ8ZTh8CFW7IRfVGNEk+XkfZ5aqkGZA==", "dc46e1b6-045f-4c8c-a5c1-ebff03cf4092" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_DocumentId",
                table: "AspNetUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_DriverLicenseId",
                table: "AspNetUsers");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_DocumentId_DriverLicenseId",
                table: "AspNetUsers",
                columns: new[] { "DocumentId", "DriverLicenseId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b101ef6-010b-40ef-afbe-79b39939b337", "AQAAAAIAAYagAAAAEBIHEgTMEm1M010bli3GbaUuP+HpzqR5jS14y1DrQhBAKK1zDIKjHYpCNtiQHShsrg==", "28a39b40-d2b6-4c98-a632-af0cb9940751" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23d78d4b-8d15-45ca-af59-f3e158801acc", "AQAAAAIAAYagAAAAEBu8+kPGCeIUw5N4KcPPL8MhBRYbvgN8eBhflanL4O7CVBCeLhJByfzJdn5/KENCBQ==", "32aaefe8-da21-4368-9d16-c2ecf468cbcf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d85fb733-a0f0-4eef-a2ff-c76605636df9", "AQAAAAIAAYagAAAAECkE2sMkvXmch2QLwnIpXM+vPeaaeQhR+B/KrBfSoL5bvV2nalILMy4w1CIhuiOy7w==", "99e581b4-cd9d-466c-9f0e-1a32fd207dea" });
        }
    }
}
