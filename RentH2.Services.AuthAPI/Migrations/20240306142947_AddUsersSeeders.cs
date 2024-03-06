using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-ladd431ccbbf", null, "Administrator", "ADMINISTRATOR" },
                    { "cac43a7e-f7cb-4448-baaf-labb431eabbf", null, "Rider", "RIDER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateBirth", "DriverLicenseClass", "DriverLicenseId", "DriverLicenseImageLocalPath", "DriverLicenseImageUrl", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SurName", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "208aa945-2d84-2421-2342-2269ec64d949", 0, "ac65f98f-bd3d-4be8-8a2b-eab37f6b4ec8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", "C5239363-957A-4F94", "", "", "rider@renth2.com", true, false, null, "System", "RIDER@RENTH2.COM", "RIDER@RENTH2.COM", "AQAAAAIAAYagAAAAEDXQGXFScmfYFo3aBEGUVgXe5YXi2KHn4RORVvWB94YrobVr6PHjhxlr+GnyTU5rFQ==", null, false, "93245e08-65f4-4b67-a196-55e580811fb6", "Rider", "7AA4F3857AB9", false, "rider@renth2.com" },
                    { "408aa945-3d84-4421-8342-7269ec64d949", 0, "d6fe3d47-c84b-4000-87f6-d85da0ece3a9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A+B", "6D13ED6A-957A-4F94", "", "", "admin@renth2.com", true, false, null, "System", "ADMIN@RENTH2.COM", "ADMIN@RENTH2.COM", "AQAAAAIAAYagAAAAEPpG7RUcU7dioTzVXjU1uta22eoRIdb+oFGZiNzFCFIANwHOYlBa/emupmxAoIt1UQ==", null, false, "f2c1178a-79fb-44cb-a78d-352bda690eb3", "Admin", "5ABFFEAAEAE0", false, "admin@renth2.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cac43a7e-f7cb-4448-baaf-labb431eabbf", "208aa945-2d84-2421-2342-2269ec64d949" },
                    { "cac43a6e-f7bb-4448-baaf-ladd431ccbbf", "408aa945-3d84-4421-8342-7269ec64d949" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a7e-f7cb-4448-baaf-labb431eabbf", "208aa945-2d84-2421-2342-2269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a6e-f7bb-4448-baaf-ladd431ccbbf", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949");
        }
    }
}
