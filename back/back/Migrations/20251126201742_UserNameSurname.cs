using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back.Migrations
{
    /// <inheritdoc />
    public partial class UserNameSurname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 5, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 26, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 28, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 13, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 23, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 20, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 31, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 2, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 28, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 28, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 10, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 25, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 30, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 25, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 7, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 26, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 15, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 15, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 8, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 25, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 30, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 22, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 3, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 11, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 29, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 11, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 26, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 30, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 7, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 21, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 20, 17, 42, 734, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Role", "Surname" },
                values: new object[] { "Bob", 1, "Ross" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Role", "Surname" },
                values: new object[] { "Rob", 0, "Boss" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 17, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 16, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 24, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 4, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 9, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 20, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 2, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 4, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 12, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 27, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 9, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 20, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 11, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 30, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 17, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 1, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 5, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 4, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 30, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 28, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 21, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 12, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 9, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 15, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 14, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Terms",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 7, 17, 59, 43, 620, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: 1);
        }
    }
}
