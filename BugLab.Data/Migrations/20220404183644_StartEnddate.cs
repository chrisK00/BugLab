using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class StartEnddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Sprints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Sprints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7e1bf63-f874-42d7-ab36-63af4e15cc03", "AQAAAAEAACcQAAAAEJHT0qfN3timu5hjFtMyaxX6tvLUWIb+h1YhkbaSKS5wNqDV6RB8LhLlzbl8RQEyHQ==", "5d8b5a4a-3cc3-4b0f-80b6-888b8e671b2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fd81d6a-41ce-476e-a006-fb78d3f5cab2", "AQAAAAEAACcQAAAAELPk1Z43vzRKcG0QkeBMsPMceNkvzdxlhcOiZix1cJmnPU0zekxAhFzwqgRL/H2atA==", "a61de3f6-bbf6-4d1e-8958-ba0ea647fd3c" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 18, 36, 44, 119, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 4, 18, 36, 44, 119, DateTimeKind.Utc).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 4, 4, 18, 36, 44, 119, DateTimeKind.Utc).AddTicks(2608));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Sprints");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c600761-3b81-46ca-a54d-6deecfeb2889", "AQAAAAEAACcQAAAAEGS0zp3+AhiBUU4Hv27HdlFmLFtZnD+WOT1C7p0mc1cy3X02jsbnEhb1nu71ZUJoEQ==", "103352b2-388f-4c5e-ab8c-f31a1683fe65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a3e27e7-9245-4bdf-b133-89f568afbadf", "AQAAAAEAACcQAAAAEPix0HqC9KgQLjhH2bvFVnwDTDIXGc+r0oR9pSCtpEYhCzqdv9gYyZ/3ndxHdm37VA==", "8470c8b0-faa2-4b5c-90ec-91cd27cce36b" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 11, 57, 33, 984, DateTimeKind.Utc).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 4, 11, 57, 33, 984, DateTimeKind.Utc).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 4, 4, 11, 57, 33, 984, DateTimeKind.Utc).AddTicks(1615));
        }
    }
}
