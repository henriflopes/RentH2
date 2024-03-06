using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDriverLicenseFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DriverLicenseClass",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverLicenseId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverLicenseImageLocalPath",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverLicenseImageUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DriverLicenseClass",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DriverLicenseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DriverLicenseImageLocalPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DriverLicenseImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "AspNetUsers");
        }
    }
}
