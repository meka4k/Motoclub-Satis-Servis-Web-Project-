using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServis.Data.Migrations
{
    /// <inheritdoc />
    public partial class annotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 16, 23, 38, 806, DateTimeKind.Local).AddTicks(1542));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 6, 21, 50, 3, 199, DateTimeKind.Local).AddTicks(9587));
        }
    }
}
