using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addAlternateKeyUserTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70aa7aa1-87fd-4b2f-82a9-30f58360ff03", "AQAAAAIAAYagAAAAEIb7preAcDGC26oXVeZKO4c3WFdHvMVsI2SpeT1gYbj/zs3HVTcEfbDy9eAQyjD7OQ==", "05490560-4702-477b-b1e0-4594d517a346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d677d74-4a9f-4d6c-86e3-829412df19c6", "AQAAAAIAAYagAAAAEPUY9rGszMhGOtzO38NQpTkleiDzKOb9/a5I3DskZHZPnG2F69pLpXY/5mVHFr8djQ==", "4b0d7e9e-eb2e-4df2-800d-706fce33ce0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9850f972-fdc5-4063-9cbd-a126ae665b76", "AQAAAAIAAYagAAAAEFr6N54Rsi+2jNaZKVcD/ojI94jP/RpbStMXAl1WPghS25Y8Q9NemOR4uME5Mk4HnQ==", "a953e0bc-fb62-4ebb-9cf2-6f8ad1cebe89" });
        }
    }
}
