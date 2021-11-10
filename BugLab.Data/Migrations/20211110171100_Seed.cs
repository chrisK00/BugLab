using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "Modified", "Text" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 10, 17, 10, 59, 664, DateTimeKind.Utc).AddTicks(1611), null, "This has been implemented" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "Modified", "Text" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 10, 17, 10, 59, 664, DateTimeKind.Utc).AddTicks(2116), null, "Nope" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "Modified", "Text" },
                values: new object[] { 3, 2, new DateTime(2021, 11, 10, 17, 10, 59, 664, DateTimeKind.Utc).AddTicks(2119), null, "Any progress?" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
