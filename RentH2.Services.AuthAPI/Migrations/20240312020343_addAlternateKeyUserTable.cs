using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addAlternateKeyUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Id_DriverLicenseId_DocumentId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DriverLicenseId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_DocumentId_DriverLicenseId",
                table: "AspNetUsers",
                
                columns: new[] { "DocumentId", "DriverLicenseId" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_DocumentId_DriverLicenseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DriverLicenseId",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15b0bd20-e994-4272-928e-9f1d22d6ab9b", "AQAAAAIAAYagAAAAENCLfuJoTOq8DkRSmvI/xWvGAbOp6IH7YGRXRck3fXB+zUSfNBFugFi3L/PCay+mmg==", "f57ba4b3-58de-433e-9c9a-ef116d7745d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60ff4ca1-855c-4b63-8103-5df51b4fc785", "AQAAAAIAAYagAAAAEKwaN4s95NBb5cxUpyXLVVLgb+dcJvx8hCri8sLi5ItrNpXhPUss5GU7LAkf+ksIWw==", "047fb7b0-32ab-4bec-9c85-2faed59a8839" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e90c8392-ae07-47e8-a29a-6f4745d1dabf", "AQAAAAIAAYagAAAAED7xq/DSNPreDf1cWilKys5S7qUXTUFxAL/S3Gotz68VPn5KutBNWUquX91anvvzaA==", "f71589a3-3d88-4913-a461-ab039525d58f" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id_DriverLicenseId_DocumentId",
                table: "AspNetUsers",
                columns: new[] { "Id", "DriverLicenseId", "DocumentId" },
                unique: true);
        }
    }
}
