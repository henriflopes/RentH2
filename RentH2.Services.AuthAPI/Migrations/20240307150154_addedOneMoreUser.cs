using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedOneMoreUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73c62cbf-71a4-4ccf-a808-99ca163b67d7", "AQAAAAIAAYagAAAAEEH4PUY8/9tvCb+f4JjtVZouU0pYvt9BwHytgRPq/he8C6jvSpp6Qep8cns3F21tfQ==", "e478308f-81a6-453a-88b7-1cd1a0cd2332" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e07ce65-1e83-4190-83f8-9ebefbd83bb6", "AQAAAAIAAYagAAAAELeXo2JGpf4njYBNbPpzQqM90/76A8+D/EoN44J+9ChKLuQ0fnbsdFT7jow22nfW9w==", "7016822a-6f0f-4438-ba37-6128cd97012e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateBirth", "DriverLicenseClass", "DriverLicenseId", "DriverLicenseImageLocalPath", "DriverLicenseImageUrl", "Email", "EmailConfirmed", "IdNumber", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[] { "208dd945-2d84-2421-2342-2269fc54d949", 0, "ecc43331-8527-471b-a339-3e974c58b89c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", "D5239773-4F94-957A", "", "", "rider02@renth2.com", true, "8BB4F3857AC0", false, null, "System", "RIDER02@RENTH2.COM", "RIDER02@RENTH2.COM", "AQAAAAIAAYagAAAAEPyYw8Zlf2h2o/EWwzECHKrOTrm0Vmh2FOVxaCpSzAt64q80rnwcIkk9JXOcXnx52g==", null, false, "22b2db92-ba7a-41d8-84c9-725987e197bb", "Rider02", false, "rider02@renth2.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cac43a7e-f7cb-4448-baaf-labb431eabbf", "208dd945-2d84-2421-2342-2269fc54d949" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a7e-f7cb-4448-baaf-labb431eabbf", "208dd945-2d84-2421-2342-2269fc54d949" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dea67a6-ee17-4528-9422-5f4741f6995c", "AQAAAAIAAYagAAAAEHubgUe9dZASy49xz075YnaJtjl6ZuAky9QTopGBY06nEVBP3K8kQV5QvDC8jeVZyw==", "dcda5dc3-3e03-4969-b707-0e9602bf714f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1f919ae-1437-4341-8020-97fb751aec1d", "AQAAAAIAAYagAAAAEMEGFQgZ7Wio1i/4c1TyQlX6Y6dX81g2lO8uRWivbDNWSYCQULuyGnHevosgdQPMDw==", "3a2271e9-9fbf-46c8-bb2b-87083330e252" });
        }
    }
}
