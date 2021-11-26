using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class ProjectUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectUsers",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsers", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca10ad6a-7b2d-4257-aba8-9c053b11f3dc", "AQAAAAEAACcQAAAAEMU5WL5+FMiBB/C2mqP9r+4xxF//5pCOjSXs01YRRnH76DuMCesd+gIrp2BEes7/Pg==", "e04c9725-1613-4d09-b521-b68d56eaf678" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbb2c297-6f8d-42a4-9654-5f8e535a25c1", "AQAAAAEAACcQAAAAECJF6h3jAGoeU6DA4OXrvvxanPjzrFcl71Yt05+5ug++6YGz9LgxLLyX+wTm/zLoDA==", "f2b0c232-3a99-45b7-8cb7-518d92936e82" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 11, 26, 17, 24, 37, 866, DateTimeKind.Utc).AddTicks(7304));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 11, 26, 17, 24, 37, 866, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 11, 26, 17, 24, 37, 866, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_ProjectId",
                table: "ProjectUsers",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUsers");

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
        }
    }
}
