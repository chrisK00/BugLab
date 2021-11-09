using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class ProjectNavOnBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ProjectTitle",
                table: "Bugs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectTitle",
                table: "Bugs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, null, "BugLab" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, null, "Plannial" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, null, "SweatSpace" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "ProjectTitle", "Status", "Title" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "None", 1, "BugLab", "Open", "Implement project controllers" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "ProjectTitle", "Status", "Title" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Better domaine events pattern", null, "None", 1, "BugLab", "Open", "update project title" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "ProjectTitle", "Status", "Title" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "None", 2, "Plannial", "Open", "How you doing?" });
        }
    }
}
