using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServis.Data.Migrations
{
    /// <inheritdoc />
    public partial class addadminMail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 10, 15, 0, 20, 38, 296, DateTimeKind.Local).AddTicks(8411), new Guid("a377db6f-a3ff-496d-9b90-3e79d3462914") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 10, 14, 18, 26, 16, 616, DateTimeKind.Local).AddTicks(7473), new Guid("7fb65c9c-4f2f-4327-85e0-b085b1a509b8") });
        }
    }
}
