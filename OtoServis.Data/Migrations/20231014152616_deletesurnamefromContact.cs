using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServis.Data.Migrations
{
    /// <inheritdoc />
    public partial class deletesurnamefromContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 10, 14, 18, 26, 16, 616, DateTimeKind.Local).AddTicks(7473), new Guid("7fb65c9c-4f2f-4327-85e0-b085b1a509b8") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 10, 12, 2, 6, 26, 189, DateTimeKind.Local).AddTicks(5347), new Guid("c99ecc27-e51b-4870-8c02-6413e067ae74") });
        }
    }
}
