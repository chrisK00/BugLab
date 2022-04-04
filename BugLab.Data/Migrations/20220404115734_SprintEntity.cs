using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class SprintEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Sprint_SprintId",
                table: "Bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_Projects_ProjectId",
                table: "Sprint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sprint",
                table: "Sprint");

            migrationBuilder.RenameTable(
                name: "Sprint",
                newName: "Sprints");

            migrationBuilder.RenameIndex(
                name: "IX_Sprint_ProjectId",
                table: "Sprints",
                newName: "IX_Sprints_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sprints",
                table: "Sprints",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Sprints_SprintId",
                table: "Bugs",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projects_ProjectId",
                table: "Sprints",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Sprints_SprintId",
                table: "Bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projects_ProjectId",
                table: "Sprints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sprints",
                table: "Sprints");

            migrationBuilder.RenameTable(
                name: "Sprints",
                newName: "Sprint");

            migrationBuilder.RenameIndex(
                name: "IX_Sprints_ProjectId",
                table: "Sprint",
                newName: "IX_Sprint_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sprint",
                table: "Sprint",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "466e4edd-146b-4ef1-b203-d3bd5cab1b57", "AQAAAAEAACcQAAAAEONlT0dkXn41oeHemLJAUZmT/u+0oVfdKpT7GcXtikaLJi3PU6/pnG3dYgp85IVwhw==", "628f0db3-0f67-4664-948b-89152870ffe6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acc45ebd-b66c-49a7-a270-6f7aa1f9be8e", "AQAAAAEAACcQAAAAEPFt7wuapfJjSM0n/VtBngwMH7/Qw8GNIdI1jwo+DnGSc1xxFvLbMKR2ENJhAszeHw==", "92456e18-c556-45b1-97cb-2458669ce6a0" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 4, 10, 40, 34, 444, DateTimeKind.Utc).AddTicks(1536));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 4, 10, 40, 34, 444, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 4, 4, 10, 40, 34, 444, DateTimeKind.Utc).AddTicks(1883));

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Sprint_SprintId",
                table: "Bugs",
                column: "SprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_Projects_ProjectId",
                table: "Sprint",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
