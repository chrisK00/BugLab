using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class BugTypeColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "BugTypes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12e7cc73-7435-4026-876a-176a62ceb905", "AQAAAAEAACcQAAAAEC16v8i64C6MAnZXkr+RTPMszOP3gS2nyuLUFUxXUnKUpEdBJjll+4KN1a7toz6+IA==", "39dea321-2d73-43d0-9544-a839b8cfba0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a145cbf-8157-43d2-8acc-b26a167ddf7a", "AQAAAAEAACcQAAAAEH1HbCwppObR9Es9sK0yg+yEOgaly+sJIb7bFYavBKQQ3WGoJV1ppKCtMM9csk2DhQ==", "adad6ca2-a0db-4e54-b862-94a38c701ea4" });

            migrationBuilder.UpdateData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Color",
                value: "#800080");

            migrationBuilder.UpdateData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Color",
                value: "#FF0000");

            migrationBuilder.UpdateData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Color",
                value: "#00FFFF");

            migrationBuilder.UpdateData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Color",
                value: "#00FFFF");

            migrationBuilder.UpdateData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Color",
                value: "#FF0000");

            migrationBuilder.UpdateData(
                table: "BugTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Color",
                value: "#800080");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 11, 17, 20, 52, 21, 173, DateTimeKind.Utc).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 11, 17, 20, 52, 21, 173, DateTimeKind.Utc).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 11, 17, 20, 52, 21, 173, DateTimeKind.Utc).AddTicks(879));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "BugTypes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80c65204-9286-448e-8997-0fcc3e17754e", "AQAAAAEAACcQAAAAEB5wCH4sGgGqgJpC8LukQ0sUFQG6Guc7/gcJI3XqpVzYXRYVFZ/Ir0kTj3NiCN+LQA==", "259f626a-63c1-4e48-9403-f1d520205518" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ba06c13-d956-4715-b48c-35d3cbacc78f", "AQAAAAEAACcQAAAAEHo9tMiaaMNuq5zBq023NH3XuVOabRpjz7zPUt64Y2KOKZWdmOvNgphUTc0wbFpOGA==", "bc19f993-807c-48dc-9be3-880d0a34ece7" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 11, 14, 11, 59, 0, 819, DateTimeKind.Utc).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 11, 14, 11, 59, 0, 819, DateTimeKind.Utc).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 11, 14, 11, 59, 0, 819, DateTimeKind.Utc).AddTicks(837));
        }
    }
}
