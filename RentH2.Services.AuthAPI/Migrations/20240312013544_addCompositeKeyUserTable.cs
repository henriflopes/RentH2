using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCompositeKeyUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirth",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DriverLicenseId",
                table: "AspNetUsers",
                column: "DriverLicenseId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DriverLicenseId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ba4f607-7fe1-403c-ab78-a32163d3154e", "AQAAAAIAAYagAAAAEBTM7/s6otqpHFZ8UVAsZY0JbWVlF+/u4RJBbOpSOKlbHfsUmtLOidrQo4Rvxn9oPg==", "8ffb51b4-a79b-4632-880d-2df74af490da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51c5425f-28b2-436b-8b74-7d278856df71", "AQAAAAIAAYagAAAAEEMCwxR8nuYe9KmElDIPOeeYxBntrUJLMoT8q8p3X8A3oPU/t3IC+nmMhhZ8gWunuw==", "ca79dea8-e238-4d52-bc0c-c4ac52a91dc2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdf54636-50e3-44c9-875d-3096fb0d3bf4", "AQAAAAIAAYagAAAAEJe7KEseucqFlB0EbvIHGkw3GRdwkXH0uPPk2Cb/qqXBpEdTy4m7AxqMiW21Z8DuTQ==", "9b04c818-b536-4b2c-8849-abc55f1bb99f" });
        }
    }
}
