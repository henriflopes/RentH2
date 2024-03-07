using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedTaxIdtoIdNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "AspNetUsers",
                newName: "IdNumber");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "AspNetUsers",
                newName: "TaxId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac65f98f-bd3d-4be8-8a2b-eab37f6b4ec8", "AQAAAAIAAYagAAAAEDXQGXFScmfYFo3aBEGUVgXe5YXi2KHn4RORVvWB94YrobVr6PHjhxlr+GnyTU5rFQ==", "93245e08-65f4-4b67-a196-55e580811fb6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6fe3d47-c84b-4000-87f6-d85da0ece3a9", "AQAAAAIAAYagAAAAEPpG7RUcU7dioTzVXjU1uta22eoRIdb+oFGZiNzFCFIANwHOYlBa/emupmxAoIt1UQ==", "f2c1178a-79fb-44cb-a78d-352bda690eb3" });
        }
    }
}
