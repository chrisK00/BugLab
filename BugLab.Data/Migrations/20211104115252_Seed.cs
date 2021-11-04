using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, null, "BugLab" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, null, "Plannial" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "None", 1, "Open", "Implement project controllers" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "None", 1, "Open", "update bugs controllers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
