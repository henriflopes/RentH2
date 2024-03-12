using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addAlternateKeyUserTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DriverLicenseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DriverLicenseId",
                table: "AspNetUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "AspNetUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DriverLicenseId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18f28ead-4681-49d6-b96c-04e5325ef004", "AQAAAAIAAYagAAAAEFosFp2d4soB7sJl2AYAxYUyH1VboU1rnAPaR5/TsSGMfNreDykRZrLpEd8JnzR7Wg==", "134aa8b4-0d43-458c-afee-71bac6285a32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10c1dbda-a21b-4b17-b3c3-a2549b5692bc", "AQAAAAIAAYagAAAAEFq3nBGWbGTBnmnrjZaCMgX8gTf5zEgH/5Z7j7IRG3bhNGE7X7UlyxTT9+bNrryD6Q==", "9935a3a1-8469-4f9d-9044-e5386ebdacf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a4fb9fa-f585-448f-a66f-044b33dd24a2", "AQAAAAIAAYagAAAAENpuSTJ/E442Ox7Xi/AnwVwT2hrNP+iP4TwI1zU8nMLiFZhQHP3WjUZl1Sl8pc8Uzw==", "9dd80133-6f9c-4efc-b8bf-8e0e617883d2" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DriverLicenseId",
                table: "AspNetUsers",
                column: "DriverLicenseId",
                unique: true);
        }
    }
}
