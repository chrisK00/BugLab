using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Deleted",
                table: "Comments",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_Deleted",
                table: "Bugs",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_Priority",
                table: "Bugs",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_Status",
                table: "Bugs",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_Title",
                table: "Bugs",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Comments_Deleted",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_Deleted",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_Priority",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_Status",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_Title",
                table: "Bugs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "757b2158-40c3-4917-9523-5861973a4d2e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "530223b3-ed1a-4b17-b834-3b3ee167f26d", "AQAAAAEAACcQAAAAEAnsXsh+Cs/vtb5i36/kY2WBvDus5YdueNm7zpi+nAaeb79rl/KCx5zpzl+2A+E3EQ==", "0294c916-29e1-4c13-ae23-b6ab6fc6d11e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9789ABC4-C48A-45E8-9E7A-0F7E341E7A62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d507f49-52bb-400c-86dc-2dcbc9b4105f", "AQAAAAEAACcQAAAAEL57E0d3Y34SaL2s/ZYMGDXmVHJASdS3EiCJWNY0SH1ktLuYm2J83gguSxSz4I4lwA==", "50ab8697-9bd8-43e6-8d47-0aaf0775fdff" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2022, 3, 31, 17, 26, 56, 343, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2022, 3, 31, 17, 26, 56, 343, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2022, 3, 31, 17, 26, 56, 343, DateTimeKind.Utc).AddTicks(3435));
        }
    }
}
