using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class SprintEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Bugs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprint_Projects_ProjectId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_SprintId",
                table: "Bugs",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_ProjectId",
                table: "Sprint",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Sprint_SprintId",
                table: "Bugs",
                column: "SprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Sprint_SprintId",
                table: "Bugs");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_SprintId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Bugs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d873e2f-0832-4ae6-ae0c-2501bb89954b", "AQAAAAEAACcQAAAAEH+IL30TewSSj07BlPfT4+MHwYHVIkR50NQN4eWvxI2FxVsHycp7o/UoDzfCqaNL/A==", "2ca28394-9291-41f8-b64b-05c97a866d3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32f62e50-1c23-4d6b-813e-3386887dd92f", "AQAAAAEAACcQAAAAEGBsizYHw/zIiBpFdtYoY2rQM/qHoN3LGKxEaAZbIN4cokK37OqKua9vZBv3MFKGcg==", "d759d0bb-a54a-4156-a29d-6c807961c315" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 4, 3, 6, 47, 23, 748, DateTimeKind.Utc).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 4, 3, 6, 47, 23, 748, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 4, 3, 6, 47, 23, 748, DateTimeKind.Utc).AddTicks(5305));
        }
    }
}
