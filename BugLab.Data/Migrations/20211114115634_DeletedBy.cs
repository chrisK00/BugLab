using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class DeletedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DeletedById",
                table: "Comments",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_DeletedById",
                table: "Bugs",
                column: "DeletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_DeletedById",
                table: "Bugs",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_DeletedById",
                table: "Comments",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_DeletedById",
                table: "Bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_DeletedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_DeletedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_DeletedById",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Bugs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "beb82d59-4b98-4d3b-9c0e-cd475ccdba10", "AQAAAAEAACcQAAAAECcG+lJQ1Dien7luSX3gTnDtyDi3ua0xJJm0wG4qSaIrEG9WG73KbCPrqQWnLX1BZw==", "a5c5d217-9520-460f-b64c-daa59b0f5d59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9e22fa1-f9ea-4bcb-bcba-002550555fff", "AQAAAAEAACcQAAAAEJsCiMrS6VazQ3u39+xlXYr2Z+VzGvlWeTMRHJCsmn8sfxGYKi1BCMInR2Jyc+xnmQ==", "dc16f8af-d90e-483f-935a-6d076d15fe9c" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 11, 14, 8, 46, 26, 794, DateTimeKind.Utc).AddTicks(44));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 11, 14, 8, 46, 26, 794, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 11, 14, 8, 46, 26, 794, DateTimeKind.Utc).AddTicks(1273));
        }
    }
}
