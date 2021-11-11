using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class UserAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bugs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Bugs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedById",
                table: "Comments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ModifiedById",
                table: "Comments",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_CreatedById",
                table: "Bugs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_ModifiedById",
                table: "Bugs",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_CreatedById",
                table: "Bugs",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_ModifiedById",
                table: "Bugs",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedById",
                table: "Comments",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ModifiedById",
                table: "Comments",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_CreatedById",
                table: "Bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_ModifiedById",
                table: "Bugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CreatedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ModifiedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CreatedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ModifiedById",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_CreatedById",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_ModifiedById",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Bugs");

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
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "None", 1, "Open", "Implement project controllers" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Better domaine events pattern", null, "None", 1, "Open", "update project title" });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "Created", "Description", "Modified", "Priority", "ProjectId", "Status", "Title" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "None", 2, "Open", "How you doing?" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "Modified", "Text" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 11, 15, 22, 13, 932, DateTimeKind.Utc).AddTicks(3666), null, "This has been implemented" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "Modified", "Text" },
                values: new object[] { 2, 1, new DateTime(2021, 11, 11, 15, 22, 13, 932, DateTimeKind.Utc).AddTicks(4187), null, "Nope" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BugId", "Created", "Modified", "Text" },
                values: new object[] { 3, 2, new DateTime(2021, 11, 11, 15, 22, 13, 932, DateTimeKind.Utc).AddTicks(4190), null, "Any progress?" });
        }
    }
}
