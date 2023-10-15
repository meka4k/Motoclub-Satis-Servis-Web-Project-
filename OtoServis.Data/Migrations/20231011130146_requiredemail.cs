using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServis.Data.Migrations
{
    /// <inheritdoc />
    public partial class requiredemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 10, 11, 16, 1, 46, 661, DateTimeKind.Local).AddTicks(7208), new Guid("0ac991ae-9793-40d0-a48b-8c31c04d9596") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 10, 10, 18, 12, 3, 694, DateTimeKind.Local).AddTicks(2758), new Guid("e5cc091a-4c40-4bbe-92a8-8b462cc82069") });
        }
    }
}
