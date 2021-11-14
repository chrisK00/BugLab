using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class DeletedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Bugs",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Bugs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ccc2777-5b9f-462d-a259-72af7e4b7d36", "AQAAAAEAACcQAAAAEGJKCNdqzCQQZkscFRk0pVqpfDGVrYwBdx0KMFH2nxxyAbMCWFTVjVUNJ4jZ/xM65g==", "3e524b58-2640-43e0-a3a8-eedcb2197fda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f05ba53-f3fb-4a90-bf53-ca8d61385179", "AQAAAAEAACcQAAAAEKa/S7YmiBxXoPk2EV4R42hghkAXVx026O7Wgf/DNHpbFV7k5an4aSOqzA95feak7g==", "8aa5a147-bac5-4129-a6dc-850b19d07cbf" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 11, 14, 11, 56, 33, 413, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 11, 14, 11, 56, 33, 413, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 11, 14, 11, 56, 33, 413, DateTimeKind.Utc).AddTicks(8452));
        }
    }
}
