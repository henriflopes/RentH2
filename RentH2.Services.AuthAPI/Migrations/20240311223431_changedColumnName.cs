using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentH2.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "AspNetUsers",
                newName: "DocumentId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Administrador", "ADMINISTRADOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Entregador", "ENTREGADOR" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "AspNetUsers",
                newName: "IdNumber");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Rider", "RIDER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208aa945-2d84-2421-2342-2269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73c62cbf-71a4-4ccf-a808-99ca163b67d7", "AQAAAAIAAYagAAAAEEH4PUY8/9tvCb+f4JjtVZouU0pYvt9BwHytgRPq/he8C6jvSpp6Qep8cns3F21tfQ==", "e478308f-81a6-453a-88b7-1cd1a0cd2332" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "208dd945-2d84-2421-2342-2269fc54d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecc43331-8527-471b-a339-3e974c58b89c", "AQAAAAIAAYagAAAAEPyYw8Zlf2h2o/EWwzECHKrOTrm0Vmh2FOVxaCpSzAt64q80rnwcIkk9JXOcXnx52g==", "22b2db92-ba7a-41d8-84c9-725987e197bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e07ce65-1e83-4190-83f8-9ebefbd83bb6", "AQAAAAIAAYagAAAAELeXo2JGpf4njYBNbPpzQqM90/76A8+D/EoN44J+9ChKLuQ0fnbsdFT7jow22nfW9w==", "7016822a-6f0f-4438-ba37-6128cd97012e" });
        }
    }
}
