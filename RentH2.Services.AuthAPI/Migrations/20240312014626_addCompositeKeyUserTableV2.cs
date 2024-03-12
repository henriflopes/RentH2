using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCompositeKeyUserTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Id_DriverLicenseId_DocumentId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
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
                values: new object[] { "8e6550bd-6eec-40c8-8e28-51d8218b4051", "AQAAAAIAAYagAAAAENI/c9Xp258dfecZBSDNAwTs/AcliVoV1kqrAgsEeA3UEYPspIAssaHu2UPVS4cgLw==", "754c984c-9d9e-4495-9abd-3cf369b7ca7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47a6e8bd-708b-4b27-ad0d-e367c36e18bc", "AQAAAAIAAYagAAAAEEWPWMe2FRf/9DExwrr7PQwwIJxst2xOTUvrMmjwe+PJrbkRP4ixYedns0MQxy6rOA==", "cec800d3-8975-4d39-bd53-72d5b2aa3f09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7690b841-5445-4a8d-b1db-02cc312724b9", "AQAAAAIAAYagAAAAEJ8UJ4tKGWAxjRUCjxoyVbi9MqlGhJGbT5E+wvKp0yO64tfl068ROoJ48LM8FeshmA==", "a3083527-269d-4932-b1da-67d2aebff6f9" });
        }
    }
}
