using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class AssignedTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedToId",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c855bc7-a989-40b3-af2c-4d043becfca0", "AQAAAAEAACcQAAAAECe9YUmS0prinSGcKuCrA1HfcF0I7wQ4qCO4Mv6sMedRTcMjo9duXRpAVa1jBRBhHQ==", "1ba9d657-a488-4428-8dc7-b8de736e78ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dff9dc54-4f50-469e-ae36-1efaf29573fc", "AQAAAAEAACcQAAAAELjhRpxTKLuVMtUhcVLQNyYGqDNuIm5H1kyzhujNN+AwEhoEaDnkJll/tfH6+52tGA==", "8106c729-32a1-45ed-9192-7e50112926ce" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 11, 24, 15, 4, 39, 353, DateTimeKind.Utc).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 11, 24, 15, 4, 39, 353, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 11, 24, 15, 4, 39, 353, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_AssignedToId",
                table: "Bugs",
                column: "AssignedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_AssignedToId",
                table: "Bugs",
                column: "AssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_AssignedToId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_AssignedToId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "Bugs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87ae3ca7-0769-4369-a2fa-9757df337f9e", "AQAAAAEAACcQAAAAEK6FYJVTsn24rXmqs9/18zTYcMCU3JeOtvCL6jn8vcnszE9zb5Em8zY2mnB0jNzttQ==", "a31cea35-6c1a-4450-8ac1-8eb2de8a565a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b4a38d6-27ca-4e4c-b4c1-89865ebfb8bd", "AQAAAAEAACcQAAAAEPmpdZmK1kk17IjlbIa2lzgULn/eQTEDoR0XbEyqR6CjdQtiielFuNxmXOK+voIezw==", "bde74562-2298-40d5-8a31-b8385a7d2b2d" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 11, 17, 22, 7, 27, 454, DateTimeKind.Utc).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 11, 17, 22, 7, 27, 455, DateTimeKind.Utc).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 11, 17, 22, 7, 27, 455, DateTimeKind.Utc).AddTicks(537));
        }
    }
}
